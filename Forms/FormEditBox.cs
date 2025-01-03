﻿using System.ComponentModel;
using UML_Diagram_Editor.Entities;

namespace UML_Diagram_Editor.Forms
{
    public partial class FormEditBox : Form
    {
        private Box _editedBox;
        private BindingList<TextContent> _properties = new();
        private BindingList<TextContent> _methods = new();

        public FormEditBox(Box box)
        {
            _editedBox = box;
            InitializeComponent();

            LoadBoxData();
            dataGridViewVariables.DataSource = _properties;
            dataGridViewMethods.DataSource = _methods;
        }

        public void LoadBoxData()
        {
            _properties = new BindingList<TextContent>(_editedBox.Properties.ToList());
            _methods = new BindingList<TextContent>(_editedBox.Methods.ToList());
            textBoxTitle.Text = _editedBox.Title;
        }

        public void SaveBoxData()
        {
            _editedBox.Properties = new List<TextContent>(_properties);
            _editedBox.Methods = new List<TextContent>(_methods);
            _editedBox.Title = textBoxTitle.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveBoxData();
            _editedBox.UpdateMinSize();
            _editedBox.Resize(_editedBox.Width, _editedBox.Height);

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
