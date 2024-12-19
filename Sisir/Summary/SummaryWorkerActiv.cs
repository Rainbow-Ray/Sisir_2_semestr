using Sisir.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TemplateEngine.Docx;
using Sisir.Templates;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Sisir.Summary
{
    public partial class SummaryWorkerActiv : Summary
    {
        private string dateStart;
        private string dateEnd;
        private Label label1;
        private Button button1;
        private Label label4;
        DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        public SummaryWorkerActiv()
        {
            InitializeComponent();
        }

        private void SummaryWorkerActiv_Load(object sender, System.EventArgs e)
        {
            InitializeComponent();

            var ds = Worker.GetFio().Tables[0];
            WorkerComboBox.ValueMember = "id";
            WorkerComboBox.DisplayMember = "FIO";
            WorkerComboBox.DataSource = ds;



        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                var start = FormatDateForDB(StartDateTimePicker.Value);
                var end = FormatDateForDB(EndDateTimePicker.Value);
                var list = GetData(start, end);

                PrepareData(list);
            }

        }

        private void CreateButton_Click(object sender, System.EventArgs e)
        {
        }

        private void PrepareData(List<Dictionary<string, string>> list)
        {
            var dateS = new FieldContent("Date_sum_start", StartDateTimePicker.Value.Date.ToShortDateString());
            var dateE = new FieldContent("Date_sum_finish", EndDateTimePicker.Value.Date.ToShortDateString());
            var table = new TableContent("Team");


            foreach (var row in list)
            {
                table.AddRow(
                    new FieldContent("FIO", row["fio"].ToString()),
                    new FieldContent("Job_pos", row["job_name"].ToString()),
                    new FieldContent("Qual", row["qual_name"].ToString()),
                    new FieldContent("Project_member", row["Member"].ToString()),
                    new FieldContent("Project_lead", row["Lead"].ToString()))
                    ;
            }

            var dateF = new FieldContent("Date_form", DateTime.Now.Date.ToShortDateString());
            var worker = new Worker(int.Parse(WorkerComboBox.SelectedValue.ToString()));
            var pos = new JobPos(worker.Job);
            var posF = new FieldContent("Job_pos_form", pos.Name);

            var w = new FieldContent("FIO_form", WorkerComboBox.Text.ToString());

            var valuesToFill = new Content(dateS, dateE, table, dateF, w, posF);

            var filePath = "C:\\Users\\Вика\\Documents\\" + FileName() + ".docx";

            this.Fill(templates.WorkerActiv, valuesToFill, filePath);
        }

        private bool Validate()
        {
            var isValid = true;
            if (StartDateTimePicker.Value > EndDateTimePicker.Value)
            {
                MessageBox.Show("Конец периода формирования отчета должен быть раньше начала.");
                isValid = false;
            }
            if (WorkerComboBox.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Выберите сотрудника, сформировавшего отчет.");
                isValid = false;
            }
            //if (summaryNameTextBox.Text == "")
            //{
            //    MessageBox.Show("Введите название отчета.");
            //    isValid = false;

            //}
            return isValid;
        }


        private List<Dictionary<string, string>> GetData(string start, string end)
        {
            string command = $"Select " +
    $"\r\nworker.name || ' ' || worker.surname || ' ' || worker.patronym as fio, job_position.name as job_name, qual_level.name as qual_name, " +
    $"\r\nCOUNT(*) filter (where project_worker.is_lead = 'true') as \"Lead\", " +
    $"\r\nCOUNT(*) as \"Member\" " +
    $"\r\nfrom project " +
    $"\r\ninner join project_worker on project.id = project_worker.project_id  " +
    $"\r\ninner join worker on project_worker.worker_id = worker.id  " +
    $"\r\ninner join qual_level on worker.qual_level = qual_level.id " +
    $"\r\ninner join job_position on worker.job_position = job_position.id " +
    $"\r\nwhere " +
    $"\r\n((to_date(date_start_f, 'YYYY-MM-DD') >= '{start}' or  date_start_p >= '{start}') " +
    $"\r\nand ((to_date(date_finish_f, 'YYYY-MM-DD') <= '{end}' and to_date(date_finish_f, 'YYYY-MM-DD') >= '{end}') " +
    $"\r\nor  date_finish_p <= '{end}')) " +
    $"\r\nGROUP BY\r\n  worker.id, job_position.name, qual_level.name;\r\n";

            return databaseAdapter.ExecuteCommand(command);
        }


        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;

        private void InitializeComponent()
        {
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateTimePicker.Location = new System.Drawing.Point(34, 73);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(121, 22);
            this.StartDateTimePicker.TabIndex = 14;
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndDateTimePicker.Location = new System.Drawing.Point(183, 73);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(121, 22);
            this.EndDateTimePicker.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "—";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 33);
            this.button1.TabIndex = 24;
            this.button1.Text = "Сформировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Период";
            // 
            // SummaryWorkerActiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(373, 301);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.StartDateTimePicker);
            this.Name = "SummaryWorkerActiv";
            this.Text = "Загруженость сотрудников";
            this.Load += new System.EventHandler(this.SummaryWorkerActiv_Load);
            this.Controls.SetChildIndex(this.StartDateTimePicker, 0);
            this.Controls.SetChildIndex(this.EndDateTimePicker, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
