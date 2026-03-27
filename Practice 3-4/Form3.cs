using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Practice_3_4
{
	public partial class Form3 : Form
    {

        DataTable dt;
        List<Employee> employee_list;

        const string filterField = "Фамилия";


        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            // Форма будет появляться в левом верхнем углу экрана
            this.Location = new Point(0, 0);

            // Передаем Form5 ширину Form3
            // Form5 отвечает за вывод аватаров сотрудников
            Form5 f5 = new Form5(this.Width);
            f5.Show();

            // Form3 и Form5 будут закрываться одновременно
            this.FormClosed += new FormClosedEventHandler(Form_Closed);
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            // Таблица данных
            dt = new DataTable();

            // Добавляем столбцы
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Отдел");
            dt.Columns.Add("Рабочее время");
            dt.Columns.Add("Оплата за час");

            // Считываем файл
            const string filename = "../../Files/employee.txt";

            if (File.Exists(filename))
            {
                StreamReader file = new StreamReader(filename);

                string[] values;
                string newline;

                // Считываем до конца файла
                while ((newline = file.ReadLine()) != null)
                {
                    DataRow dr = dt.NewRow();   // Строки таблицы

                    values = newline.Split(' ');    // Строку разбиваем на части (lastname, firstname, и т.д.),
                                                    // используя разделительный пробел Split(' ')

                    for (int i = 0; i < values.Length; ++i)
                        dr[i] = values[i];  // Присваиваем ячейкам строки

                    dt.Rows.Add(dr);    // Строку добавляем в таблицу
                }

                file.Close();

                // Таблицу данных dt используем как Data Sourse для dataGridView1
                dataGridView1.DataSource = dt;

                // Устанавливаем автоматическую ширину столбцов
                dataGridView1.AutoResizeColumns();
            }
            else MessageBox.Show("Нет файла с данными");
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                // Добавляем новый столбец
                dt.Columns.Add("Средняя зарплата");

                // и рассчитываем среднюю зарплату
                for(int i = 0; i < dt.Rows.Count; ++i)
                {
                    double working_time = Convert.ToDouble(dt.Rows[i]["Рабочее время"]);
                    double payment_per_hour = Convert.ToDouble(dt.Rows[i]["Оплата за час"]);
                    // 22 - среднее число рабочих дней в месяце
                    dt.Rows[i]["Средняя зарплата"] = working_time * payment_per_hour * 22;
                }

                dataGridView1.DataSource = dt;
            }
            else
            {
                // Если CheckBox1 не выбран - удаляем столбец
                dt.Columns.Remove("Средняя зарплата");
            }
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Фильтрация данных, фильтруем по полю filterField
            // задаём образец [{0}] LIKE '{1}%'

            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterField, textBox1.Text);
        }

        
        // Удаление сотрудника из списка и таблицы
        private void button1_Click(object sender, EventArgs e)
        {
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
                    values = newline.Split(' '); // Строку разбиваем на части (lastname, 
                                                 // firstname, и т.д.), используя 
                                                 // разделительный пробел Split(' ')

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


                const string pic_path = "../../Files/Images/";

                // Закрываем форму Form5 и освобождаем все
                // ресурсы для удаления аватаров сотрудников
                Form f5 = Application.OpenForms["Form5"];
                f5.Dispose();

                string fullname;
                for (int j = 0; j < employee_list.Count; j++)
                {
                    emp = employee_list[j];

                    // Сравниваем со значением текстового поля
                    if (emp.getLastName() == textBox1.Text)
                    {
                        // Удаляем аватар сотрудника
                        fullname = emp.getFullName();

                        if (File.Exists(pic_path + fullname + ".png"))
                        {
                            File.Delete(pic_path + fullname + ".png");
                        }

                        // Удаляем сотрудника из списка
                        employee_list.RemoveAt(j);
                    }
                }


                string data;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    // Присваиваем j-е значение 1-го столбца Фамилия
                    data = dt.Rows[j]["Фамилия"].ToString();

                    if (data.Equals(textBox1.Text))
                        dt.Rows[j].Delete();
                }

                textBox1.Text = String.Empty;


                // Перезаписываем старый файл
                StreamWriter new_file = new StreamWriter(filename);

                foreach (var x in employee_list)
                    new_file.WriteLine(x.Info());

                new_file.Close();

                // Обновляем таблицу
                dataGridView1.DataSource = dt;
                dataGridView1.Update();
                dataGridView1.Refresh();

                // Обновляем форму с аватарами сотрудников
                Form5 f5_new = new Form5(this.Width);
                f5_new.Show();
            }
            else MessageBox.Show("Нет файла с данными");
        }


        private void Form_Closed(object sender, EventArgs e)
        {
            Form f5 = Application.OpenForms["Form5"];
            if (f5 != null)
                f5.Close();
        }
    }
}