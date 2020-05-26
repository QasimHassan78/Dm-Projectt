using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA_FOR_DM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void button3_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = ofd.SafeFileName;
            }
        }
        RSAFileHelper rs = new RSAFileHelper();
        private void button1_Click(object sender, EventArgs e)
        {
            //    FileStream fs2 = new FileStream(textBox1.Text, FileMode.Open);

            //    StreamReader sr2 = new StreamReader(fs2);

            //    string data2 = sr2.ReadLine();
            //    RSainc rs = new RSainc();
            //    while (data2 != null)
            //    {
            //        string cypher = rs.incript(data2);

            //        StreamWriter sw = new StreamWriter("ciphertext.txt", true);
            //        sw.Write(cypher);
            //        sw.Close();
            //       // Console.WriteLine(cypher);
            //        data2 = sr2.ReadLine();
            //    }

            //    fs2.Close();
            //    sr2.Close();
            rs.EncryptFile(textBox1.Text);
            MessageBox.Show("File incripter");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.SafeFileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FileStream fs2 = new FileStream(textBox2.Text, FileMode.Open);

            //StreamReader sr2 = new StreamReader(fs2);

            //string data2 = sr2.ReadLine();
            //RSainc rs = new RSainc();
            //while (data2 != null)
            //{
            //    string cypher = rs.Decript(data2);
            //    StreamWriter sw = new StreamWriter("plaintext.txt",true);
            //    sw.Write(cypher, true);
            //    sw.Close();

            //    //  Console.WriteLine(cypher);
            //    data2 = sr2.ReadLine();
            //}

            //fs2.Close();
            //sr2.Close();
            rs.DecryptFile(textBox2.Text);
            MessageBox.Show("File Decript");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }
    }
}
