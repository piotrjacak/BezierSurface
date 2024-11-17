namespace GK_BezierSurface
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            loadPointsFromFileToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            drawingPanel = new Panel();
            slidersTableLayout = new TableLayoutPanel();
            panel1 = new Panel();
            gridSizeSlider = new TrackBar();
            gridSizeVal = new Label();
            gridSizeDesc = new Label();
            panelRotateOX = new Panel();
            rotateOXSlider = new TrackBar();
            rotateOXVal = new Label();
            rotateOXDesc = new Label();
            panelRotateOZ = new Panel();
            rotateOZSlider = new TrackBar();
            rotateOZVal = new Label();
            rotateOZDesc = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            radioButtonGrid = new RadioButton();
            radioButtonFill = new RadioButton();
            tableLayoutPanel3 = new TableLayoutPanel();
            surfaceColorButton = new Button();
            setLightButton = new Button();
            importTextureButton = new Button();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel2 = new Panel();
            label1 = new Label();
            kd_trackBar = new TrackBar();
            trackBar1 = new TrackBar();
            panel3 = new Panel();
            label2 = new Label();
            ks_trackBar = new TrackBar();
            panel4 = new Panel();
            M = new Label();
            m_trackBar = new TrackBar();
            tableLayoutPanel5 = new TableLayoutPanel();
            startAnimationBtn = new Button();
            panel5 = new Panel();
            z_label = new Label();
            label3 = new Label();
            z_trackBar = new TrackBar();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            slidersTableLayout.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridSizeSlider).BeginInit();
            panelRotateOX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rotateOXSlider).BeginInit();
            panelRotateOZ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rotateOZSlider).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kd_trackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ks_trackBar).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)m_trackBar).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)z_trackBar).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 1, 0, 1);
            menuStrip1.Size = new Size(1384, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadPointsFromFileToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 22);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // loadPointsFromFileToolStripMenuItem
            // 
            loadPointsFromFileToolStripMenuItem.Name = "loadPointsFromFileToolStripMenuItem";
            loadPointsFromFileToolStripMenuItem.Size = new Size(188, 22);
            loadPointsFromFileToolStripMenuItem.Text = "Load Points From File";
            loadPointsFromFileToolStripMenuItem.Click += loadPointsFromFileToolStripMenuItem_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1000F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(drawingPanel, 0, 0);
            tableLayoutPanel1.Controls.Add(slidersTableLayout, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Margin = new Padding(2, 1, 2, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1384, 937);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // drawingPanel
            // 
            drawingPanel.BackColor = Color.White;
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(2, 1);
            drawingPanel.Margin = new Padding(2, 1, 2, 1);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(996, 935);
            drawingPanel.TabIndex = 0;
            drawingPanel.Paint += drawingPanel_Paint;
            // 
            // slidersTableLayout
            // 
            slidersTableLayout.ColumnCount = 1;
            slidersTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            slidersTableLayout.Controls.Add(panel1, 0, 0);
            slidersTableLayout.Controls.Add(panelRotateOX, 0, 1);
            slidersTableLayout.Controls.Add(panelRotateOZ, 0, 2);
            slidersTableLayout.Controls.Add(tableLayoutPanel2, 0, 3);
            slidersTableLayout.Controls.Add(tableLayoutPanel3, 0, 4);
            slidersTableLayout.Controls.Add(tableLayoutPanel4, 0, 5);
            slidersTableLayout.Controls.Add(tableLayoutPanel5, 0, 6);
            slidersTableLayout.Dock = DockStyle.Fill;
            slidersTableLayout.Location = new Point(1002, 1);
            slidersTableLayout.Margin = new Padding(2, 1, 2, 1);
            slidersTableLayout.Name = "slidersTableLayout";
            slidersTableLayout.RowCount = 8;
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 79F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            slidersTableLayout.Size = new Size(380, 935);
            slidersTableLayout.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(gridSizeSlider);
            panel1.Controls.Add(gridSizeVal);
            panel1.Controls.Add(gridSizeDesc);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(2, 1);
            panel1.Margin = new Padding(2, 1, 2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(376, 64);
            panel1.TabIndex = 0;
            // 
            // gridSizeSlider
            // 
            gridSizeSlider.Dock = DockStyle.Bottom;
            gridSizeSlider.Location = new Point(0, 19);
            gridSizeSlider.Margin = new Padding(2, 1, 2, 1);
            gridSizeSlider.Maximum = 40;
            gridSizeSlider.Minimum = 10;
            gridSizeSlider.Name = "gridSizeSlider";
            gridSizeSlider.Size = new Size(376, 45);
            gridSizeSlider.TabIndex = 2;
            gridSizeSlider.Value = 32;
            gridSizeSlider.ValueChanged += gridSizeSlider_ValueChanged;
            // 
            // gridSizeVal
            // 
            gridSizeVal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gridSizeVal.AutoSize = true;
            gridSizeVal.Location = new Point(348, 1);
            gridSizeVal.Margin = new Padding(2, 0, 2, 0);
            gridSizeVal.Name = "gridSizeVal";
            gridSizeVal.Padding = new Padding(1);
            gridSizeVal.Size = new Size(21, 17);
            gridSizeVal.TabIndex = 1;
            gridSizeVal.Text = "32";
            // 
            // gridSizeDesc
            // 
            gridSizeDesc.AutoSize = true;
            gridSizeDesc.Location = new Point(0, 0);
            gridSizeDesc.Margin = new Padding(2, 0, 2, 0);
            gridSizeDesc.Name = "gridSizeDesc";
            gridSizeDesc.Padding = new Padding(1);
            gridSizeDesc.Size = new Size(54, 17);
            gridSizeDesc.TabIndex = 0;
            gridSizeDesc.Text = "Grid Size";
            // 
            // panelRotateOX
            // 
            panelRotateOX.Controls.Add(rotateOXSlider);
            panelRotateOX.Controls.Add(rotateOXVal);
            panelRotateOX.Controls.Add(rotateOXDesc);
            panelRotateOX.Dock = DockStyle.Fill;
            panelRotateOX.Location = new Point(2, 67);
            panelRotateOX.Margin = new Padding(2, 1, 2, 1);
            panelRotateOX.Name = "panelRotateOX";
            panelRotateOX.Size = new Size(376, 64);
            panelRotateOX.TabIndex = 1;
            // 
            // rotateOXSlider
            // 
            rotateOXSlider.Dock = DockStyle.Bottom;
            rotateOXSlider.Location = new Point(0, 19);
            rotateOXSlider.Margin = new Padding(2, 1, 2, 1);
            rotateOXSlider.Name = "rotateOXSlider";
            rotateOXSlider.Size = new Size(376, 45);
            rotateOXSlider.TabIndex = 2;
            rotateOXSlider.ValueChanged += rotateOXSlider_ValueChanged;
            // 
            // rotateOXVal
            // 
            rotateOXVal.AutoSize = true;
            rotateOXVal.Location = new Point(354, 0);
            rotateOXVal.Margin = new Padding(2, 0, 2, 0);
            rotateOXVal.Name = "rotateOXVal";
            rotateOXVal.Padding = new Padding(1);
            rotateOXVal.Size = new Size(15, 17);
            rotateOXVal.TabIndex = 1;
            rotateOXVal.Text = "0";
            // 
            // rotateOXDesc
            // 
            rotateOXDesc.AutoSize = true;
            rotateOXDesc.Location = new Point(2, 0);
            rotateOXDesc.Margin = new Padding(2, 0, 2, 0);
            rotateOXDesc.Name = "rotateOXDesc";
            rotateOXDesc.Padding = new Padding(1);
            rotateOXDesc.Size = new Size(62, 17);
            rotateOXDesc.TabIndex = 0;
            rotateOXDesc.Text = "Rotate OX";
            // 
            // panelRotateOZ
            // 
            panelRotateOZ.Controls.Add(rotateOZSlider);
            panelRotateOZ.Controls.Add(rotateOZVal);
            panelRotateOZ.Controls.Add(rotateOZDesc);
            panelRotateOZ.Dock = DockStyle.Fill;
            panelRotateOZ.Location = new Point(2, 133);
            panelRotateOZ.Margin = new Padding(2, 1, 2, 1);
            panelRotateOZ.Name = "panelRotateOZ";
            panelRotateOZ.Size = new Size(376, 64);
            panelRotateOZ.TabIndex = 2;
            // 
            // rotateOZSlider
            // 
            rotateOZSlider.Dock = DockStyle.Bottom;
            rotateOZSlider.Location = new Point(0, 19);
            rotateOZSlider.Margin = new Padding(2, 1, 2, 1);
            rotateOZSlider.Maximum = 45;
            rotateOZSlider.Minimum = -45;
            rotateOZSlider.Name = "rotateOZSlider";
            rotateOZSlider.Size = new Size(376, 45);
            rotateOZSlider.TabIndex = 2;
            rotateOZSlider.ValueChanged += rotateOZSlider_ValueChanged;
            // 
            // rotateOZVal
            // 
            rotateOZVal.AutoSize = true;
            rotateOZVal.Location = new Point(354, 1);
            rotateOZVal.Margin = new Padding(2, 0, 2, 0);
            rotateOZVal.Name = "rotateOZVal";
            rotateOZVal.Padding = new Padding(1);
            rotateOZVal.Size = new Size(15, 17);
            rotateOZVal.TabIndex = 1;
            rotateOZVal.Text = "0";
            // 
            // rotateOZDesc
            // 
            rotateOZDesc.AutoSize = true;
            rotateOZDesc.Location = new Point(2, 0);
            rotateOZDesc.Margin = new Padding(2, 0, 2, 0);
            rotateOZDesc.Name = "rotateOZDesc";
            rotateOZDesc.Padding = new Padding(1);
            rotateOZDesc.Size = new Size(62, 17);
            rotateOZDesc.TabIndex = 0;
            rotateOZDesc.Text = "Rotate OZ";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(radioButtonGrid, 0, 0);
            tableLayoutPanel2.Controls.Add(radioButtonFill, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 201);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel2.Size = new Size(374, 27);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // radioButtonGrid
            // 
            radioButtonGrid.AutoSize = true;
            radioButtonGrid.Checked = true;
            radioButtonGrid.Dock = DockStyle.Fill;
            radioButtonGrid.Location = new Point(3, 3);
            radioButtonGrid.Name = "radioButtonGrid";
            radioButtonGrid.Size = new Size(181, 21);
            radioButtonGrid.TabIndex = 0;
            radioButtonGrid.TabStop = true;
            radioButtonGrid.Text = "Draw Grid";
            radioButtonGrid.UseVisualStyleBackColor = true;
            radioButtonGrid.Click += radioButtonGrid_Click;
            // 
            // radioButtonFill
            // 
            radioButtonFill.AutoSize = true;
            radioButtonFill.Dock = DockStyle.Fill;
            radioButtonFill.Location = new Point(190, 3);
            radioButtonFill.Name = "radioButtonFill";
            radioButtonFill.Size = new Size(181, 21);
            radioButtonFill.TabIndex = 1;
            radioButtonFill.Text = "Fill triangles";
            radioButtonFill.UseVisualStyleBackColor = true;
            radioButtonFill.Click += radioButtonFill_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tableLayoutPanel3.Controls.Add(surfaceColorButton, 0, 0);
            tableLayoutPanel3.Controls.Add(setLightButton, 1, 0);
            tableLayoutPanel3.Controls.Add(importTextureButton, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(2, 232);
            tableLayoutPanel3.Margin = new Padding(2, 1, 2, 1);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel3.Size = new Size(376, 40);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // surfaceColorButton
            // 
            surfaceColorButton.BackColor = Color.LightBlue;
            surfaceColorButton.Dock = DockStyle.Fill;
            surfaceColorButton.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 238);
            surfaceColorButton.Location = new Point(2, 1);
            surfaceColorButton.Margin = new Padding(2, 1, 2, 1);
            surfaceColorButton.Name = "surfaceColorButton";
            surfaceColorButton.Size = new Size(121, 38);
            surfaceColorButton.TabIndex = 0;
            surfaceColorButton.Text = "Set surface color";
            surfaceColorButton.UseVisualStyleBackColor = false;
            surfaceColorButton.Click += surfaceColorButton_Click;
            // 
            // setLightButton
            // 
            setLightButton.Dock = DockStyle.Fill;
            setLightButton.Font = new Font("Segoe UI", 8F);
            setLightButton.Location = new Point(127, 1);
            setLightButton.Margin = new Padding(2, 1, 2, 1);
            setLightButton.Name = "setLightButton";
            setLightButton.Size = new Size(121, 38);
            setLightButton.TabIndex = 1;
            setLightButton.Text = "Set light color";
            setLightButton.UseVisualStyleBackColor = true;
            setLightButton.Click += setLightButton_Click;
            // 
            // importTextureButton
            // 
            importTextureButton.Dock = DockStyle.Fill;
            importTextureButton.Font = new Font("Segoe UI", 8F);
            importTextureButton.Location = new Point(252, 1);
            importTextureButton.Margin = new Padding(2, 1, 2, 1);
            importTextureButton.Name = "importTextureButton";
            importTextureButton.Size = new Size(122, 38);
            importTextureButton.TabIndex = 2;
            importTextureButton.Text = "Import texture";
            importTextureButton.UseVisualStyleBackColor = true;
            importTextureButton.Click += importTextureButton_Click;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Controls.Add(panel2, 0, 0);
            tableLayoutPanel4.Controls.Add(panel3, 1, 0);
            tableLayoutPanel4.Controls.Add(panel4, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(2, 274);
            tableLayoutPanel4.Margin = new Padding(2, 1, 2, 1);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 63F));
            tableLayoutPanel4.Size = new Size(376, 64);
            tableLayoutPanel4.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(kd_trackBar);
            panel2.Controls.Add(trackBar1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(2, 1);
            panel2.Margin = new Padding(2, 1, 2, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(121, 62);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 2);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 2;
            label1.Text = "KD";
            // 
            // kd_trackBar
            // 
            kd_trackBar.Location = new Point(2, 17);
            kd_trackBar.Margin = new Padding(2, 1, 2, 1);
            kd_trackBar.Maximum = 100;
            kd_trackBar.Name = "kd_trackBar";
            kd_trackBar.Size = new Size(92, 45);
            kd_trackBar.TabIndex = 1;
            kd_trackBar.Value = 75;
            kd_trackBar.ValueChanged += kd_trackBar_ValueChanged;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(2, 17);
            trackBar1.Margin = new Padding(2, 1, 2, 1);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(92, 45);
            trackBar1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(ks_trackBar);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(127, 1);
            panel3.Margin = new Padding(2, 1, 2, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(121, 62);
            panel3.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 2);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 1;
            label2.Text = "KS";
            // 
            // ks_trackBar
            // 
            ks_trackBar.Location = new Point(0, 17);
            ks_trackBar.Margin = new Padding(2, 1, 2, 1);
            ks_trackBar.Maximum = 100;
            ks_trackBar.Name = "ks_trackBar";
            ks_trackBar.Size = new Size(94, 45);
            ks_trackBar.TabIndex = 0;
            ks_trackBar.Value = 75;
            ks_trackBar.ValueChanged += ks_trackBar_ValueChanged;
            // 
            // panel4
            // 
            panel4.Controls.Add(M);
            panel4.Controls.Add(m_trackBar);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(252, 1);
            panel4.Margin = new Padding(2, 1, 2, 1);
            panel4.Name = "panel4";
            panel4.Size = new Size(122, 62);
            panel4.TabIndex = 2;
            // 
            // M
            // 
            M.AutoSize = true;
            M.Location = new Point(2, 2);
            M.Margin = new Padding(2, 0, 2, 0);
            M.Name = "M";
            M.Size = new Size(18, 15);
            M.TabIndex = 1;
            M.Text = "M";
            // 
            // m_trackBar
            // 
            m_trackBar.Location = new Point(2, 17);
            m_trackBar.Margin = new Padding(2, 1, 2, 1);
            m_trackBar.Maximum = 100;
            m_trackBar.Name = "m_trackBar";
            m_trackBar.Size = new Size(92, 45);
            m_trackBar.TabIndex = 0;
            m_trackBar.Value = 10;
            m_trackBar.ValueChanged += m_trackBar_ValueChanged;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.6987953F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.30121F));
            tableLayoutPanel5.Controls.Add(startAnimationBtn, 0, 0);
            tableLayoutPanel5.Controls.Add(panel5, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 342);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(374, 73);
            tableLayoutPanel5.TabIndex = 6;
            // 
            // startAnimationBtn
            // 
            startAnimationBtn.Dock = DockStyle.Fill;
            startAnimationBtn.Location = new Point(3, 3);
            startAnimationBtn.Name = "startAnimationBtn";
            startAnimationBtn.Size = new Size(86, 67);
            startAnimationBtn.TabIndex = 0;
            startAnimationBtn.Text = "Start Animation";
            startAnimationBtn.UseVisualStyleBackColor = true;
            startAnimationBtn.Click += startAnimationBtn_Click_1;
            // 
            // panel5
            // 
            panel5.Controls.Add(z_label);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(z_trackBar);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(95, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(276, 67);
            panel5.TabIndex = 1;
            // 
            // z_label
            // 
            z_label.AutoSize = true;
            z_label.Location = new Point(247, 1);
            z_label.Name = "z_label";
            z_label.Size = new Size(25, 15);
            z_label.TabIndex = 2;
            z_label.Text = "350";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 1);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 1;
            label3.Text = "Z = const";
            // 
            // z_trackBar
            // 
            z_trackBar.Dock = DockStyle.Bottom;
            z_trackBar.Location = new Point(0, 22);
            z_trackBar.Maximum = 500;
            z_trackBar.Minimum = 120;
            z_trackBar.Name = "z_trackBar";
            z_trackBar.Size = new Size(276, 45);
            z_trackBar.TabIndex = 0;
            z_trackBar.Value = 350;
            z_trackBar.ValueChanged += z_trackBar_ValueChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 961);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 1, 2, 1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bezier Surface";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            slidersTableLayout.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridSizeSlider).EndInit();
            panelRotateOX.ResumeLayout(false);
            panelRotateOX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rotateOXSlider).EndInit();
            panelRotateOZ.ResumeLayout(false);
            panelRotateOZ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rotateOZSlider).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)kd_trackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ks_trackBar).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)m_trackBar).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)z_trackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem loadPointsFromFileToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel drawingPanel;
        private TableLayoutPanel slidersTableLayout;
        private Panel panel1;
        private Label gridSizeVal;
        private Label gridSizeDesc;
        private TrackBar gridSizeSlider;
        private Panel panelRotateOX;
        private Label rotateOXVal;
        private Label rotateOXDesc;
        private ContextMenuStrip contextMenuStrip1;
        private TrackBar rotateOXSlider;
        private Panel panelRotateOZ;
        private TrackBar rotateOZSlider;
        private Label rotateOZVal;
        private Label rotateOZDesc;
        private TableLayoutPanel tableLayoutPanel2;
        private RadioButton radioButtonGrid;
        private RadioButton radioButtonFill;
        private TableLayoutPanel tableLayoutPanel3;
        private Button surfaceColorButton;
        private Button setLightButton;
        private Button importTextureButton;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel2;
        private TrackBar trackBar1;
        private Panel panel3;
        private Panel panel4;
        private TrackBar kd_trackBar;
        private TrackBar ks_trackBar;
        private TrackBar m_trackBar;
        private Label label1;
        private Label label2;
        private Label M;
        private TableLayoutPanel tableLayoutPanel5;
        private Button startAnimationBtn;
        private Panel panel5;
        private TrackBar z_trackBar;
        private Label label3;
        private Label z_label;
    }
}
