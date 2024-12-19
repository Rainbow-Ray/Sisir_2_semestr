using Npgsql;
using Sisir.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sisir
{
    public partial class JobPosotionForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }

        private NpgsqlDataSource dataSource;
        private DataSet jobDS = new DataSet();

        private List<Control> textFieldList = new List<Control>();

        public string SelectedJobPos;

        public JobPosotionForm(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

        public JobPosotionForm()
        {
            InitializeComponent();
        }

        private void PrepareAddForm()
        {
            zpTextBox.Text = string.Empty;
            jobNameTextBox.Text = string.Empty;
            idLabel.Text = string.Empty;
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
            PrepareAddForm();
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
            var jobDS = JobPos.GetDataSet();

            dataGridViewWorkers.DataSource = jobDS.Tables[0];


        }

        private void DataGridViewWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (parentForm != null)
            {
                var value = CellDoubleClicK(dataGridViewWorkers, e);
                if (value != "")
                {
                    SelectedJobPos = value.ToString();
                    this.Close();
                }
            }
        }

        private void OkButtonForm_Click_1(object sender, EventArgs e)
        {
            try
            {
                var isAdded = false;
                if (idLabel.Text != "")
                {
                    var id = int.Parse(idLabel.Text);

                    var job = new JobPos(id);
                    job.Name = jobNameTextBox.Text;
                    job.Zp = int.Parse(zpTextBox.Text);
                    isAdded = job.Update();
                }
                else
                {
                    var job = new JobPos(jobNameTextBox.Text, int.Parse(zpTextBox.Text));

                    var validRes = job.Validate();

                    if (validRes.isValid)
                    {
                        job.Insert();
                        isAdded = true;
                    }
                    else
                    {
                        MessageBox.Show(validRes.Message);
                        isAdded = false;
                    }
                }

                UpdateDataSource();

                if (isAdded)
                {
                    dataGridViewWorkers.Visible = true;
                    groupBoxAddForm.Visible = false;
                    AddFormOkay();
                    AddEditDelButtonsEnable();
                }
                else
                {
                    //MessageBox.Show("Произошла ошибка при добавлении должности в базу данных." +
                    //    "Попробуйте еще раз.");
                }

                UpdateDataSource();

            }
            catch (Exception)
            {
                MessageBox.Show("Зарплата должна быть указана в виде целого числа");
            }
        }

        public void UpdateDataSource()
        {
            jobDS = JobPos.UpdateDataSet();
            var q = jobDS.Tables[0];
            dataGridViewWorkers.DataSource = q;
            dataGridViewWorkers.Update();
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

        private void dataGridViewWorkers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var job = GetJob();

            if (job != null)
            {
                job.Delete();
            }
            else
            {
                MessageBox.Show("Выберите должность в таблице должностей " +
                    " (Кликните один раз по любой ячейке ряда интересующей вас должности).");
            }

            UpdateDataSource();

        }
        private JobPos GetJob()
        {
            if (dataGridViewWorkers.SelectedCells.Count > 0)
            {
                var row = dataGridViewWorkers.SelectedCells[0].RowIndex;
                var column = dataGridViewWorkers.Columns["id"].Index;
                var _id = dataGridViewWorkers.Rows[row].Cells[column].Value;
                int id;
                if (_id != null && int.TryParse(_id.ToString(), out id))
                {
                    id = int.Parse(_id.ToString());
                    var job = new JobPos(id);
                    return job;
                }
            }
            return null;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var job = GetJob();

            if (job != null)
            {
                ShowAddForm();
                FillData(job);
            }
            else
            {
                MessageBox.Show("Выберите сотрудника в таблице сотрудников " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас сотрудника).");
            }

        }
        private void FillData(JobPos job)
        {
            zpTextBox.Text = job.Zp.ToString();
            jobNameTextBox.Text = job.Name;
            idLabel.Text = job.Id.ToString();
        }

        private void dataGridViewWorkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow(dataGridViewWorkers, e);
        }
    }
}
