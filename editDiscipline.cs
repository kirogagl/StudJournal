using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudJournal
{
    public partial class editDiscipline : Form
    {
        List<Discipline> disciplines;
        TextBox textBox1;
        int id = -1;
        char changeType = 'x';

        Form1 frm;
        public editDiscipline(List<Discipline> disciplines, Form1 f)
        {
            InitializeComponent();
            frm = f;
            this.disciplines = disciplines;
            comboBoxFill();
            this.Width = 427;
            this.Height = 129;
            label2.Hide();
            numericUpDown1.Hide();
        }

        private void comboBoxFill()
        {
            for (int i = 0; i < disciplines.Count(); i++)
            {
                string txt = "";
                switch (disciplines[i].DayWeek)
                {
                    case DayOfWeek.Monday:
                        txt = "Понедельник";
                        break;
                    case DayOfWeek.Tuesday:
                        txt = "Вторник";
                        break;
                    case DayOfWeek.Wednesday:
                        txt = "Среда";
                        break;
                    case DayOfWeek.Thursday:
                        txt = "Четверг";
                        break;
                    case DayOfWeek.Friday:
                        txt = "Пятница";
                        break;
                }
                comboBox1.Items.Add(i.ToString() + " " + disciplines[i].ToString() + " " + txt + " " + disciplines[i].Lesson.ToString() + " пара");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ch = false;
            for (int i = 0; i < disciplines.Count(); i++)
            {
                if ((comboBox1.Text[0].ToString() + comboBox1.Text[1].ToString()).Trim(' ') == i.ToString())
                {
                    id = i;
                    ch = true;
                    break;
                }
            }
            if (ch)
            {
                label1.Text = "Выберите что нужно изменить:";
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox1.Items.Add("1. День недели и номер пары");
                comboBox1.Items.Add("2. Название предмета");
                comboBox1.Items.Add("3. Данные о преподавателе");
            }
            else
            {
                MessageBox.Show("Такой элемент не существует");
                this.Close();
            }
            button1.Click -= button1_Click;
            button1.Click += new EventHandler(button2_Click);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            changeType = comboBox1.Items[comboBox1.SelectedIndex].ToString()[0];
            switch (changeType)
            {
                case '1':
                    label1.Text = "Выберите день недели: ";
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                    comboBox1.Items.Add("1. Понедельник");
                    comboBox1.Items.Add("2. Вторник");
                    comboBox1.Items.Add("3. Среда");
                    comboBox1.Items.Add("4. Четверг");
                    comboBox1.Items.Add("5. Пятница");
                    this.Height = 165;
                    label2.Show();
                    numericUpDown1.Show();
                    break;
                case '2':
                    label1.Text = "Введите новое название предмета: ";
                    textBox1 = new TextBox();
                    textBox1.Location = comboBox1.Location;
                    textBox1.Size = comboBox1.Size;
                    this.Controls.Add(textBox1);
                    comboBox1.Dispose();
                    break;
                case '3':
                    label1.Text = "Введите новое ИО преподавателя: ";
                    textBox1 = new TextBox();
                    textBox1.Location = comboBox1.Location;
                    textBox1.Size = comboBox1.Size;
                    this.Controls.Add(textBox1);
                    comboBox1.Dispose();
                    break;
            }
            button1.Click -= button2_Click;
            button1.Click += new EventHandler(button3_Click);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (changeType)
            {
                case '1':
                    bool check = false;
                    int no = (int)numericUpDown1.Value;
                    int dw = comboBox1.Text[0];
                    DayOfWeek day = new DayOfWeek();
                    switch (dw)
                    {
                        case '1':
                            day = DayOfWeek.Monday;
                            break;
                        case '2':
                            day = DayOfWeek.Tuesday;
                            break;
                        case '3':
                            day = DayOfWeek.Wednesday;
                            break;
                        case '4':
                            day = DayOfWeek.Thursday;
                            break;
                        case '5':
                            day = DayOfWeek.Friday;
                            break;
                    }
                    for (int i = 0; i < disciplines.Count(); i++)
                    {
                        if ((disciplines[i].DayWeek == day) && (disciplines[i].Lesson == no))
                        {
                            check = true;
                        }
                    }
                    if (!check)
                    {
                        disciplines[id].DayWeek = day;
                        disciplines[id].Lesson = no;
                        frm.setDiscip(disciplines);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: В это время уже есть пара");
                        this.Close();
                    }
                    break;
                case '2':
                    disciplines[id].Name = textBox1.Text;
                    frm.setDiscip(disciplines);
                    this.Close();
                    break;
                case '3':
                    disciplines[id].Teacher = textBox1.Text;
                    frm.setDiscip(disciplines);
                    this.Close();
                    break;
            }
        }
    }
}