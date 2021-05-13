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
    public partial class delElement : Form
    {
        private List<Discipline> disciplines;
        private Form1 frm;
        public delElement(List<Discipline> disciplines, Form1 frm)
        {
            InitializeComponent();
            this.frm = frm;
            this.disciplines = disciplines;
            comboBoxFill();
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
        private void nextB_Click(object sender, EventArgs e)
        {
            int id = -1;
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
                disciplines.RemoveAt(id);
                frm.setDiscip(disciplines);
                this.Close();
            }
            else
            {
                MessageBox.Show("Такой элемент не существует");
                this.Close();
            }
        }
    }
}
