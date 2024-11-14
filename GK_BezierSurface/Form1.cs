using System.Drawing;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;

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

        public Form1()
        {
            InitializeComponent();
            //this.Size = new Size(2000, 1400);
            this.Size = new Size(1400, 800); // Rozmiar odpowiedni dla wyœwietlacza 1920x1080
            this.StartPosition = FormStartPosition.CenterScreen;

            bitmap = new DirectBitmap(drawingPanel.Width, drawingPanel.Height);
            controlPoints = new Vertex[4, 4];
            triangles = new List<Triangle>();

            prevAlpha = 0;
            alpha = 0;
            prevBeta = 0;
            beta = 0;
            gridSize = 20;
            pointsLoaded = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // Funkcja do odœwie¿ania panelu
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

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        g.FillEllipse(Brushes.Green, controlPoints[i, j].prevR.X - 5, controlPoints[i, j].prevR.Y - 5, 10, 10);
                    }
                }

                int k = 0;
                foreach (Triangle triangle in triangles)
                {
                    if (radioButtonGrid.Checked)
                    {
                        triangle.DrawTriangle(g);
                    }
                    else if (radioButtonFill.Checked)
                    {
                        triangle.DrawTriangle(g);

                        triangle.FillTriangle(g);
                        //if (k == 20) return;
                    }
                    k++;

                }

                DrawControlLines(g);
            }
        }

        // Funkcja do rysowania linii siatki miêdzy punktami kontrolnymi
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


        // Funkcja pomocnicza wyznaczaj¹ca siatkê trójk¹tów
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

            // Wyznaczenie trójk¹tów i dodanie do listy
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    int index = i * (gridSize + 1) + j;

                    Vertex p1 = points[index];
                    Vertex p2 = points[index + 1];
                    Vertex p3 = points[index + gridSize + 1];
                    Vertex p4 = points[index + gridSize + 2];

                    //Triangle t1 = new Triangle(p1, p2, p3);
                    //triangles.Add(t1);
                    Triangle t2 = new Triangle(p2, p3, p4);
                    triangles.Add(t2);

                    return;

                    //if (j == 0) return;
                }
            }
        }


        // Zmiana rozmiaru siatki
        private void gridSizeSlider_ValueChanged(object sender, EventArgs e)
        {
            this.gridSize = gridSizeSlider.Value;
            gridSizeVal.Text = gridSizeSlider.Value.ToString();

            drawingPanel.Invalidate();
        }

        // Obrót wzd³u¿ osi OX
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

        // Obrót wzd³u¿ osi OZ
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
            // Wczytywanie punktów zak³ada, ¿e punkty kontrolne s¹ wypisane w pliku tekstowym
            // Od lewej do prawej i od góry do do³u (patrz¹c z góry na siatkê)
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

        // Wczytywanie pliku i odœwie¿anie panelu
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

                    ReadPoints(filePath);
                }
            }
            pointsLoaded = true;
            rotateOXSlider.Value = 0;
            rotateOZSlider.Value = 0;
            SetUpTriangles();

            drawingPanel.Invalidate();
        }

        private void radioButtonGrid_Click(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }

        private void radioButtonFill_Click(object sender, EventArgs e)
        {
            drawingPanel.Invalidate();
        }
    }
}
