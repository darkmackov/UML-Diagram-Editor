using System.Drawing.Imaging;
using UML_Diagram_Editor.Entities;
using UML_Diagram_Editor.Forms;

namespace UML_Diagram_Editor
{
    public partial class FormMain : Form
    {
        private readonly Canvas _canvas;

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
            if (e.Button != MouseButtons.Left)
                return;

            if (_canvas.Selection != null)
            {
                _canvas.Unselect();
            }
            else
            {
                _canvas.Select(e.X, e.Y);
                pictureBox.Refresh();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            _canvas.Move(e.X, e.Y);
            pictureBox.Refresh();
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
            Form form = new FormEditBox(_canvas.Selection.SelectedBox);
            form.ShowDialog();
        }

        private void buttonDeleteBox_Click(object sender, EventArgs e)
        {
            _canvas.RemoveBox();
            pictureBox.Refresh();
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
    }
}
