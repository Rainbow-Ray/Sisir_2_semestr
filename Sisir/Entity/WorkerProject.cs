using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sisir.Entity
{
    public class WorkerProject : IEntity
    {
        public int Id { get; set; }
        public int workerId { get; set; }
        public int projectId { get; set; }
        public bool isLead { get; set; } = false;

        public string workerName { get; set; }
        public string workerSurname { get; set; }
        public string workerPatronym { get; set; }
        public string workerQual { get; set; }
        public string workerJob { get; set; }

        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();

        private static string table = "project_worker";


        public WorkerProject() { }
        public WorkerProject(int workerId)
        {
            this.workerId = workerId;
            var worker = new Worker(workerId);
            this.workerName = worker.Name;
            this.workerSurname = worker.Surname;
            this.workerPatronym = worker.Patronym;
            var job = new JobPos(worker.Job);
            this.workerJob = job.Name;
            var qual = new QualLevel(worker.QualLevel);
            this.workerQual = qual.Name;

        }
        public WorkerProject(int workerId, bool islead)
        {
            this.workerId = workerId;
            this.isLead = isLead;
        }

        public WorkerProject(int workerId, int projectId, bool islead)
        {
            this.workerId = workerId;
            this.projectId = projectId;
            this.isLead = islead;
        }

        public static List<Dictionary<string, string>> Select(int id, int wId, int pId)
        {
            var command = "SELECT id, worker_id, project_id, is_lead " +
                 $" FROM public.{table} WHERE id={id}, worker_id={wId}, project_id={pId};";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }
        public static List<Dictionary<string, string>> Select(int wId, int pId)
        {
            var command = "SELECT id, worker_id, project_id, is_lead " +
                 $" FROM public.{table} WHERE worker_id={wId}, project_id={pId};";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }
        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT id, worker_id, project_id, is_lead " +
                 $" FROM public.{table} WHERE id={id};";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }

        public static bool IsIn(int id)
        {
            var data = Select(id);
            if (data.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsIn(int id, int wId, int sId)
        {
            var data = Select(id, wId, sId);
            if (data.Count > 0)
            {
                return true;
            }
            return false;
        }
        public static bool IsIn(int wId, int sId)
        {
            var data = Select(wId, sId);
            if (data.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static DataSet GetDataSet(int workerId)
        {
            return databaseAdapter.GetDataSet(
                $"Select project_worker.id, worker_id, project_id, is_lead, " +
                $"worker.name as worker_name, worker.surname as worker_surname, " +
                $"worker.patronym as worker_patronym, " +
                $"qual_level.name as qual, job_position.name as job " +
                $" FROM {table} left join worker on worker_id = worker.id " +
                $"left join qual_level on worker.qual_level=qual_level.id " +
                $"left join job_position on worker.job_position = job_position.id where " +
                $"project_id={workerId} and is_lead=false");
        }

        public static DataSet GetDataSet()
        {
            return databaseAdapter.GetDataSet(
                $"Select project_worker.id, worker_id, project_id, is_lead, " +
                $"worker.name as worker_name, worker.surname as worker_surname, " +
                $"worker.patronym as worker_patronym, " +
                $"qual_level.name as qual, job_position.name as job " +
                $" FROM {table} left join worker on worker_id = worker.id " +
                $"left join qual_level on worker.qual_level=qual_level.id " +
                $"left join job_position on worker.job_position = job_position.id where " +
                $"worker_id= -1");
        }

        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();



            return response;

        }

        private bool isValid(string field, Regex regex)
        {
            return regex.IsMatch(field);
        }


        public void Insert()
        {
            try
            {
                var command = $"INSERT INTO " +
                    $"public.project_worker(worker_id, project_id, is_lead) " +
                    $"VALUES ({workerId}, {projectId}, {isLead});";

                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Произошла ошибка при добавлении сотрудника в проект.");
            }
        }

        public bool Update()
        {
            var command = $"UPDATE public.project_worker " +
                $"SET worker_id ={workerId}, project_id ={projectId}, is_lead ={isLead} " +
                $"WHERE id ={Id}; ";

            try
            {
                databaseAdapter.ExecuteCommandNoReturn(command);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Delete()
        {
            try
            {
                var command = $"DELETE FROM public.{table} WHERE id={Id};";
                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Данный проект нельзя удалить.");
            }
        }

        internal static void ClearWorkers(int projectId)
        {
            try
            {
                var command = $"DELETE FROM public.{table} WHERE project_id={projectId};";
                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Произошла ошибка при обновлении навыков сотрудника.");
            }

        }

        internal static int GetLead(int id)
        {
            var command = $"select worker_id from {table} where project_id={id.ToString()} and is_lead=true";
            var dict = databaseAdapter.ExecuteCommand(command);
            if (dict.Count > 0)
            {
                var ida = dict[0]["worker_id"];
                return int.Parse(ida);
            }
            return -1;

        }
    }

}
