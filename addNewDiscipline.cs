using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudJournal
{
    public partial class addNewDiscipline : Form
    {
        private List<Discipline> disciplines;
        private Form1 frm;
        public addNewDiscipline(List<Discipline> ds, Form1 f)
        {
            InitializeComponent();
            this.disciplines = ds;
            frm = f;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DayOfWeek d = new DayOfWeek();
            bool check = false;
            switch (comboBox1.Text)
            {
                case "Понедельник":
                    d = DayOfWeek.Monday;
                    break;
                case "Вторник":
                    d = DayOfWeek.Tuesday;
                    break;
                case "Среда":
                    d = DayOfWeek.Wednesday;
                    break;
                case "Четверг":
                    d = DayOfWeek.Thursday;
                    break;
                case "Пятница":
                    d = DayOfWeek.Friday;
                    break;
            }
            Discipline disc = new Discipline(textBox1.Text, textBox2.Text, d, (int)numericUpDown1.Value);
            if (!(disciplines.Count == 0))
            {
                for(int i =0; i < disciplines.Count(); i++)
                {
                    if ((disciplines[i].DayWeek == disc.DayWeek) && (disciplines[i].Lesson == disc.Lesson))
                    {
                        check = true;
                    }
                }
                if (!check)
                {
                    disciplines.Add(disc);
                    frm.setDiscip(disciplines);
                    this.Close();
                }
                else MessageBox.Show("Ошибка: в это время уже есть пара");
            }
            else
            {
                disciplines.Add(disc);
                frm.setDiscip(disciplines);
                this.Close();
            }
        }
    }
}
