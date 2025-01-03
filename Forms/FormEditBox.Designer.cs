namespace UML_Diagram_Editor.Forms
{
    partial class FormEditBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            dataGridViewMethods = new DataGridView();
            dataGridViewVariables = new DataGridView();
            labelMethods = new Label();
            labelProperties = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            textBoxTitle = new TextBox();
            labelTitle = new Label();
            buttonCancel = new Button();
            buttonSave = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMethods).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVariables).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonCancel, 0, 1);
            tableLayoutPanel1.Controls.Add(buttonSave, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(dataGridViewMethods, 0, 3);
            tableLayoutPanel2.Controls.Add(dataGridViewVariables, 0, 1);
            tableLayoutPanel2.Controls.Add(labelMethods, 0, 2);
            tableLayoutPanel2.Controls.Add(labelProperties, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(403, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(394, 404);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // dataGridViewMethods
            // 
            dataGridViewMethods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewMethods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMethods.ColumnHeadersVisible = false;
            dataGridViewMethods.Dock = DockStyle.Fill;
            dataGridViewMethods.Location = new Point(3, 225);
            dataGridViewMethods.Name = "dataGridViewMethods";
            dataGridViewMethods.Size = new Size(388, 176);
            dataGridViewMethods.TabIndex = 1;
            // 
            // dataGridViewVariables
            // 
            dataGridViewVariables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVariables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVariables.ColumnHeadersVisible = false;
            dataGridViewVariables.Dock = DockStyle.Fill;
            dataGridViewVariables.Location = new Point(3, 23);
            dataGridViewVariables.Name = "dataGridViewVariables";
            dataGridViewVariables.Size = new Size(388, 176);
            dataGridViewVariables.TabIndex = 0;
            // 
            // labelMethods
            // 
            labelMethods.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelMethods.AutoSize = true;
            labelMethods.Location = new Point(3, 204);
            labelMethods.Name = "labelMethods";
            labelMethods.Size = new Size(388, 15);
            labelMethods.TabIndex = 2;
            labelMethods.Text = "Methods";
            // 
            // labelProperties
            // 
            labelProperties.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelProperties.AutoSize = true;
            labelProperties.Location = new Point(3, 2);
            labelProperties.Name = "labelProperties";
            labelProperties.Size = new Size(388, 15);
            labelProperties.TabIndex = 3;
            labelProperties.Text = "Properties";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(textBoxTitle, 0, 1);
            tableLayoutPanel3.Controls.Add(labelTitle, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(394, 404);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTitle.Location = new Point(3, 23);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(388, 23);
            textBoxTitle.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(3, 2);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(388, 15);
            labelTitle.TabIndex = 1;
            labelTitle.Text = "Title";
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonCancel.Location = new Point(3, 418);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(394, 23);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonSave.Location = new Point(403, 418);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(394, 23);
            buttonSave.TabIndex = 5;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // FormEditBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "FormEditBox";
            Text = "UML Diagram Editor - Box Editor";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMethods).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVariables).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridViewVariables;
        private DataGridView dataGridViewMethods;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox textBoxTitle;
        private Button buttonCancel;
        private Button buttonSave;
        private Label labelMethods;
        private Label labelProperties;
        private Label labelTitle;
    }
}