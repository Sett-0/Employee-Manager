using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Practice_3_4
{
	public partial class Form5 : Form
	{
		List<Employee> employee_list;
		FlowLayoutPanel FLPanel;

		public Form5(int form3Width)
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.Manual;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;

			// Ширина и высота экрана пользователя
			int scWidth = Screen.PrimaryScreen.Bounds.Width;
			int scHeight = Screen.PrimaryScreen.Bounds.Height;

			// Форма будет появляться рядом с Form3
			this.Location = new Point(form3Width, 0);

			this.Width = scWidth - form3Width;

			// Высота Form5 ограничена высотой экрана пользователя
			this.MinimumSize = new Size(this.Width, 270);
			this.MaximumSize = new Size(this.Width, scHeight - 40);

			// Form3 и Form5 будут закрываться одновременно
			this.FormClosed += new FormClosedEventHandler(Form_Closed);
		}

		private void Form5_Load(object sender, EventArgs e)
		{
			FLPanel = new FlowLayoutPanel { Dock = DockStyle.Fill };

			FLPanel.Location = new Point(10, 10);

			FLPanel.FlowDirection = FlowDirection.LeftToRight;
			FLPanel.AutoScroll = true;

			this.Controls.Add(FLPanel);


			const string filename = "../../Files/employee.txt";

			if (File.Exists(filename))
			{
				StreamReader file = new StreamReader(filename);

				string[] values;
				string newline;

				string ln;
				string fn;
				string dep;
				double wt;
				double p_per_h;

				Employee emp;

				employee_list = new List<Employee>();

				// Считываем до конца файла

				while ((newline = file.ReadLine()) != null)
				{
					values = newline.Split(' '); // Строку разбиваем на части (lastname, firstname, и т.д.),
												 // используя разделительный пробел Split(' ')

					// Присваиваем ячейкам строки
					ln = values[0];
					fn = values[1];
					dep = values[2];
					wt = Convert.ToDouble(values[3]);
					p_per_h = Convert.ToDouble(values[4]);

					emp = new Employee(ln, fn, dep, wt, p_per_h);

					employee_list.Add(emp);
				}

				file.Close();


				// Создаем нужное число PictureBox
				const string path = "../../Files/Images/";

				for (int i = 0; i < employee_list.Count; ++i)
				{
					PictureBox pic = new PictureBox();

					// Размер PictureBox из Form2 - 215 x 248, 248 / 215 = 1.15
					int width = this.Width / 3 - 17;
					int height = (int)(width * 1.15);

					pic.Size = new Size(width, height);

					// Полный путь к картинке
					string full_path = path + employee_list[i].getFullName() + ".png";

					// Используем поток для корректного
					// удаления аватаров в дальнейшем
					FileStream fs = new FileStream(full_path, FileMode.Open);
					pic.Image = Image.FromStream(fs);
					fs.Close();

					pic.SizeMode = PictureBoxSizeMode.StretchImage;
					pic.BorderStyle = BorderStyle.Fixed3D;

					// Привязка названия pic к номеру в списке сотрудников,
					// понадобится при выводе информации о сотруднике по аватару
					pic.Name = Convert.ToString(i);

					FLPanel.Controls.Add(pic);

					// Увеличение высоты формы, если влезают не все
					// картинки, при максимуме высоты - прокрутка
					if (pic.Bottom > this.Height && this.Height < MaximumSize.Height)
						this.Height += height;

					// Для вывода информации о сотруднике по изображению
					pic.MouseEnter += new EventHandler(pic_MouseEnter);
					pic.MouseLeave += new EventHandler(pic_MouseLeave);
				}
			}
			else MessageBox.Show("Нет файла с данными");
		}

		
		// Меню-подсказка для вывода информации о сотруднике
		ToolTip tip = new ToolTip();

		private void pic_MouseEnter(object sender, EventArgs e)
		{
			PictureBox pic = (PictureBox)sender;
			int i = Convert.ToInt32(pic.Name);
			tip.SetToolTip(pic, employee_list[i].Info());
			tip.Active = true;
		}


		private void pic_MouseLeave(object sender, EventArgs e)
		{
			tip.Active = false;
		}

		private void Form_Closed(object sender, EventArgs e)
		{
			Form f3 = Application.OpenForms["Form3"];
			if(f3 != null)
				f3.Close();
		}
	}
}
