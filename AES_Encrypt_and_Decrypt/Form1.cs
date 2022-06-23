namespace AES_Encrypt_and_Decrypt
{
    public partial class Form1 : Form
    {
        #region 变量
        /// <summary>
        /// 一次处理的明文字节数
        /// </summary>
        public static int encryptSize = 10000000;
        /// <summary>
        /// 一次处理的密文字节数
        /// </summary>
        public static int decryptSize = 10000016;
        #endregion

        public delegate void RefreshFileProgress(int max, int value);

        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("本程序加密文件后会覆盖原文件，请备份原文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            #region 验证
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空", "提示", MessageBoxButtons.OK);
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
                writer.WriteLine("原文件：" + textBox1.Text + " 密码：" + textBox2.Text);
                writer.Close();
                MessageBox.Show("加密完成！", "提示", MessageBoxButtons.OK);
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
                writer.WriteLine("原文件：" + textBox1.Text + " 密码：" + textBox2.Text);
                writer.Close();
                MessageBox.Show("加密完成！", "提示", MessageBoxButtons.OK);
                label3.Visible = false;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            #region 验证
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空", "提示", MessageBoxButtons.OK);
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
                MessageBox.Show("解密完成！", "提示", MessageBoxButtons.OK);
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
                MessageBox.Show("解密完成！", "提示", MessageBoxButtons.OK);
                label3.Visible = false;
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("输入密码，点击加密/解密按钮，选择要加密的文件，程序会自动加密/解密，不检验密码是否正确\n若“文件路径”文本框中有文件路径，可直接输入密码进行加密/解密\n加密的文件和密码会保存至:D:\\passwoed.password\n使用AES加密算法，请妥善保存密码", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("可以反复加密/解密文件\n其实解密算法也相当于加密算法", "彩蛋");
        }
    }
}