using Npgsql;
using Sisir.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Sisir.Sprav
{
    public partial class ProjectForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }
        private BindingList<Worker> itemList = new BindingList<Worker>();

        public Project project = null;
        private NpgsqlDataSource dataSource;
        private DataSet projectsDS = new DataSet();
        private DataSet workerDs = new DataSet();

        private List<Control> textFieldList = new List<Control>();


        public ProjectForm()
        {
            InitializeComponent();
        }

        public void AddEditDelButtonsDisable()
        {
            AddButton.Enabled = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            moreInfoButton.Enabled = false;
        }

        public void AddEditDelButtonsEnable()
        {
            AddButton.Enabled = true;
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
            moreInfoButton.Enabled = true;

        }

        public void AddFormCancel()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;
        }

        public void AddFormOkay()
        {
            var isAdded = false;
            if (idLabel.Text != "")
            {
                isAdded = UpdateProject();
            }
            else
            {
                isAdded = AddProject();
            }

            if (isAdded)
            {
                dataGridViewWorkers.Visible = true;
                groupBoxAddForm.Visible = false;

            }
            else
            {
                //MessageBox.Show("Произошла ошибка при добавлении проекта в базу данных." +
                //    "Попробуйте еще раз.");
            }
            UpdateDataSource();
        }

        private bool AddProject()
        {
            var name = nameTextBox.Text;
            var desc = descRichTextBox.Text;
            var crDate = createdDateTimePicker.Value;
            var sP = sPDateTimePicker1.Value;
            var fP = fPDateTimePicker3.Value;
            var sF = sFDateTimePicker2.Value.ToString();
            var fF = fFDateTimePicker.Value.ToString();

            if (startCheckBox.Checked)
            {
                sF = "";
            }
            if (finishCheckBox.Checked)
            {
                fF = "";
            }

            var worker = new Project(name, crDate,
            sP, fP, desc, sF, fF);

            var validRes = worker.Validate();

            int workerId = -1;

            bool workerAdded = false;
            if (validRes.isValid)
            {
                var validationResponse = worker.InsertWithReturn();
                if (validationResponse.isValid)
                {
                    workerId = int.Parse(validationResponse.Message);
                    workerAdded = true;
                }
                else
                {
                    MessageBox.Show(validationResponse.Message);
                }
            }
            else
            {
                MessageBox.Show(validRes.Message);
            }

            if (leadComboBox.SelectedIndex > 0)
            {
                var leadId = int.Parse(leadComboBox.SelectedValue.ToString());
                var leadPr = new WorkerProject(leadId, workerId, true);

                if (leadPr.Validate().isValid)
                {
                    leadPr.Insert();
                }
                else
                {
                    MessageBox.Show(leadPr.Validate().Message);
                }

            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var wrId = int.Parse(row.Cells["worker_id"].Value.ToString());
                var worSkill = new WorkerProject(wrId, workerId, false);
                var wrPrValid = worSkill.Validate();
                if (wrPrValid.isValid)
                {
                    worSkill.Insert();
                }
                else
                {
                    MessageBox.Show(wrPrValid.Message);
                }
            }

            return workerAdded;
        }

        private bool UpdateProject()
        {
            var id = int.Parse(idLabel.Text.Trim());

            var name = nameTextBox.Text;
            var desc = descRichTextBox.Text;
            var crDate = createdDateTimePicker.Value;
            var sP = sPDateTimePicker1.Value;
            var fP = fPDateTimePicker3.Value;
            string sF = sFDateTimePicker2.Value.ToString();
            string fF = fFDateTimePicker.Value.ToString();

            if (startCheckBox.Checked)
            {
                sF = "";
            }
            if (finishCheckBox.Checked)
            {
                fF = "";
            }


            var worker = new Project(id, name, crDate,
            sP, fP, desc, sF, fF);
            var validRes = worker.Validate();



            WorkerProject.ClearWorkers(id);

            int job;
            if (leadComboBox.SelectedIndex > 0)
            {
                job = int.Parse(leadComboBox.SelectedValue.ToString());
                var leadId = int.Parse(leadComboBox.SelectedValue.ToString());
                var leadPr = new WorkerProject(leadId, id, true);

                if (leadPr.Validate().isValid)
                {
                    leadPr.Insert();
                }
                else
                {
                    MessageBox.Show(leadPr.Validate().Message);
                }

            }



            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var wrId = int.Parse(row.Cells["worker_id"].Value.ToString());
                var worSkill = new WorkerProject(wrId, id, false);
                var wrPrValid = worSkill.Validate();
                if (wrPrValid.isValid)
                {
                    worSkill.Insert();
                }
                else
                {
                    //MessageBox.Show(wrPrValid.Message);
                }
            }
            return worker.Update();
        }

        public void ShowAddForm()
        {
            dataGridViewWorkers.Visible = false;
            groupBoxAddForm.Visible = true;
            PrepareAddForm();
        }

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            T f = new T();
            f.parentForm = this;
            f.ShowDialog();
        }

        private string FormatDate(string date)
        {
            if (date.ToString() != "")
            {

                var str = date.ToString();
                var dates = str.Split('-');
                var forattedDate = dates[2] + "." + dates[1] + "." + dates[0];

                return forattedDate;
            }
            return "";
        }

        private DataTable FormatTable(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                foreach (DataRow item in table.Rows)
                {
                    item["date_start_f"] = FormatDate(item["date_start_f"].ToString());
                    item["date_finish_f"] = FormatDate(item["date_finish_f"].ToString());

                }
            }
            return table;
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            projectsDS = Project.GetDataSet();
            var table = projectsDS.Tables[0];
            table = FormatTable(table);
            dataGridViewWorkers.DataSource = table;

            textFieldList.Add(nameTextBox);
            textFieldList.Add(descRichTextBox);
            textFieldList.Add(createdDateTimePicker);
            textFieldList.Add(sFDateTimePicker2);
            textFieldList.Add(sPDateTimePicker1);
            textFieldList.Add(fFDateTimePicker);
            textFieldList.Add(fPDateTimePicker3);
            textFieldList.Add(leadComboBox);
            textFieldList.Add(dataGridView1);
            textFieldList.Add(dataGridView1);
            textFieldList.Add(idLabel);
        }

        private void PrepareAddForm()
        {
            foreach (var control in textFieldList)
            {
                control.ResetText();
            }

            FillLeadComboBox();

            workerDs = WorkerProject.GetDataSet();
            var table = workerDs.Tables[0];
            table = FormatTable(table);
            dataGridView1.DataSource = table;
            dataGridView1.Update();

            startCheckBox.Checked = true;
            finishCheckBox.Checked = true;

        }

        private void FillLeadComboBox()
        {
            var ds = Worker.GetFio().Tables[0];

            leadComboBox.ValueMember = "id";
            leadComboBox.DisplayMember = "FIO";
            leadComboBox.DataSource = ds;

            var a = ds.NewRow();
            a[0] = 0;
            ds.Rows.InsertAt(a, 0);
            leadComboBox.SelectedIndex = 0;
        }



        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var worker = GetWorker();

            if (worker != null)
            {
                ShowAddForm();
                FillData(worker);
                AddEditDelButtonsDisable();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника в таблице сотрудников " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас сотрудника).");
            }

        }

        private void FillData(Project worker)
        {
            nameTextBox.Text = worker.Name;
            descRichTextBox.Text = worker.Description;
            createdDateTimePicker.Value = worker.DateCreated;
            sPDateTimePicker1.Value = worker.DateStartP;
            fPDateTimePicker3.Value = worker.DateFinishP;
            if (worker.DateStartF != "")
            {
                sFDateTimePicker2.Value = DateTime.Parse(worker.DateStartF);
                startCheckBox.Checked = false;

            }
            else
            {
                sFDateTimePicker2.Value = DateTime.Now;
                startCheckBox.Checked = true;
            }
            if (worker.DateFinishF != "")
            {
                fFDateTimePicker.Value = DateTime.Parse(worker.DateFinishF);
                finishCheckBox.Checked = false;

            }
            else
            {
                fFDateTimePicker.Value = DateTime.Now;
                finishCheckBox.Checked = true;
            }


            workerDs = WorkerProject.GetDataSet(worker.Id);
            var table = workerDs.Tables[0];
            dataGridView1.DataSource = table;
            dataGridView1.Update();
            var lead = WorkerProject.GetLead(worker.Id);
            leadComboBox.SelectedValue = lead;
            idLabel.Text = worker.Id.ToString();

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var worker = GetWorker();

            if (worker != null)
            {
                worker.Delete();
            }
            else
            {
                MessageBox.Show("Выберите сотрудника в таблице сотрудников " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас сотрудника).");
            }

            UpdateDataSource();

        }
        private Project GetWorker()
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
                    var worker = new Project(id);
                    return worker;
                }
            }
            return null;
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
            var f = OpenSprav<WorkersForm>(true);
            var s = f.SelectedWorker;
            WorkerProject workerProject;
            if (s != -1)
            {
                workerProject = new WorkerProject(f.SelectedWorker);
                WorkerTableUpdate(workerProject);
            }

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
            var workerId = f.SelectedWorker;
            FillLeadComboBox();
            if (Worker.IsIn(workerId))
            {
                leadComboBox.SelectedValue = workerId;
            }


        }


        public void UpdateDataSource()
        {
            projectsDS = Project.UpdateDataSet();
            var q = projectsDS.Tables[0];
            FormatTable(q);
            dataGridViewWorkers.DataSource = q;
            dataGridViewWorkers.Update();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (startCheckBox.Checked)
            {
                sFDateTimePicker2.Enabled = false;
            }
            else
            {
                sFDateTimePicker2.Enabled = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var row = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(row);
            }

        }

        private void CheckIfinTeam()
        {

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                var existingId = int.Parse(r.Cells["worker_id"].Value.ToString());
                var worker = new Worker(existingId);
                    if (leadComboBox.SelectedIndex > 0 && leadComboBox.SelectedValue.ToString() == existingId.ToString())
                    {
                    dataGridView1.Rows.Remove(r);

                }
               
            }

            dataGridView1.Update();
        }


        private void WorkerTableUpdate(WorkerProject workerPr)
        {
            var notDeleted = false;
            if (workerPr != null)
            {
                notDeleted = Worker.IsIn(workerPr.workerId);
            }

            bool isIn = false;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                var existingId = int.Parse(r.Cells["worker_id"].Value.ToString());
                var deleted = !Worker.IsIn(existingId);
                var worker = new Worker(existingId);
                if (deleted)
                {
                    dataGridView1.Rows.Remove(r);
                    continue;
                }
                if (notDeleted)
                {
                    if (existingId == workerPr.workerId)
                    {
                        MessageBox.Show($"Сотрудник {workerPr.workerSurname} {workerPr.workerName} уже " +
    $"является участником проекта");
                        dataGridView1.Rows.Remove(r);
                    }
                }


            }

            if (notDeleted)
            {
                if (leadComboBox.SelectedIndex > 0 && leadComboBox.SelectedValue.ToString() == workerPr.workerId.ToString())
                {
                    MessageBox.Show("Сотрудник является ответственным за проект");
                }
                else
                {
                    var row = workerDs.Tables[0].NewRow();
                    row["worker_id"] = workerPr.workerId;
                    row["worker_name"] = workerPr.workerName;
                    row["worker_surname"] = workerPr.workerSurname;
                    row["worker_patronym"] = workerPr.workerPatronym;
                    row["qual"] = workerPr.workerQual;
                    row["job"] = workerPr.workerJob;
                    workerDs.Tables[0].Rows.Add(row);
                }
            }
            dataGridView1.Update();
        }

        private void leadComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (leadComboBox.SelectedItem != null)
            {
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (leadComboBox.SelectedValue.ToString() == r.Cells["worker_id"].Value.ToString())
                    {
                        dataGridView1.Rows.Remove(r);
                        break;
                    }
                }

            }
        }

        private void finishCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (finishCheckBox.Checked)
            {
                fFDateTimePicker.Enabled = false;
            }
            else
            {
                fFDateTimePicker.Enabled = true;
            }
        }

        private void leadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfinTeam();
        }

        private void dataGridViewWorkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow(dataGridViewWorkers, e);
        }



        private void DisableFields()
        {
            foreach (var item in textFieldList)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    (item as TextBox).ReadOnly = true;
                }
                else
                {
                    item.Enabled = false;
                }
            }
            QualButtonEtc.Visible = false;
            OkButtonForm.Visible = false;
            CancelButoonForm.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            startCheckBox.Enabled = false;
            finishCheckBox.Enabled = false;


            infoCloseButton.Visible = true;

        }

        private void EnableFields()
        {
            foreach (var item in textFieldList)
            {
                if (item.GetType() == nameTextBox.GetType())
                {
                    (item as TextBox).ReadOnly = false;
                }
                else
                {
                    item.Enabled = true;

                }

            }

            QualButtonEtc.Visible = true;
            OkButtonForm.Visible = true;
            CancelButoonForm.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            startCheckBox.Enabled = true;
            finishCheckBox.Enabled = true;

            infoCloseButton.Visible = false;
        }

        private void infoCancelButton_Click(object sender, EventArgs e)
        {
            EnableFields();
            AddFormCancel();
            AddEditDelButtonsEnable();

        }

        private void moreInfoButton_Click(object sender, EventArgs e)
        {
            var worker = GetWorker();

            if (worker != null)
            {
                ShowAddForm();
                FillData(worker);
                DisableFields();
                AddEditDelButtonsDisable();
            }
            else
            {
                MessageBox.Show("Выберите проект в таблице проектов " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас проекта).");
            }

        }
    }
}
