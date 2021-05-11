using System.Windows.Forms;

namespace StudJournal
{
    public partial class editBells : Form
    {
        string[] bells;
        Form1 frm;
        public editBells(string[] bs, Form1 frm)
        {
            InitializeComponent();
            bells = bs;
            this.frm = frm;
            drawDataGrid();
        }

        void drawDataGrid()
        {
            dataGridView1.Rows.Add();
            for (int i = 0; i < 4; i++)
            {
                dataGridView1[i, 0].Value = bells[i];
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for(int i = 0; i < 4; i++)
            {
                bells[i] = dataGridView1[i, 0].Value.ToString();
            }
            frm.setBell(bells);
        }
    }
}