using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sisir.QualificationForm;
using Sisir.Sprav;

namespace Sisir
{
    public partial class JobPosotionForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }
        public BindingList<JobPos> items = new BindingList<JobPos>();
        public string click;

        public JobPosotionForm(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

        public JobPosotionForm()
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();
        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            AddFormOkay();
            AddEditDelButtonsEnable();

        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            AddFormCancel();
        }
        private void JobPosotionForm_Load(object sender, EventArgs e)
        {
            dataGridViewWorkers.Columns[0].DataPropertyName = "Name";
            dataGridViewWorkers.Columns[1].DataPropertyName = "Zp";

            dataGridViewWorkers.DataSource = items;

        }

        private void DataGridViewWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = dataGridViewWorkers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (a != null)
            {
                click = a.ToString();
            }
            this.Close();
        }

        private void OkButtonForm_Click_1(object sender, EventArgs e)
        {
            try
            {
                items.Add(new JobPos(textBox20.Text, int.Parse(textBox1.Text)));
                dataGridViewWorkers.Update();

                AddFormOkay();
                AddEditDelButtonsEnable();

            }
            catch (Exception)
            {
                MessageBox.Show("Зарплата должна быть указана в виде целого числа");
            }
        }

        private void CancelButoonForm_Click_1(object sender, EventArgs e)
        {
            AddFormCancel();
            AddEditDelButtonsEnable();
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobPosotionForm f = new JobPosotionForm();
            f.Show();

        }

        private void сотрудникиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WorkersForm f = new WorkersForm();
            f.Show();


        }

        public void ShowHelperSprav()
        {
            throw new NotImplementedException();
        }

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            throw new NotImplementedException();
        }

        private void JobPosotionForm_Activated(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += DataGridViewWorkers_CellDoubleClick;
            }

        }

        private void JobPosotionForm_ParentChanged(object sender, EventArgs e)
        {
        }

        private void dataGridViewWorkers_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += dataGridViewWorkers_CellContentClick;
            }

        }

        private void dataGridViewWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
