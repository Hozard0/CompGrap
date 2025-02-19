using System.Text;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        const int MaxN = 10; // ����������� ���������� ����������� �������
        int n = 3; // ������� ����������� �������
        TextBox[,] MatrText = null; // ������� ��������� ���� TextBox
        double[,] Matr1 = new double[MaxN, MaxN]; // ������� 1 ����� � ��������� ������
        double[,] Matr2 = new double[MaxN, MaxN]; // ������� 2 ����� � ��������� ������
        double[,] Matr3 = new double[MaxN, MaxN]; // ������� �����������
        bool f1; // ������, ������� ��������� � ����� ������ � ������� Matr1
        bool f2; // ������, ������� ��������� � ����� ������ � ������� Matr2
        int dx = 40, dy = 20; // ������ � ������ ������ � MatrText[,]
        Form2
        form2 = null; // ��������� (������) ������ ����� Form2
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // �. ������������� ��������� ���������� � ���������� ����������
            textBox1.Text = "";
            f1 = f2 = false; // ������� ��� �� ���������
            label2.Text = "false";
            label3.Text = "false";
            // ��. ��������� ������ � ��������� MatrText
            int i, j;
            // 1. ��������� ������ ��� ����� Form2
            form2 = new Form2();
            // 2. ��������� ������ ��� ����� �������
            MatrText = new TextBox[MaxN, MaxN];
            // 3. ��������� ������ ��� ������ ������ ������� � �� ���������
            for (i = 0; i < MaxN; i++)
                for (j = 0; j < MaxN; j++)
                {
                    // 3.1. �������� ������
                    MatrText[i, j] = new TextBox();
                    // 3.2. �������� ��� ������
                    MatrText[i, j].Text = "0";
                    // 3.3. ���������� ������� ������ � ����� Form2
                    MatrText[i, j].Location = new System.Drawing.Point(10 + i *
                    dx, 10 + j * dy);
                    // 3.4. ���������� ������ ������
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    // 3.5. ���� ��� �������� ������
                    MatrText[i, j].Visible = false;
                    // 3.6. �������� MatrText[i,j] � ����� form2
                    form2.Controls.Add(MatrText[i, j]);
                }
        }
        private void Clear_MatrText()
        {
            // ��������� ����� MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. ������ ����������� �������
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);
            // 2. ��������� ������ MatrText
            Clear_MatrText();
            // 3. ��������� ������� ����� ������� MatrText
            // � ��������� � �������� n � ����� Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ������� ������ �������
                    MatrText[i, j].Visible = true;
                }
            // 4. ������������� �������� �����
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;
            // 5. ������������� ������� � �������� ������ �� ����� Form2
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;
            // 6. ����� ����� Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 7. ������� ����� �� ����� Form2 � ������� Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                // 8. ������ � ������� Matr1 �������
                f1 = true;
                label2.Text = "true";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. ������ ����������� �������
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);
            // 2. �������� ������ MatrText Clear_MatrText();
            // 3. ��������� ������� ����� ������� MatrText
            // � ��������� � �������� n � ����� Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ������� ������ �������
                    MatrText[i, j].Visible = true;
                }
            // 4. ������������� �������� �����
            form2.Width = 10 + n * dx + 20;
            form2.Height = 10 + n * dy + form2.button1.Height + 50;
            // 5. ������������� ������� � �������� ������ �� ����� Form2
            form2.button1.Left = 10;
            form2.button1.Top = 10 + n * dy + 10;
            form2.button1.Width = form2.Width - 30;
            // 6. ����� ����� Form2
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // 7. ������� ����� �� ����� Form2 � ������� Matr2
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        Matr2[i, j] = Double.Parse(MatrText[i, j].Text);
                // 8. ������� Matr2 ������������
                f2 = true;
                label3.Text = "true";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int nn;
            nn = Int16.Parse(textBox1.Text);
            if (nn != n)
            {
                f1 = f2 = false;
                label2.Text = "false";
                label3.Text = "false";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������� �� ������ � ����� ��������
            if (!((f1 == true) && (f2 == true))) return;
            // 2. ���������� ������������ ������. ��������� � Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = 0;
                    for (int k = 0; k < n; k++)
                        Matr3[j, i] = Matr3[j, i] + Matr1[k, i] * Matr2[j, k];
                }
            // 3. �������� ������ � MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ��������� ����� � ������
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. ����� �����
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fw = null;
            string msg;
            byte[] msgByte = null; // �������� ������
            // 1. ������� ���� ��� ������
            fw = new FileStream("Res_Matr.txt", FileMode.Create);
            // 2. ������ ������� ���������� � ����

            // 2.1. ������� �������� ����� ��������� ������� Matr3
            msg = n.ToString() + "\r\n";
            // ������� ������ msg � �������� ������ msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // ������ ������� msgByte � ����
            fw.Write(msgByte, 0, msgByte.Length);
            // 2.2. ������ �������� ���� �������
            msg = "";
            for (int i = 0; i < n; i++)
            {
                // ��������� ������ msg �� ��������� �������
                for (int j = 0; j < n; j++)
                    msg = msg + Matr3[i, j].ToString() + " ";
                msg = msg + "\r\n";
                // �������� ������� ������
            }
            // 3. ������� ������ msg � �������� ������ msgByte
            msgByte = Encoding.Default.GetBytes(msg);
            // 4. ������ ����� ������� � ����
            fw.Write(msgByte, 0, msgByte.Length);
            // 5. ������� ����
            if (fw != null) fw.Close();
        }

        // ��������
        private void button5_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������� �� ������ � ����� ��������
            if (!((f1 == true) && (f2 == true))) return;
            // 2. ���������� ��������� ������. ��������� � Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = Matr1[j, i] + Matr2[j, i];
                }
            // 3. �������� ������ � MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ��������� ����� � ������
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. ����� �����
            form2.ShowDialog();
        }
        // ���������
        private void button6_Click(object sender, EventArgs e)
        {
            // 1. ��������, ������� �� ������ � ����� ��������
            if (!((f1 == true) && (f2 == true))) return;
            // 2. ���������� ��������� ������. ��������� � Matr3
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Matr3[j, i] = Matr1[j, i] - Matr2[j, i];
                }
            // 3. �������� ������ � MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. ������� ���������
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. ��������� ����� � ������
                    MatrText[i, j].Text = Matr3[i, j].ToString();
                }
            // 4. ����� �����
            form2.ShowDialog();
        }
    }

}

