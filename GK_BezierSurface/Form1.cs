using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GK_BezierSurface
{
    public partial class Form1 : Form
    {
        public Vertex[,] controlPoints { get; set; }
        public List<Triangle> triangles { get; set; }
        public DirectBitmap bitmap { get; set; }
        public int gridSize { get; set; }

        public int prevAlpha { get; set; }
        public int alpha { get; set; }
        public int prevBeta { get; set; }
        public int beta { get; set; }
        public bool pointsLoaded { get; set; }

        public SolidBrush fillColor { get; set; }
        public SolidBrush lightColor { get; set; }

        public float kd { get; set; }
        public float ks { get; set; }
        public int m { get; set; }

        public Vector3 lightDirection { get; set; }
        public float zAnimation { get; set; }
        public bool isAnimated { get; set; }
        public System.Windows.Forms.Timer animationTimer { get; set; }
        public float angle { get; set; }

        public Bitmap scaledImage { get; set; }

        public bool isNormalMap { get; set; }


        public Form1()
        {
            InitializeComponent();
            //this.Size = new Size(2000, 1400);
            this.Size = new Size(1400, 800); // Rozmiar odpowiedni dla wyświetlacza 1920x1080
            this.StartPosition = FormStartPosition.CenterScreen;

            // Bitmapa i punkty kontrolne
            bitmap = new DirectBitmap(drawingPanel.Width, drawingPanel.Height);
            controlPoints = new Vertex[4, 4];
            triangles = new List<Triangle>();

            // Kąty obrotu i rozmiar siatki
            prevAlpha = 0;
            alpha = 0;
            prevBeta = 0;
            beta = 0;
            gridSize = gridSizeSlider.Value;
            pointsLoaded = false;

            // Kolory wypełnienia i światła
            fillColor = new SolidBrush(Color.LightBlue);
            lightColor = new SolidBrush(Color.White);

            // Współczynniki oświetlenia
            kd = (float)kd_trackBar.Value / 100;
            ks = (float)ks_trackBar.Value / 100;
            m = m_trackBar.Value;

            // Animacja
            zAnimation = z_trackBar.Value;
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 2000;
            animationTimer.Tick += (sender, args) => AnimationTimer_Tick(sender, args);
            isAnimated = false;
            angle = 0f;

            // Światło
            lightDirection = new Vector3(120, 120, zAnimation);

            // Mapa wektorów normalnych
            isNormalMap = false;

            // Wczytanie domyślnej tekstury
            ReadPoints(@"controlPoints\initialPoints.txt");
            pointsLoaded = true;
            scaledImage = new Bitmap(@"textures\normalMap1.jpg");
            radioButtonTexture.Enabled = true;
            radioButtonTexture.Checked = true;
            SetUpTriangles();
            drawingPanel.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Funkcja do odświeżania panelu
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!pointsLoaded) return;

            BitmapDraw();
            e.Graphics.DrawImage(bitmap.Bitmap, Point.Empty);
        }

        // Funkcja do rysowania Bitmapy
        private void BitmapDraw()
        {
            bitmap = new DirectBitmap(drawingPanel.Width, drawingPanel.Height);

            using (var g = Graphics.FromImage(this.bitmap.Bitmap))
            {
                g.ScaleTransform(1, -1);
                g.TranslateTransform(drawingPanel.Width / 2, -drawingPanel.Height / 2);

                // Wypełnianie trójkątów
                foreach (Triangle triangle in triangles)
                {
                    triangle.ks = ks;
                    triangle.kd = kd;
                    triangle.m = m;
                    triangle.lightDirection = lightDirection;
                    triangle.isNormalMap = isNormalMap;

                    if (radioButtonGrid.Checked)
                    {
                        triangle.DrawTriangle(g);
                    }
                    else if (radioButtonFill.Checked)
                    {
                        triangle.FillTriangle(g, bitmap, false);
                    }
                    else if (radioButtonTexture.Checked)
                    {
                        triangle.texture = scaledImage;
                        triangle.FillTriangle(g, bitmap, true);
                    }
                }

                // Rysowanie linii miedzy punktami kontrolnymi
                DrawControlLines(g);

                // Punkty kontrolne
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        g.FillEllipse(Brushes.Green, controlPoints[i, j].prevR.X - 5, controlPoints[i, j].prevR.Y - 5, 10, 10);
                    }
                }

                // Punkt oznaczający pozycję światła
                if (radioButtonTexture.Checked || radioButtonFill.Checked)
                    g.FillEllipse(Brushes.White, lightDirection.X - 6, lightDirection.Y - 6, 12, 12);
            }
        }

        // Funkcja do rysowania linii siatki między punktami kontrolnymi
        private void DrawControlLines(Graphics g)
        {
            Pen pen = new Pen(Brushes.Black);
            pen.Width = 2;
            PointF p1;
            PointF p2;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    p1 = new PointF(controlPoints[i, j].prevR.X, controlPoints[i, j].prevR.Y);
                    p2 = new PointF(controlPoints[i, j + 1].prevR.X, controlPoints[i, j + 1].prevR.Y);

                    g.DrawLine(pen, p1, p2);
                }
            }
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    p1 = new PointF(controlPoints[i, j].prevR.X, controlPoints[i, j].prevR.Y);
                    p2 = new PointF(controlPoints[i + 1, j].prevR.X, controlPoints[i + 1, j].prevR.Y);

                    g.DrawLine(pen, p1, p2);
                }
            }
        }


        // Funkcja pomocnicza wyznaczająca siatkę trójkątów
        private void SetUpTriangles()
        {
            List<Vertex> points = new List<Vertex>();

            // Obliczenie punktów Beziera
            for (int i = 0; i <= gridSize; i++)
            {
                float u = i / (float)gridSize;
                for (int j = 0; j <= gridSize; j++)
                {
                    float v = j / (float)gridSize;

                    Vertex vertex = new Vertex();
                    vertex.u = u;
                    vertex.v = v;
                    for (int k = 0; k < 4; k++)
                    {
                        for (int l = 0; l < 4; l++)
                        {
                            vertex.controlPoints[k, l] = this.controlPoints[k, l];
                        }
                    }

                    vertex.CalculateBezierPoint();

                    points.Add(vertex);
                }
            }

            // Wyznaczenie trójkątów i dodanie do listy
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    int index = i * (gridSize + 1) + j;

                    Vertex p1 = points[index];
                    Vertex p2 = points[index + 1];
                    Vertex p3 = points[index + gridSize + 1];
                    Vertex p4 = points[index + gridSize + 2];

                    Triangle t1 = new Triangle(p1, p2, p3, this.kd, this.ks, this.m,
                        fillColor, lightColor, lightDirection);
                    triangles.Add(t1);
                    Triangle t2 = new Triangle(p2, p3, p4, this.kd, this.ks, this.m,
                        fillColor, lightColor, lightDirection);
                    triangles.Add(t2);
                }
            }
        }


        // Zmiana rozmiaru siatki
        private void gridSizeSlider_ValueChanged(object sender, EventArgs e)
        {
            this.gridSize = gridSizeSlider.Value;
            gridSizeVal.Text = gridSizeSlider.Value.ToString();

            triangles = new List<Triangle>();
            SetUpTriangles();
            drawingPanel.Invalidate();
        }

        // Obrót wzdłuż osi OX
        private void rotateOXSlider_ValueChanged(object sender, EventArgs e)
        {
            this.prevBeta = this.beta;
            this.beta = rotateOXSlider.Value;
            rotateOXVal.Text = rotateOXSlider.Value.ToString();

            int angle = this.beta - this.prevBeta;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    controlPoints[i, j].RotateOX(angle);
                }
            }
            triangles = new List<Triangle>();
            SetUpTriangles();

            drawingPanel.Invalidate();
        }

        // Obrót wzdłuż osi OZ
        private void rotateOZSlider_ValueChanged(object sender, EventArgs e)
        {
            this.prevAlpha = this.alpha;
            this.alpha = rotateOZSlider.Value;
            rotateOZVal.Text = rotateOZSlider.Value.ToString();

            int angle = this.alpha - this.prevAlpha;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    controlPoints[i, j].RotateOZ(angle);
                }
            }
            triangles = new List<Triangle>();
            SetUpTriangles();

            drawingPanel.Invalidate();
        }



        // Wczytywanie punktów kontrolnych z pliku
        private void ReadPoints(string filePath)
        {
            // Wczytywanie punktów zakłada, że punkty kontrolne są wypisane w pliku tekstowym
            // Od lewej do prawej i od góry do dołu (patrząc z góry na siatkę)
            int level = 0;
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    int lineCount = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(' ');

                        if (parts.Length == 3 &&
                            int.TryParse(parts[0], out int x) &&
                            int.TryParse(parts[1], out int y) &&
                            int.TryParse(parts[2], out int z))
                        {
                            Vertex vertex = new Vertex(new Vector3(x, y, z));

                            this.controlPoints[level, lineCount % 4] = vertex;
                            if (lineCount % 4 == 3) level++;

                            lineCount++;
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect file formatting in line: {line}");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File reading exception: {ex.Message}");
            }
        }

        // Wczytywanie pliku i odświeżanie panelu
        private void loadPointsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlPoints = new Vertex[4, 4];
            triangles = new List<Triangle>();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt";
                openFileDialog.Title = "Choose txt file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Console.WriteLine($"{filePath}");
                    ReadPoints(filePath);
                }
            }
            pointsLoaded = true;
            rotateOXSlider.Value = 0;
            rotateOZSlider.Value = 0;

            SetUpTriangles();

            drawingPanel.Invalidate();
        }


        // Radiobuttons
        private void radioButtonGrid_Click(object sender, EventArgs e)
        {
            triangles = new List<Triangle>();
            SetUpTriangles();
            drawingPanel.Invalidate();
        }
        private void radioButtonFill_Click(object sender, EventArgs e)
        {
            triangles = new List<Triangle>();
            SetUpTriangles();
            drawingPanel.Invalidate();
        }
        private void radioButtonTexture_Click(object sender, EventArgs e)
        {
            triangles = new List<Triangle>();
            SetUpTriangles();
            drawingPanel.Invalidate();
        }


        // Ustawienie koloru obiektu
        private void surfaceColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                fillColor = new SolidBrush(MyDialog.Color);
                surfaceColorButton.BackColor = MyDialog.Color;
            }
            triangles = new List<Triangle>();
            SetUpTriangles();
            drawingPanel.Invalidate();
        }

        // Ustawienie koloru światła
        private void setLightButton_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                lightColor = new SolidBrush(MyDialog.Color);
                setLightButton.BackColor = MyDialog.Color;
            }
            triangles = new List<Triangle>();
            SetUpTriangles();
            drawingPanel.Invalidate();
        }

        // Import tekstury
        private void importTextureButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Obrazy (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap ogBitmap = new Bitmap(dialog.FileName);
                    Console.WriteLine(dialog.FileName);
                    scaledImage = ogBitmap;
                    radioButtonTexture.Enabled = true;
                }
            }
            drawingPanel.Invalidate();
        }


        // Funkcje odpowiadajace za zmiany ustawien suwakow
        private void kd_trackBar_ValueChanged(object sender, EventArgs e)
        {
            kd = (float)kd_trackBar.Value / 100;
            drawingPanel.Invalidate();
        }
        private void ks_trackBar_ValueChanged(object sender, EventArgs e)
        {
            ks = (float)ks_trackBar.Value / 100;
            drawingPanel.Invalidate();
        }
        private void m_trackBar_ValueChanged(object sender, EventArgs e)
        {
            m = m_trackBar.Value;
            drawingPanel.Invalidate();
        }
        private void z_trackBar_ValueChanged(object sender, EventArgs e)
        {
            zAnimation = z_trackBar.Value;
            z_label.Text = zAnimation.ToString();

            lightDirection = new Vector3(lightDirection.X, lightDirection.Y, zAnimation);

            drawingPanel.Invalidate();
        }


        // Funkcje do animacji
        private void startAnimationBtn_Click_1(object sender, EventArgs e)
        {
            if (isAnimated && (radioButtonFill.Checked || radioButtonTexture.Checked))
            {
                // Zatrzymaj animację
                animationTimer.Stop();
                isAnimated = false;
                startAnimationBtn.Text = "Start Animation";
            }
            else if (radioButtonFill.Checked || radioButtonTexture.Checked)
            {
                // Rozpocznij animację
                animationTimer.Start();
                isAnimated = true;
                startAnimationBtn.Text = "Stop Animation";
            }
        }
        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (isAnimated)
            {
                PointF center = new PointF(0, 0);
                float radius = 120;

                angle += (float)Math.PI / 5;
                Vector3 light = new Vector3();

                light.X = center.X + radius * (float)Math.Cos(angle);
                light.Y = center.Y + radius * (float)Math.Sin(angle);
                light.Z = zAnimation;

                this.lightDirection = light;
                drawingPanel.Invalidate();
            }
        }

        private void checkBoxNormalMap_Click(object sender, EventArgs e)
        {
            if (checkBoxNormalMap.Checked)
                isNormalMap = true;
            else
                isNormalMap = false;

            drawingPanel.Invalidate();
        }
    }
}
