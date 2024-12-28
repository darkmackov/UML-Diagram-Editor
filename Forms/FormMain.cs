using UML_Diagram_Editor.Entities;

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
            MessageBox.Show("NOT IMPLEMENTED!");
        }

        private void buttonDeleteBox_Click(object sender, EventArgs e)
        {
            _canvas.RemoveBox();
            pictureBox.Refresh();
        }

    }
}
