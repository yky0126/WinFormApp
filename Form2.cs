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


namespace PlayerStatus
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            
            InitializeComponent();

            // TextBoxへ初期値割り当て
            textBox2.ReadOnly = true;
            textBox2.Text = "Dragon Fantasy Online";         
                                   
        }

        public string ID { get; set; }
        public string Password { get; set; }
        
        private void Form2_Load(object sender, EventArgs e)
        {

            textBox1.MaxLength = 10;
            DialogResult = DialogResult.OK;
            ID = textBox1.Text;

            textBox3.MaxLength = 10;
            Password = textBox3.Text;

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string userpass = textBox3.Text;

            if (username == "yeon" && userpass == "0312")
            {
                MessageBox.Show("Character情報、読み込み成功！");

                Form3 frm3 = new Form3();

                frm3.ShowDialog();
                
            }
            else
            {
               
                MessageBox.Show("ID もしくは パスワードが間違ってます");                 

            }
        }
    }
}
