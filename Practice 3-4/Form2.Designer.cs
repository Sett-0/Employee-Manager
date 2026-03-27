namespace Practice_3_4
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lastname = new System.Windows.Forms.TextBox();
            this.firstname = new System.Windows.Forms.TextBox();
            this.working_time = new System.Windows.Forms.TextBox();
            this.payment_per_hour = new System.Windows.Forms.TextBox();
            this.mounth_salary = new System.Windows.Forms.TextBox();
            this.department = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФАМИЛИЯ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "ИМЯ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отдел";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Рабочее время";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Оплата за час";
            // 
            // lastname
            // 
            this.lastname.Location = new System.Drawing.Point(26, 51);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(207, 20);
            this.lastname.TabIndex = 5;
            // 
            // firstname
            // 
            this.firstname.Location = new System.Drawing.Point(26, 101);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(207, 20);
            this.firstname.TabIndex = 6;
            // 
            // working_time
            // 
            this.working_time.Location = new System.Drawing.Point(26, 202);
            this.working_time.Name = "working_time";
            this.working_time.Size = new System.Drawing.Size(207, 20);
            this.working_time.TabIndex = 7;
            this.working_time.TextChanged += new System.EventHandler(this.working_time_TextChanged);
            this.working_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.working_time_KeyPress);
            // 
            // payment_per_hour
            // 
            this.payment_per_hour.Location = new System.Drawing.Point(26, 253);
            this.payment_per_hour.Name = "payment_per_hour";
            this.payment_per_hour.Size = new System.Drawing.Size(207, 20);
            this.payment_per_hour.TabIndex = 8;
            this.payment_per_hour.TextChanged += new System.EventHandler(this.payment_per_hour_TextChanged);
            this.payment_per_hour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.payment_per_hour_KeyPress);
            // 
            // mounth_salary
            // 
            this.mounth_salary.Location = new System.Drawing.Point(26, 316);
            this.mounth_salary.Name = "mounth_salary";
            this.mounth_salary.Size = new System.Drawing.Size(207, 20);
            this.mounth_salary.TabIndex = 9;
            // 
            // department
            // 
            this.department.FormattingEnabled = true;
            this.department.Location = new System.Drawing.Point(26, 150);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(207, 21);
            this.department.TabIndex = 10;
            this.department.SelectedIndexChanged += new System.EventHandler(this.department_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(26, 289);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Вычислить среднюю зарплату";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Practice_3_4.Properties.Resources.avatar;
            this.pictureBox1.Location = new System.Drawing.Point(282, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 248);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(282, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "Загрузить фото";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(26, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(471, 35);
            this.button2.TabIndex = 14;
            this.button2.Text = "СОХРАНИТЬ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(26, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(471, 34);
            this.button3.TabIndex = 15;
            this.button3.Text = "Сортировать список сотрудников";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 455);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.department);
            this.Controls.Add(this.mounth_salary);
            this.Controls.Add(this.payment_per_hour);
            this.Controls.Add(this.working_time);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lastname;
        private System.Windows.Forms.TextBox firstname;
        private System.Windows.Forms.TextBox mounth_salary;
        private System.Windows.Forms.ComboBox department;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox working_time;
        private System.Windows.Forms.TextBox payment_per_hour;
        private System.Windows.Forms.Button button3;
    }
}