using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sisir.Sprav;

namespace Sisir
{
    public partial class QualificationForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }
        public BindingList<QualLevel> items = new BindingList<QualLevel>();
        public string click;

        public QualificationForm(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

        public QualificationForm()
        {
            InitializeComponent();
        }

        public void AddEditDelButtonsDisable()
        {
            AddButton.Enabled = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
        }

        public void AddEditDelButtonsEnable()
        {
            AddButton.Enabled = true;
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        public void AddFormCancel()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;
            AddEditDelButtonsEnable();

        }

        public void AddFormOkay()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;


        }

        public void ShowAddForm()
        {
            dataGridViewWorkers.Visible = false;
            groupBoxAddForm.Visible = true;
        }

        private void Qualification_Load(object sender, EventArgs e)
        {
            if(parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += DataGridViewWorkers_CellDoubleClick;
            }
            dataGridViewWorkers.Columns[0].DataPropertyName = "Name";
            dataGridViewWorkers.Columns[1].DataPropertyName = "Coef";

            dataGridViewWorkers.DataSource = items;
            
        }

        private void DataGridViewWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = dataGridViewWorkers.Rows[e.RowIndex].Cells[0].Value;
            if (a != null)
            {
                click = a.ToString();
            }
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            items.Add(new QualLevel(textBox20.Text, (double)numericUpDown1.Value));
            dataGridViewWorkers.Update();

            AddFormOkay();
            AddEditDelButtonsEnable();

        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            AddFormCancel();
        }

        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkersForm f = new WorkersForm();
            f.Show();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void сотрудникиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WorkersForm f = new WorkersForm();
            f.Show();

        }

        private void должностиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            JobPosotionForm f = new JobPosotionForm();
            f.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            throw new NotImplementedException();
        }

        private void QualificationForm_ParentChanged(object sender, EventArgs e)
        {
            this.menuStrip.Visible = false;
        }

        private void dataGridViewWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QualificationForm_Activated(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += dataGridViewWorkers_CellDoubleClick;
            }

        }
    }
}
