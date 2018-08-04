using System;
using System.Windows.Forms;

namespace TestApp
{
    public partial class MainForm : Form
    {
        bool _isModeifyTest;

        public MainForm()
        {
            InitializeComponent();
            _list.MouseDown += ListMouseDown;
            _clickCheck.MouseClick += _clickCheck_MouseClick;
            _clickCheck.MouseDoubleClick += _clickCheck_MouseDoubleClick;
            _moveCheck.MouseMove += _moveCheck_MouseMove;
            _keyTest.KeyDown += _keyTest_KeyDown;
            _panel.Click += _panel_Click;
            _panel.MouseWheel += _panel_MouseWheel;
        }

        private void _panel_MouseWheel(object sender, MouseEventArgs e)
        {
            _textBox.Text = e.Delta.ToString();
        }

        private void _panel_Click(object sender, EventArgs e)
        {
            var pos = _panel.PointToClient(Cursor.Position);
            _textBox.Text = pos.ToString();
        }

        private void _keyTest_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_isModeifyTest) return;

            if (e.KeyCode == Keys.Q)
            {
                switch (ModifierKeys)
                {
                    case Keys.Alt:
                        _keyTest.Text = "ALT + Q";
                        return;
                    case Keys.Control:
                        _keyTest.Text = "CONTROL + Q";
                        return;
                }
            }
            _keyTest.Text = string.Empty;
        }

        private void _moveCheck_MouseMove(object sender, MouseEventArgs e)
        {
            _textBox.Text = "Check Move : " + e.X + ", " + e.Y;
        }

        private void _clickCheck_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _textBox.Text = "CheckDoubleClick : " + e.Button + ", " + e.X + ", " + e.Y;
        }

        private void _clickCheck_MouseClick(object sender, MouseEventArgs e)
        {
            _textBox.Text = "CheckClick : " + e.Button + ", " + e.X + ", " + e.Y;
        }

        void ListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int itemIndex = _list.IndexFromPoint(e.X, e.Y);
                if (itemIndex < 0) return;
                string itemText = _list.Items[itemIndex].ToString();
                var dde = _list.DoDragDrop(itemText, DragDropEffects.All);
            }
        }

        int _click = 0;
        protected override void OnClick(EventArgs e)
        {
            _click++;
            _textBox.Text = "Click : " + _click.ToString();
            base.OnClick(e);
        }

        int _doubleClick = 0;
        protected override void OnDoubleClick(EventArgs e)
        {
            _doubleClick++;
            _textBox.Text = "DoubleClick : " + _doubleClick.ToString();
            base.OnDoubleClick(e);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            drgevent.Effect = DragDropEffects.Copy;
            base.OnDragOver(drgevent);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            var pos = PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y));
            var pos2 = PointToClient(Cursor.Position);
            _textBox.Text = "Drop : " + pos.X + ", " + pos.Y;
            base.OnDragDrop(drgevent);
        }
        
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            _textBox.Text = "Menu10";
        }

        private void _testEnterButton_Click(object sender, EventArgs e)
        {
            _testEnterButton.Text = "ENTER";
        }
    }
}
