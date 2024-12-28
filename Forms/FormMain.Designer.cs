﻿namespace UML_Diagram_Editor
{
    partial class FormMain
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonAddBox = new Button();
            buttonEditBox = new Button();
            buttonDeleteBox = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pictureBox, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(984, 761);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = SystemColors.ControlLight;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(203, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(778, 755);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Paint += pictureBox_Paint;
            pictureBox.MouseDown += pictureBox_MouseDown;
            pictureBox.MouseMove += pictureBox_MouseMove;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(buttonAddBox, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonEditBox, 0, 1);
            tableLayoutPanel2.Controls.Add(buttonDeleteBox, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(194, 755);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonAddBox
            // 
            buttonAddBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonAddBox.Location = new Point(3, 8);
            buttonAddBox.Name = "buttonAddBox";
            buttonAddBox.Size = new Size(188, 23);
            buttonAddBox.TabIndex = 0;
            buttonAddBox.Text = "Add Box";
            buttonAddBox.UseVisualStyleBackColor = true;
            buttonAddBox.Click += buttonAddBox_Click;
            // 
            // buttonEditBox
            // 
            buttonEditBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonEditBox.Location = new Point(3, 48);
            buttonEditBox.Name = "buttonEditBox";
            buttonEditBox.Size = new Size(188, 23);
            buttonEditBox.TabIndex = 1;
            buttonEditBox.Text = "Edit Box";
            buttonEditBox.UseVisualStyleBackColor = true;
            buttonEditBox.Click += buttonEditBox_Click;
            // 
            // buttonDeleteBox
            // 
            buttonDeleteBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonDeleteBox.Location = new Point(3, 88);
            buttonDeleteBox.Name = "buttonDeleteBox";
            buttonDeleteBox.Size = new Size(188, 23);
            buttonDeleteBox.TabIndex = 2;
            buttonDeleteBox.Text = "Delete Box";
            buttonDeleteBox.UseVisualStyleBackColor = true;
            buttonDeleteBox.Click += buttonDeleteBox_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 761);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMain";
            Text = "UML Diagram Editor";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonAddBox;
        private Button buttonEditBox;
        private Button buttonDeleteBox;
    }
}
