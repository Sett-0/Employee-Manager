using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Practice_3_4
{
	public partial class Form2 : Form
    {

        string ln;
        string fn;
        string dep;
        double wt;
        double p_per_h;

        List<Employee> employee_list = new List<Employee>();


        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            string[] departments = { "Технадзора", "Техподдержки", 
                                     "Кадров", "Безопасности", "Бухгалтерии" };

            department.DataSource = departments;  // Источник данных
            department.SelectedIndex = 0;   // Значение по умолчанию

            // Действие при изменении comboBox1
            department.SelectedIndexChanged += department_SelectedIndexChanged;

            working_time.KeyPress += working_time_KeyPress;
            payment_per_hour.KeyPress += payment_per_hour_KeyPress;

            working_time.TextChanged += working_time_TextChanged;
            payment_per_hour.TextChanged += payment_per_hour_TextChanged;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "All files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if(openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openPicture.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }



        private void working_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ввод в working_time только цифр, ',' и Backspace
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch != ',' && ch != 8)
            {
                e.Handled = true;
            }
        }



        private void payment_per_hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ввод в payment_per_hour только цифр, ',' и Backspace
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != ',' && ch != 8)
            {
                e.Handled = true;
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {

                if (working_time.Text != String.Empty)
                {
                    // Если да, то берем из TextBox рабочее время и конвертируем в число
                    wt = Convert.ToDouble(working_time.Text);   // Convert.ToDouble(string) сам заменяет ',' на '.'
                }
                else
                {
                    // Устанавливаем курсор в поле рабочее время
                    working_time.Focus();
                    MessageBox.Show("Заполните поле Рабочее время");

                    // Прерываем выполнение программы
                    return;
                }

                // Проверка для поля оплата за час аналогична
                if (payment_per_hour.Text != String.Empty)
                {
                    p_per_h = Convert.ToDouble(payment_per_hour.Text);
                }
                else
                {
                    payment_per_hour.Focus();
                    MessageBox.Show("Заполните поле Оплата за час");
                    return;
                }

                double mounth_salary = wt * p_per_h * 22;   // 22 - среднее число рабочих дней в месяце
                this.mounth_salary.Text = mounth_salary.ToString();
            }
            else
            {
                mounth_salary.Text = "";
            }
        }

        

        private void working_time_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            mounth_salary.Text = "";
        }

        

        private void payment_per_hour_TextChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            mounth_salary.Text = "";
        }

        

        private void department_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Значение переменной dep (отдел) равна выбранному значению в comboBox
            dep = department.SelectedItem.ToString();
        }

        

        private bool checkField()
        {
                // Проверяем каждое поле по отдельности
                if (lastname.Text != String.Empty)
                {
                    ln = lastname.Text;
                }
                else
                {
                    lastname.Focus();
                    MessageBox.Show("Заполните поле Фамилия");
                    return false;
                }

                if (firstname.Text != String.Empty)
                {
                    fn = firstname.Text;
                }
                else
                {
                    firstname.Focus();
                    MessageBox.Show("Заполните поле Имя");
                    return false;
                }

                if (working_time.Text != String.Empty)
                {
                    wt = Convert.ToDouble(working_time.Text);
                }
                else
                {
                    working_time.Focus();
                    MessageBox.Show("Заполните поле Рабочее время");
                    return false;
                }

                if (payment_per_hour.Text != String.Empty)
                {
                    p_per_h = Convert.ToDouble(payment_per_hour.Text);
                }
                else
                {
                    payment_per_hour.Focus();
                    MessageBox.Show("Заполните поле Оплата за час");
                    return false;
                }

                return true;
        }
        
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkField())
            {

                // Создаём объект Employee
                Employee emp = new Employee(ln, fn, dep, wt, p_per_h);

                // Выводим информацию
                MessageBox.Show(ln + ' ' + fn + " Отдел " + dep + ' ' + wt + ' ' + p_per_h);


                const string path = "../../Files/";

                // Создаём каталог, если его нет
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                    MessageBox.Show("Created dir " + path);
                }

                // true - в файл можно дописывать
                StreamWriter streamwriter = new StreamWriter(path + "employee.txt", true);
                streamwriter.WriteLine(emp.Info());
                streamwriter.Close();


                // Создаём подкаталог для хранения фотографий сотрудников, если его нет
                const string path_images = "../../Files/Images/";

                DirectoryInfo dirImagesInfo = new DirectoryInfo(path_images);
                if (!dirImagesInfo.Exists)
                {
                    dirImagesInfo.Create();
                    MessageBox.Show("Created dir " + path_images);
                }

                // Запись содержимого PictureBox1
                string fullname = lastname.Text + " " + firstname.Text;
                pictureBox1.Image.Save(path_images + fullname + ".png");
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            // Позволяет сформировать отсортированный список студентов и записать его в файл.
            // Фотография не записывается, т.к.запись осуществляется списком.

            const string path = "../../Files/employee.txt";

            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);

                string[] values;
                string newline;

                Employee emp;

                employee_list = new List<Employee>();

                // Считываем до конца файла

                while ((newline = file.ReadLine()) != null)
                {
                    values = newline.Split(' '); // Строку разбиваем на части (lastname, firstname и т.д.),
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

                employee_list.Sort();

                string message = "";
                foreach (var x in employee_list)
                    message += x.Info() + '\n';

                MessageBox.Show(message);


                StreamWriter new_file = new StreamWriter(path);

                foreach (var x in employee_list)
                    new_file.WriteLine(x.Info());

                new_file.Close();
            }
            else MessageBox.Show("Нет файла с данными");
        }
    }
}
