using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Practice_3_4
{
	public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(480, 400);

            pictureBox1.Dock = DockStyle.Fill;

            // Перемещение кнопок при масштабировании
            button1.Anchor = AnchorStyles.None;
            button2.Anchor = AnchorStyles.None;
            label1.Anchor = AnchorStyles.None;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists("../../Files/employee.txt"))
            {
                Form3 f3 = new Form3();
                f3.Show();
            }
            else
            {
                MessageBox.Show("Нет файла с данными");
                return;
            }
        }


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 aboutProgramm = new Form4();
            aboutProgramm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
