using System.Drawing.Imaging;
using Newtonsoft.Json;
using UML_Diagram_Editor.Entities;
using UML_Diagram_Editor.Forms;

namespace UML_Diagram_Editor
{
    public partial class FormMain : Form
    {
        private Canvas _canvas;
        private bool isDragging = false;
        private bool _trackLastSelectedBoxes = true; //TODO: Add checkbox to enable/disable tracking

        public FormMain()
        {
            _canvas = new Canvas();
            InitializeComponent();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            _canvas.Draw(e.Graphics);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_canvas.Selection != null)
            {
                _canvas.Unselect();
            }

            isDragging = true;
            _canvas.Select(e.X, e.Y);
            pictureBox.Refresh();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                _canvas.Move(e.X, e.Y);
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        public void buttonAddBox_Click(object sender, EventArgs e)
        {
            _canvas.AddBox();
            pictureBox.Refresh();
        }

        private void buttonEditBox_Click(object sender, EventArgs e)
        {
            if (_canvas.Selection == null)
                return;

            if (_canvas.Selection.SelectedObj is Box box)
            {
                Form form = new FormEditBox(box);
                form.ShowDialog();
            }
        }

        private void buttonDeleteSelected_Click(object sender, EventArgs e)
        {
            _canvas.RemoveSelected();
            pictureBox.Refresh();
        }

        private void buttonExportCode_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Not implemented!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            SaveFileDialog saveFileDialog = new()
            {
                FileName = "diagramCode",
                DefaultExt = ".cs",
                Filter = "C# Files (*.cs)|*.cs|Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };

            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                //TODO: Export code
            }
        }

        private void buttonExportPng_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                FileName = "diagram",
                DefaultExt = ".png",
                Filter = "PNG files (*.png)|*.png"
            };

            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                Graphics g = Graphics.FromImage(bmp);
                _canvas.Draw(g);

                bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void buttonSaveJson_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                FileName = "diagram",
                DefaultExt = ".json",
                Filter = "JSON files (*.json)|*.json"
            };

            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string data = JsonConvert.SerializeObject(_canvas, Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, data);
            }
        }

        private void buttonLoadJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                DefaultExt = ".json",
                Filter = "JSON files (*.json)|*.json"
            };

            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    _canvas = JsonConvert.DeserializeObject<Canvas>(fileContent);
                    _canvas.ReconnectLines();
                    pictureBox.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAddLine_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Not implemented!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

            _canvas.AddLine(LineType.Association);
            pictureBox.Refresh();
        }
    }
}
