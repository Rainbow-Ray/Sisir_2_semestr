using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sisir.Entity
{
    public class QualLevel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Coeff { get; set; }


        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();

        private static string table = "qual_level";

        public QualLevel() { }
        public QualLevel(int id)
        {
            Id = id;
            var selectedLevel = Select(id);

            if (selectedLevel.Count > 0)
            {
                var levelData = selectedLevel[0];
                Name = levelData["name"];
                decimal coeff;
                if (decimal.TryParse(levelData["coeff"], out coeff))
                {
                    Coeff = coeff;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при вынимании коэффициента из базы данных.");
                }
            }
            else
            {
                MessageBox.Show($"Произошла ошибка при получении данных о должности с идентификатором {id}");
            }

        }

        public QualLevel(string name, decimal coef)
        {
            Name = name;
            Coeff = coef;
        }

        public static DataSet GetDataSet()
        {
            return databaseAdapter.GetDataSet($"Select * FROM {table}");
        }

        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();

            if (string.IsNullOrEmpty(Name) || !isValid(Name, regRules.lettersOnly))
            {
                response.isValid = false;
                response.Message += "Поле Название уровня должно быть не пустым и содержать только буквы.\n";
            }
            if (string.IsNullOrEmpty(Coeff.ToString()) || !isValid(Coeff.ToString(), regRules.floatNumber))
            {
                response.isValid = false;
                response.Message += "Введите правильную коэффициент. Например, 0,5 \n";
            }
            return response;
        }
        private bool isValid(string field, Regex regex)
        {
            return regex.IsMatch(field);
        }
        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT id, name, coeff " +
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
        public static DataSet UpdateDataSet()
        {
            var ds = GetDataSet();
            databaseAdapter.UpdateDataSet(ds.Tables[0], $"Select * from {table}");
            return ds;
        }

        public void Insert()
        {
            var coeff = PrepareCoeff(Coeff);

            try
            {
                var command = $"INSERT INTO public.{table} " +
                    $"(name, coeff)" +
                    $" VALUES ('{Name}', {coeff});";

                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Произошла ошибка при добавлении уровня квалификации.");
            }
        }
        private string PrepareCoeff(decimal coeff)
        {
            return coeff.ToString().Replace(',', '.');
        }

        public bool Update()
        {
            var coeff = PrepareCoeff(Coeff);

            var command = $"UPDATE public.{table}" +
                $" SET name='{Name}', coeff={coeff}" +
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
    }
}
