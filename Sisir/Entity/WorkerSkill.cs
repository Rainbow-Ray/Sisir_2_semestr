using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sisir.Entity
{
    public class WorkerSkill : IEntity
    {
        public int Id { get; set; }
        public int workerId { get; set; }
        public int skillId { get; set; }
        public string skillLevel { get; set; }
        public string skillName { get; set; }

        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();

        private static string table = "worker_skill";



        public WorkerSkill() { }
        public WorkerSkill(int skillId, string skillLevel)
        {
            this.skillId = skillId;
            this.skillLevel = skillLevel;
            var skill = new Skill(skillId);
            this.skillName = skill.Name;
        }

        public WorkerSkill(int workerId, int skillId, string skillLevel)
        {
            this.skillId = skillId;
            this.skillLevel = skillLevel;
            this.workerId = workerId;
        }

        public static List<Dictionary<string, string>> Select(int id, int wId, int sId)
        {
            var command = "SELECT id, worker_id, skill_id, level " +
                 $" FROM public.{table} WHERE id={id}, worker_id={wId}, skill_id={sId};";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }
        public static List<Dictionary<string, string>> Select(int wId, int sId)
        {
            var command = "SELECT id, worker_id, skill_id, level " +
                 $" FROM public.{table} WHERE worker_id={wId}, skill_id={sId};";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }
        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT id, worker_id, skill_id, level " +
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
            return databaseAdapter.GetDataSet($"Select worker_skill.id, worker_id, skill_id, level," +
                $"skill.name as skill_name FROM {table} left join skill on skill_id = skill.id where " +
                $"worker_id={workerId}");
        }

        public static DataSet GetDataSet()
        {
            return databaseAdapter.GetDataSet($"Select worker_skill.id, worker_id, skill_id, level," +
                $"skill.name as skill_name FROM {table} left join skill on skill_id = skill.id where worker_id = -1");
        }

        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();

            int lvlParsed = 0;
            var isInt = int.TryParse(skillLevel, out lvlParsed);

            if (string.IsNullOrEmpty(skillLevel) || !isValid(skillLevel, regRules.numberOnly)
                || !isInt || lvlParsed > 10 || lvlParsed < 0)
            {
                response.isValid = false;
                response.Message += "Поле Уровень навыка уровня должно быть целочисленным числом " +
                    "в интервале 0-10.\n";
            }
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
                var command = $"INSERT INTO public.{table} " +
                    $"(worker_id, skill_id, level)" +
                    $" VALUES ({workerId}, {skillId}, {skillLevel});";

                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Произошла ошибка при добавлении навыка сотрудника.");
            }
        }

        public bool Update()
        {
            var command = $"UPDATE public.{table}" +
                $" SET worker_id={workerId}, skill_id={skillId}, skill_level={skillLevel} " +
                $" WHERE id={Id};";

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
                MessageBox.Show("Данный уровень назначен сотруднику. Вы не можете удалить его.");
            }
        }

        internal static void ClearWorkerSkills(int workerId)
        {
            try
            {
                var command = $"DELETE FROM public.{table} WHERE worker_id={workerId};";
                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Произошла ошибка при обновлении навыков сотрудника.");
            }

        }
    }
}
