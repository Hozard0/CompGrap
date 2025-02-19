namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += button1_Click;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(); // создаем объект типа Form2
            if (f.ShowDialog() == DialogResult.OK) // вызов диалогового окна формы Form2
            {
                label1.Text = "Result = OK!";
            }
            else
            {
                label1.Text = "Result = Cancel!";
            }
            
        }
    }
}
