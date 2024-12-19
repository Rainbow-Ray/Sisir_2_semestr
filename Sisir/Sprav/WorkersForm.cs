using Npgsql;
using Sisir.Entity;
using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sisir
{
    public partial class WorkersForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }
        public Worker worker = null;
        private NpgsqlDataSource dataSource;
        private DataSet workersDS = new DataSet();
        private DataSet skillDs = new DataSet();


        private List<Control> textFieldList = new List<Control>();
        public int SelectedWorker = -1;
        public WorkerProject ProjectWorker;

        public WorkersForm()
        {
            InitializeComponent();
        }

        public WorkersForm(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            workersDS = Worker.GetDataSet();

            dataGridViewWorkers.DataSource = workersDS.Tables[0];
            Adjust_Columns();


            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += dataGridViewWorkers_CellDoubleClick;
            }


            textFieldList.Add(nameTextBox);
            textFieldList.Add(surnameTextBox);
            textFieldList.Add(patronymTextBox);
            textFieldList.Add(dateBirthDateTimePicker);
            textFieldList.Add(passSerieTextBox);
            textFieldList.Add(passNumtextBox);
            textFieldList.Add(passWhoTextBox);
            textFieldList.Add(passDateDateTimePicker);
            textFieldList.Add(addPasstextBox);
            textFieldList.Add(addFacttextBox);
            textFieldList.Add(jobPoscomboBox);
            textFieldList.Add(qualLevelcomboBox);
            textFieldList.Add(emailtextBox);
            textFieldList.Add(tgtextBox);
            textFieldList.Add(phonetextBox);
            textFieldList.Add(dataGridView1);
            textFieldList.Add(idLabel);


        }

        private void dataGridViewWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (parentForm != null)
            {
                var value = CellDoubleClicK(dataGridViewWorkers, e);
                if (value != "")
                {
                    SelectedWorker = int.Parse(value.ToString());
                    this.Close();
                }
            }
        }

        private void Adjust_Columns()
        {
            dataGridViewWorkers.Columns["name"].DisplayIndex = 0;
            dataGridViewWorkers.Columns["surname"].DisplayIndex = 1;
            dataGridViewWorkers.Columns["patronym"].DisplayIndex = 2;
            dataGridViewWorkers.Columns["job_position"].DisplayIndex = 3;
            dataGridViewWorkers.Columns["qual_level"].DisplayIndex = 4;
            dataGridViewWorkers.Columns["birth_date"].DisplayIndex = 5;
            dataGridViewWorkers.Columns["pass_serie"].DisplayIndex = 6;
            dataGridViewWorkers.Columns["pass_num"].DisplayIndex = 7;
            dataGridViewWorkers.Columns["pass_date"].DisplayIndex = 8;
            dataGridViewWorkers.Columns["pass_who"].DisplayIndex = 8;
            dataGridViewWorkers.Columns["adress_pass"].DisplayIndex = 9;
            dataGridViewWorkers.Columns["adress_fact"].DisplayIndex = 10;
            dataGridViewWorkers.Columns["id"].Visible = false;
        }

        private void PrepareAddForm()
        {
            foreach (var control in textFieldList)
            {
                control.ResetText();
            }

            FillQualComboBox();
            FillJobComboBox();

            skillDs = WorkerSkill.GetDataSet();
            dataGridView1.DataSource = skillDs.Tables[0];
            dataGridView1.Update();

        }

        private void FillJobComboBox()
        {
            var ds = JobPos.GetDataSet().Tables[0];

            jobPoscomboBox.ValueMember = "id";
            jobPoscomboBox.DisplayMember = "name";
            jobPoscomboBox.DataSource = ds;

            var a = ds.NewRow();
            a[0] = 0;
            ds.Rows.InsertAt(a, 0);
            jobPoscomboBox.SelectedIndex = 0;

        }

        private void FillQualComboBox()
        {
            var ds = QualLevel.GetDataSet().Tables[0];

            qualLevelcomboBox.ValueMember = "id";
            qualLevelcomboBox.DisplayMember = "name";
            qualLevelcomboBox.DataSource = ds;

            var a = ds.NewRow();
            a[0] = 0;
            ds.Rows.InsertAt(a, 0);
            qualLevelcomboBox.SelectedIndex = 0;

        }


        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            AddFormCancel();
            AddEditDelButtonsEnable();
        }

        public void AddEditDelButtonsEnable()
        {
            AddButton.Enabled = true;
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
            moreInfoButton.Enabled = true;

        }

        public void AddEditDelButtonsDisable()
        {
            AddButton.Enabled = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
            moreInfoButton.Enabled = false;
        }

        public void ShowAddForm()
        {
            dataGridViewWorkers.Visible = false;
            groupBoxAddForm.Visible = true;
            PrepareAddForm();
        }

        public void AddFormOkay()
        {
            var isAdded = false;
            if (idLabel.Text != "")
            {
                isAdded = UpdateWorker();
            }
            else
            {
                isAdded = AddWorker();
            }

            if (isAdded)
            {
                dataGridViewWorkers.Visible = true;
                groupBoxAddForm.Visible = false;

            }
            else
            {
                //MessageBox.Show("Произошла ошибка при добавлении сотрудника в базу данных." +
                //    "Попробуйте еще раз.");
            }
            UpdateDataSource();
        }

        private bool UpdateWorker()
        {
            var id = int.Parse(idLabel.Text.Trim());

            var name = nameTextBox.Text;
            var surname = surnameTextBox.Text;
            var patronym = patronymTextBox.Text;
            var birthDate = dateBirthDateTimePicker.Value;
            var passSerie = passSerieTextBox.Text;
            var passNum = passNumtextBox.Text;
            var passWho = passWhoTextBox.Text;
            var passDate = passDateDateTimePicker.Value;
            var adressPass = addPasstextBox.Text;
            var adressFact = addFacttextBox.Text;
            var job = int.Parse(jobPoscomboBox.SelectedValue.ToString());
            var qual = int.Parse(qualLevelcomboBox.SelectedValue.ToString());
            if (jobPoscomboBox.SelectedIndex == 0 || qualLevelcomboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите должность и уровень квалификации сотрудника.");

                return false;
            }


            var email = emailtextBox.Text;
            var tg = tgtextBox.Text;
            var phone = phonetextBox.Text;


            var worker = new Worker(id, surname, name, passNum, passDate,
            patronym, birthDate, email, tg, phone,
            passSerie, adressPass,
            adressFact, passWho, job, qual);
            var validRes = worker.Validate();

            var isUpd = false;

            if (validRes.isValid)
            {
                isUpd = worker.Update();

                if (isUpd)
                {
                    WorkerSkill.ClearWorkerSkills(id);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        var skId = int.Parse(row.Cells["skill_id"].Value.ToString());
                        var skillLevel = row.Cells["level"].Value.ToString();
                        var worSkill = new WorkerSkill(id, skId, skillLevel);
                        var wrSkValid = worSkill.Validate();
                        if (wrSkValid.isValid)
                        {
                            worSkill.Insert();
                        }
                        else
                        {
                            MessageBox.Show(wrSkValid.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(validRes.Message);
            }

            return isUpd;
        }

        public void UpdateDataSource()
        {
            workersDS = Worker.UpdateDataSet();
            var q = workersDS.Tables[0];
            dataGridViewWorkers.DataSource = q;
            dataGridViewWorkers.Update();
        }

        private bool AddWorker()
        {
            var name = nameTextBox.Text;
            var surname = surnameTextBox.Text;
            var patronym = patronymTextBox.Text;
            var dateBirth = dateBirthDateTimePicker.Value;
            var passSer = passSerieTextBox.Text;
            var passNum = passNumtextBox.Text;
            var passWho = passWhoTextBox.Text;
            var passWhen = passDateDateTimePicker.Value;
            var adressPass = addPasstextBox.Text;
            var adressFact = addFacttextBox.Text;
            var email = emailtextBox.Text;
            var tg = tgtextBox.Text;
            var phone = phonetextBox.Text;
            var job = int.Parse(jobPoscomboBox.SelectedValue.ToString());
            var qual = int.Parse(qualLevelcomboBox.SelectedValue.ToString());
            if (jobPoscomboBox.SelectedIndex == 0 || qualLevelcomboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Выберите должность и уровень квалификации сотрудника.");

                return false;
            }




            var worker = new Worker(surname, name, passNum, passWhen, patronym, dateBirth, email, tg,
                phone, passSer, adressPass, adressFact, passWho, job, qual);

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


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var id = int.Parse(row.Cells["skill_id"].Value.ToString());
                var skillLevel = row.Cells["level"].Value.ToString();
                var worSkill = new WorkerSkill(workerId, id, skillLevel);
                var wrSkValid = worSkill.Validate();
                if (wrSkValid.isValid)
                {
                    worSkill.Insert();
                }
                else
                {
                    MessageBox.Show(wrSkValid.Message);
                    workerAdded = false;
                }
            }

            return workerAdded;

        }

        public void AddFormCancel()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;
        }

        private void JobTitleButtonEtc_Click(object sender, EventArgs e)
        {

            var f = OpenSprav<JobPosotionForm>(true);
            var jobId = f.SelectedJobPos;
            FillJobComboBox();
            if (jobId != null)
            {
                if (JobPos.IsIn(int.Parse(jobId)))
                {
                    jobPoscomboBox.SelectedValue = jobId;

                }
            }
            else
            {
                jobPoscomboBox.SelectedIndex = 0;

            }
        }
        //J,hf,jnfnm[]
        private void QualButtonEtc_Click(object sender, EventArgs e)
        {
            var f = OpenSprav<QualificationForm>(true);

            var prevSelected = qualLevelcomboBox.SelectedValue;
            var qualId = f.SelectedLevel;
            FillQualComboBox();
            if (qualId != null)
            {
                if (QualLevel.IsIn(int.Parse(qualId)))
                {
                    qualLevelcomboBox.SelectedValue = qualId;
                }
            }
            else if (QualLevel.IsIn(int.Parse(prevSelected.ToString())))
            {
                qualLevelcomboBox.SelectedValue = prevSelected;
            }

            else
            {
                qualLevelcomboBox.SelectedIndex = 0;
            }


        }


        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            T f = new T();
            f.parentForm = this;
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = OpenSprav<SkillForm>(true);
            var workerSkill = f.WorkerSkill;
            SkillTableUpdate(workerSkill);
        }

        private void SkillTableUpdate(WorkerSkill workerSkill)
        {
            var notDeleted = false;
            if (workerSkill != null)
            {
                notDeleted = Skill.IsIn(workerSkill.skillId);
            }

            bool isIn = false;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                var existingId = int.Parse(r.Cells["skill_id"].Value.ToString());
                var deleted = !Skill.IsIn(existingId);
                var skill = new Skill(existingId);
                if (deleted)
                {
                    dataGridView1.Rows.Remove(r);
                    continue;
                }
                if (skill != null && r.Cells["skill_name"].Value.ToString() != skill.Name)
                {
                    r.Cells["skill_name"].Value = skill.Name;
                }
                if (notDeleted)
                {
                    if (existingId == workerSkill.skillId)
                    {
                        isIn = true;
                        r.Cells["skill_name"].Value = workerSkill.skillName;
                        r.Cells["level"].Value = workerSkill.skillLevel;
                    }
                }
            }

            if (!isIn && notDeleted)
            {
                var row = skillDs.Tables[0].NewRow();
                row["skill_id"] = workerSkill.skillId;
                row["skill_name"] = workerSkill.skillName;
                row["level"] = workerSkill.skillLevel;
                skillDs.Tables[0].Rows.Add(row);
            }
            dataGridView1.Update();
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

            }
            else
            {
                MessageBox.Show("Выберите сотрудника в таблице сотрудников " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас сотрудника).");
            }
        }

        private Worker GetWorker()
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
                    var worker = new Worker(id);
                    return worker;
                }
            }
            return null;
        }
        private void FillData(Worker worker)
        {
            nameTextBox.Text = worker.Name;
            surnameTextBox.Text = worker.Surname;
            patronymTextBox.Text = worker.Patronym;
            dateBirthDateTimePicker.Value = worker.BirthDate;
            passSerieTextBox.Text = worker.PassSerie;
            passNumtextBox.Text = worker.PassNum;
            passWhoTextBox.Text = worker.PassWho;
            passDateDateTimePicker.Value = worker.PassDate;
            addFacttextBox.Text = worker.AdressFact;
            addPasstextBox.Text = worker.AdressPass;
            emailtextBox.Text = worker.Email;
            tgtextBox.Text = worker.Tg;
            phonetextBox.Text = worker.Phone;
            idLabel.Text = worker.Id.ToString();
            qualLevelcomboBox.SelectedValue = worker.QualLevel;
            jobPoscomboBox.SelectedValue = worker.Job;

            skillDs = WorkerSkill.GetDataSet(worker.Id);
            dataGridView1.DataSource = skillDs.Tables[0];
            dataGridView1.Update();

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

        private void WorkersForm_Activated(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
            }

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            AddFormOkay();
            AddEditDelButtonsEnable();

        }

        private void dataGridViewWorkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow(dataGridViewWorkers, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var row = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                MessageBox.Show("Выберите сотрудника в таблице сотрудников " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас сотрудника).");
            }
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
            JobTitleButtonEtc.Visible = false;
            QualButtonEtc.Visible = false;
            OkButtonForm.Visible = false;
            CancelButoonForm.Visible = false;
            button1.Visible = false;
            button2.Visible = false;

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

            JobTitleButtonEtc.Visible = true;
            QualButtonEtc.Visible = true;
            OkButtonForm.Visible = true;
            CancelButoonForm.Visible = true;
            button1.Visible = true;
            button2.Visible = true;

            infoCloseButton.Visible = false;
        }

        private void infoCloseButton_Click(object sender, EventArgs e)
        {
            EnableFields();
            AddFormCancel();
            AddEditDelButtonsEnable();

        }
    }



}
