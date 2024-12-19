using Sisir.Entity;
using Sisir.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateEngine.Docx;

namespace Sisir.Summary
{
    public partial class SummaryWorkerSalary : Summary
    {
        private string dateStart;
        DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        public SummaryWorkerSalary()
        {
            InitializeComponent();

        }

        private void SummaryWorkerSalary_Load(object sender, EventArgs e)
        {
            var ds = Worker.GetFio().Tables[0];
            WorkerComboBox.ValueMember = "id";
            WorkerComboBox.DisplayMember = "FIO";
            WorkerComboBox.DataSource = ds;
        }
        private void CreateButton_Click(object sender, System.EventArgs e)
        {

        }
        private void PrepareData(List<Dictionary<string, string>> list)
        {
            var dateS = new FieldContent("date_summary", StartDateTimePicker.Value.Date.ToShortDateString());
            var tableMax = new TableContent("TeamM");
            var tableMin = new TableContent("TeamMn");
            var kol = list.Count;
            var count = (int)(list.Count) / 10;
            for (int i = 0; i <= count; i++)
            {
                tableMax.AddRow(
                    new FieldContent("FIO_max", list[kol - i-1]["fio"].ToString()),
                    new FieldContent("Job_pos_max", list[kol - i-1]["job"].ToString()),
                    new FieldContent("Qual_max", list[kol - i - 1]["qual"].ToString()),
                    new FieldContent("Project_count_max", list[kol - i - 1]["countpr"].ToString()),
                    new FieldContent("Salary_max", list[kol - i - 1]["sumsalary"].ToString()))
                    ;
                tableMin.AddRow(
                    new FieldContent("FIO_min", list[i]["fio"].ToString()),
                    new FieldContent("Job_pos_min", list[i]["job"].ToString()),
                    new FieldContent("Qual_min", list[i]["qual"].ToString()),
                    new FieldContent("Project_count_min", list[i]["countpr"].ToString()),
                    new FieldContent("Salary_min", list[i]["sumsalary"].ToString()))
                    ;
            }

            var dateF = new FieldContent("Date_form", DateTime.Now.Date.ToShortDateString());
            var worker = new Worker(int.Parse(WorkerComboBox.SelectedValue.ToString()));
            var pos = new JobPos(worker.Job);
            var posF = new FieldContent("Job_pos_form", pos.Name);

            var w = new FieldContent("FIO_form", WorkerComboBox.Text.ToString());

            var valuesToFill = new Content(dateS, tableMax, tableMin, dateF, w, posF);

            var filePath = "C:\\Users\\Вика\\Documents\\" + FileName() + ".docx";

            this.Fill(templates.WorkerSalary,valuesToFill, filePath);
        }

        private bool Validate()
        {
            var isValid = true;
            if (WorkerComboBox.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Выберите сотрудника, сформировавшего отчет.");
                isValid = false;
            }
            //if (summaryNameTextBox.Text == "")
            //{
            //    MessageBox.Show("Ввкдите название отчета.");
            //    isValid = false;

            //}
            return isValid;
        }
        private List<Dictionary<string, string>> GetData(string start)
        {
            string command = $"Select worker.name || ' ' || worker.surname || ' ' || worker.patronym as fio, " +
                $"\r\njob_position.name as job, qual_level.name as qual, " +
                $"\r\ncoeff * salary as sumSalary, " +
                $"\r\ncount(project_id) as countPr " +
                $"\r\nfrom project_worker " +
                $"\r\ninner join worker on worker.id = project_worker.worker_id " +
                $"\r\ninner join project on project.id = project_worker.project_id " +
                $"\r\ninner join job_position on worker.job_position = job_position.id " +
                $"\r\ninner join qual_level on worker.qual_level = qual_level.id " +
                $"\r\nwhere (is_fired = false and ((to_date(date_start_f, 'YYYY-MM-DD') >= '2024-01-01' or  date_start_p >= '2024-01-01'))) " +
                $"\r\n\r\ngroup by fio, job_position.name, qual_level.name, qual_level.coeff, salary, sumSalary " +
                $"\r\norder by countPr";

            return databaseAdapter.ExecuteCommand(command);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                var start = FormatDateForDB(StartDateTimePicker.Value);
                var list = GetData(start);

                PrepareData(list);
            }
        }
    }
}
