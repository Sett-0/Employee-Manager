using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice_3_4
{
	public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel { Dock = DockStyle.Fill };

            Label label1 = new Label();
            Label label2 = new Label();
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            Button button1 = new Button();

            // В таблице 1 столбец и 2 строки
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.RowCount = 4;

            // Ширина строк в пропорциях 80:20
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));

            // Ширина столбцов 50:50
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));

            // Добавляем элементы управления (0,0 – первый столбец, первая строка,
            //                                1,0 – второй столбец, первая строка и т.д.)

            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 3);
            tableLayoutPanel1.Controls.Add(button1, 1, 3);

            tableLayoutPanel1.TabIndex = 0;

            // pictureBox1
            pictureBox1.Dock = DockStyle.Fill;   // pictureBox1 занимает всё пространство ячейки
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabIndex = 0;
            pictureBox1.Image = Image.FromFile("../../Images/avatar.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // label1
            label1.Dock = DockStyle.Fill;
            label1.Name = "label1";
            label1.Text = "v0.5.0";

            // label2
            label2.Dock = DockStyle.Bottom;
            label2.Name = "label2";
            label2.Text = "Made by Pavel";

            // button1
            button1.Dock = DockStyle.Fill;
            button1.Name = "button1";
            button1.TabIndex = 1;
            button1.Text = "Закрыть";
            button1.Click += new EventHandler(closeProgram);

            Controls.Add(tableLayoutPanel1);
        }


        private void closeProgram(object sender, EventArgs e)
        {
            Close();
        }
    }
}
