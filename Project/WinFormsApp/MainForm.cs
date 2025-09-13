namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void _button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button", "caption");
        }
    }
}
