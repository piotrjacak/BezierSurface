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
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 1, 0, 1);
            menuStrip1.Size = new Size(955, 24);
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(drawingPanel, 0, 0);
            tableLayoutPanel1.Controls.Add(slidersTableLayout, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Margin = new Padding(2, 1, 2, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(955, 473);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // drawingPanel
            // 
            drawingPanel.BackColor = Color.White;
            drawingPanel.Dock = DockStyle.Fill;
            drawingPanel.Location = new Point(2, 1);
            drawingPanel.Margin = new Padding(2, 1, 2, 1);
            drawingPanel.Name = "drawingPanel";
            drawingPanel.Size = new Size(712, 471);
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
            slidersTableLayout.Dock = DockStyle.Top;
            slidersTableLayout.Location = new Point(718, 1);
            slidersTableLayout.Margin = new Padding(2, 1, 2, 1);
            slidersTableLayout.Name = "slidersTableLayout";
            slidersTableLayout.RowCount = 5;
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 66F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            slidersTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 47F));
            slidersTableLayout.Size = new Size(235, 260);
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
            panel1.Size = new Size(231, 64);
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
            gridSizeSlider.Size = new Size(231, 45);
            gridSizeSlider.TabIndex = 2;
            gridSizeSlider.Value = 20;
            gridSizeSlider.ValueChanged += gridSizeSlider_ValueChanged;
            // 
            // gridSizeVal
            // 
            gridSizeVal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gridSizeVal.AutoSize = true;
            gridSizeVal.Location = new Point(204, -1);
            gridSizeVal.Margin = new Padding(2, 0, 2, 0);
            gridSizeVal.Name = "gridSizeVal";
            gridSizeVal.Padding = new Padding(1);
            gridSizeVal.Size = new Size(21, 17);
            gridSizeVal.TabIndex = 1;
            gridSizeVal.Text = "20";
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
            panelRotateOX.Size = new Size(231, 64);
            panelRotateOX.TabIndex = 1;
            // 
            // rotateOXSlider
            // 
            rotateOXSlider.Dock = DockStyle.Bottom;
            rotateOXSlider.Location = new Point(0, 19);
            rotateOXSlider.Margin = new Padding(2, 1, 2, 1);
            rotateOXSlider.Name = "rotateOXSlider";
            rotateOXSlider.Size = new Size(231, 45);
            rotateOXSlider.TabIndex = 2;
            rotateOXSlider.ValueChanged += rotateOXSlider_ValueChanged;
            // 
            // rotateOXVal
            // 
            rotateOXVal.AutoSize = true;
            rotateOXVal.Location = new Point(213, -1);
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
            panelRotateOZ.Size = new Size(231, 64);
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
            rotateOZSlider.Size = new Size(231, 45);
            rotateOZSlider.TabIndex = 2;
            rotateOZSlider.ValueChanged += rotateOZSlider_ValueChanged;
            // 
            // rotateOZVal
            // 
            rotateOZVal.AutoSize = true;
            rotateOZVal.Location = new Point(213, 0);
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
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(229, 41);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // radioButtonGrid
            // 
            radioButtonGrid.AutoSize = true;
            radioButtonGrid.Checked = true;
            radioButtonGrid.Dock = DockStyle.Fill;
            radioButtonGrid.Location = new Point(3, 3);
            radioButtonGrid.Name = "radioButtonGrid";
            radioButtonGrid.Size = new Size(108, 35);
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
            radioButtonFill.Location = new Point(117, 3);
            radioButtonFill.Name = "radioButtonFill";
            radioButtonFill.Size = new Size(109, 35);
            radioButtonFill.TabIndex = 1;
            radioButtonFill.Text = "Fill triangles";
            radioButtonFill.UseVisualStyleBackColor = true;
            radioButtonFill.Click += radioButtonFill_Click;
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
            ClientSize = new Size(955, 497);
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
    }
}
