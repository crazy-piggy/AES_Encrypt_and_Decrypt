namespace AES_Encrypt_and_Decrypt
{
    public partial class Form1 : Form
    {
        #region ����
        /// <summary>
        /// һ�δ���������ֽ���
        /// </summary>
        public static int encryptSize = 10000000;
        /// <summary>
        /// һ�δ���������ֽ���
        /// </summary>
        public static int decryptSize = 10000016;
        #endregion

        public delegate void RefreshFileProgress(int max, int value);

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("����������ļ���Ḳ��ԭ�ļ����뱸��ԭ�ļ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            #region ��֤
            if (textBox2.Text == "")
            {
                MessageBox.Show("���벻��Ϊ��", "��ʾ", MessageBoxButtons.OK);
                return;
            }
            #endregion
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(delegate (object obj)
                {
                    DateTime t1 = DateTime.Now;
                    FileEncrypt.EncryptFile(textBox1.Text, textBox2.Text);
                    DateTime t2 = DateTime.Now;
                    string t = t2.Subtract(t1).TotalSeconds.ToString("0.00");
                }));
                thread.Start();
                string password = @"D:\password.password";
                FileStream fileStream = new FileStream(password, FileMode.Append);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.WriteLine("ԭ�ļ���" + textBox1.Text + " ���룺" + textBox2.Text);
                writer.Close();
                MessageBox.Show("������ɣ�", "��ʾ", MessageBoxButtons.OK);
                label3.Visible = false;
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK & string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Text = openFileDialog1.FileName;
                Thread thread = new Thread(new ParameterizedThreadStart(delegate (object obj)
                {
                    DateTime t1 = DateTime.Now;
                    FileEncrypt.EncryptFile(openFileDialog1.FileName, textBox2.Text);
                    DateTime t2 = DateTime.Now;
                    string t = t2.Subtract(t1).TotalSeconds.ToString("0.00");
                }));
                thread.Start();
                string password = @"D:\password.password";
                FileStream fileStream = new FileStream(password, FileMode.Append);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.WriteLine("ԭ�ļ���" + textBox1.Text + " ���룺" + textBox2.Text);
                writer.Close();
                MessageBox.Show("������ɣ�", "��ʾ", MessageBoxButtons.OK);
                label3.Visible = false;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            #region ��֤
            if (textBox2.Text == "")
            {
                MessageBox.Show("���벻��Ϊ��", "��ʾ", MessageBoxButtons.OK);
                return;
            }
            #endregion
            if (string.IsNullOrEmpty(textBox1.Text) == false)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(delegate (object obj)
                {
                    DateTime t1 = DateTime.Now;
                    FileEncrypt.DecryptFile(textBox1.Text, textBox2.Text);
                    DateTime t2 = DateTime.Now;
                    string t = t2.Subtract(t1).TotalSeconds.ToString("0.00");
                }));
                thread.Start();
                MessageBox.Show("������ɣ�", "��ʾ", MessageBoxButtons.OK);
                label3.Visible = false;
                return;
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK & string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Text = openFileDialog1.FileName;
                Thread thread = new Thread(new ParameterizedThreadStart(delegate (object obj)
                {
                    DateTime t1 = DateTime.Now;
                    FileEncrypt.DecryptFile(openFileDialog1.FileName, textBox2.Text);
                    DateTime t2 = DateTime.Now;
                    string t = t2.Subtract(t1).TotalSeconds.ToString("0.00");
                }));
                thread.Start();
                MessageBox.Show("������ɣ�", "��ʾ", MessageBoxButtons.OK);
                label3.Visible = false;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�������룬�������/���ܰ�ť��ѡ��Ҫ���ܵ��ļ���������Զ�����/���ܣ������������Ƿ���ȷ\n�����ļ�·�����ı��������ļ�·������ֱ������������м���/����\n���ܵ��ļ�������ᱣ����:D:\\passwoed.password\nʹ��AES�����㷨�������Ʊ�������", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���Է�������/�����ļ�\n��ʵ�����㷨Ҳ�൱�ڼ����㷨", "�ʵ�");
        }
    }
}