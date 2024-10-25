using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisir.Sprav
{
    public partial class ProjectForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }
        private BindingList<Worker> itemList = new BindingList<Worker>();

        public ProjectForm()
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

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            T f = new T();
            f.parentForm = this;
            f.ShowDialog();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].DataPropertyName = "Surname";
            dataGridView1.Columns[1].DataPropertyName = "Name";
            dataGridView1.Columns[2].DataPropertyName = "SecName";
            dataGridView1.Columns[4].DataPropertyName = "Job";
            dataGridView1.DataSource = itemList;
            dataGridView1.Update();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();

        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            AddFormOkay();
            AddEditDelButtonsEnable();

        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            AddFormCancel();
            AddEditDelButtonsEnable();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkersForm f = new WorkersForm(this);
            f.ShowDialog();
            var worker = f.worker;
            itemList.Add(worker);
            dataGridView1.Update();

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += dataGridViewWorkers_CellDoubleClick;
            }


        }

        private void QualButtonEtc_Click(object sender, EventArgs e)
        {
            var f = OpenSprav<WorkersForm>(true);
            var item = new Worker("", "", "", "");
            itemList.Add(item);
            dataGridView1.Update();

        }
    }
}
