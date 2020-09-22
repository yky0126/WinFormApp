using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PlayerStatus
{
    public partial class Form3 : Form
    {
        public Form3()
        { 

            InitializeComponent();

            textBox1.ReadOnly = true;
            textBox1.Text = "YEON";
            textBox2.ReadOnly = true;
            textBox2.Text = "50";
            textBox3.ReadOnly = true;
            textBox3.Text = "10000 GOLD";
            textBox4.ReadOnly = true;



            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Class : Knight");
            sb.AppendLine("HP : 5000");
            sb.AppendLine("MP : 1500");
            sb.AppendLine("Str : 80");
            sb.AppendLine("Int : 10");
            sb.AppendLine("Dex : 50");
            sb.AppendLine("Luk : 10");

            textBox4.Text = sb.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        public void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();

            XmlNode root = xml.CreateElement("プレイヤー情報");

            XmlNode game = xml.CreateElement("DragonFantasyOnline");
            game.InnerText = "DFO";
            root.AppendChild(game);

            XmlNode player = xml.CreateElement("プレイヤー");

            XmlAttribute id = xml.CreateAttribute("ID");
            id.Value = "yeon";
            XmlAttribute password = xml.CreateAttribute("パスワード");
            password.Value = "0312";

            player.Attributes.Append(id);
            player.Attributes.Append(password);

            XmlNode characterstat = xml.CreateElement("ステータス");
            characterstat.InnerText = textBox4.Text;

            string skl = checkedListBox1.SelectedItem as string;
            string sps = checkedListBox2.SelectedItem as string;

            XmlNode skills = xml.CreateElement("スキル");           

            foreach (object obj in checkedListBox1.CheckedItems)
            {
                checkedListBox1.Items.Add(obj);
            }

            skills.InnerText = skl;

            XmlNode spstats = xml.CreateElement("スペシャルステータス");

            foreach (object obj in checkedListBox2.CheckedItems)
            {
                checkedListBox2.Items.Add(obj);
            }

            spstats.InnerText = sps;

            foreach (object obj in checkedListBox2.CheckedItems)
            {
                spstats.InnerText = checkedListBox2.CheckedItems.ToString();
            }

            /*foreach (var input_special in checkedListBox2.CheckedItems)
            {
                string result_special = "";
                result_special += string.Format("{0}", input_special);
                while (spstats.InnerText == null)
                {
                    spstats.InnerText = result_special;
                }
            }*/



            player.AppendChild(characterstat);
            player.AppendChild(skills);
            player.AppendChild(spstats);

            root.AppendChild(player);
            xml.AppendChild(root);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\PlayerStat.xml";
            
            xml.Save(path);

            MessageBox.Show("Xmlファイルの生成に成功しました！");
        }

       
    }
}
