using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sisir.Entity
{
    public class Worker : IEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronym { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Tg { get; set; }
        public string Phone { get; set; }
        public string PassSerie { get; set; }
        public string PassNum { get; set; }
        public DateTime PassDate { get; set; }
        public string AdressPass { get; set; }
        public string AdressFact { get; set; }
        public string PassWho { get; set; }
        public int Job { get; set; }
        public int QualLevel { get; set; }
        public int Id { get; set; }

        public string isFired { get; set; }

        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();

        public Worker() { }


        public Worker(int id)
        {
            Id = id;
            var selectedWorker = Select(id);

            if (selectedWorker.Count > 0)
            {
                var workerData = selectedWorker[0];
                Surname = workerData["surname"];
                Name = workerData["name"];
                Patronym = workerData["patronym"];
                DateTime bday;
                if (DateTime.TryParse(workerData["birth_date"], out bday))
                {
                    BirthDate = bday;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при вынимании Даты рождения из базы данных.");
                }
                Email = workerData["email"];
                Tg = workerData["tg"];
                Phone = workerData["phone"];
                PassSerie = workerData["pass_serie"];
                PassNum = workerData["pass_num"];
                DateTime pday;
                if (DateTime.TryParse(workerData["pass_date"], out pday))
                {
                    PassDate = pday;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при вынимании Даты выдачи паспорта из базы данных.");
                }
                AdressPass = workerData["adress_pass"];
                AdressFact = workerData["adress_fact"];
                PassWho = workerData["pass_who"];

                int job;
                if (int.TryParse(workerData["job_position"], out job))
                {
                    Job = job;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при вынимании Должности из базы данных.");
                }

                int qual;
                if (int.TryParse(workerData["qual_level"], out qual))
                {
                    QualLevel = qual;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при вынимании Уровня квалификации из базы данных.");
                }
            }
            else
            {
                MessageBox.Show($"Произошла ошибка при получении данных о сотруднике с идентификатором {id}");
            }
        }

        public Worker(string surname, string name, string passNum, DateTime passDate,
            string patronym = null,
            DateTime birthDate = new DateTime(), string email = null, string tg = null, string phone = null,
            string passSerie = null, string adressPass = null,
            string adressFact = null, string passWho = null, int job = -1, int qualLevel = -1
            )
        {
            Surname = surname;
            Name = name;
            Patronym = patronym;
            BirthDate = birthDate;
            Email = email;
            Tg = tg;
            Phone = phone;
            PassSerie = passSerie;
            PassNum = passNum;
            PassDate = passDate;
            AdressPass = adressPass;
            AdressFact = adressFact;
            PassWho = passWho;
            Job = job;
            QualLevel = qualLevel;
        }
        public Worker(int id, string surname, string name, string passNum, DateTime passDate,
            string patronym = null,
            DateTime birthDate = new DateTime(), string email = null, string tg = null, string phone = null,
            string passSerie = null, string adressPass = null,
            string adressFact = null, string passWho = null, int job = -1, int qualLevel = -1
            )
        {
            Id = id;
            var data = Select(id);
            if (data.Count > 0)
            {
                Surname = surname;
                Name = name;
                Patronym = patronym;
                BirthDate = birthDate;
                Email = email;
                Tg = tg;
                Phone = phone;
                PassSerie = passSerie;
                PassNum = passNum;
                PassDate = passDate;
                AdressPass = adressPass;
                AdressFact = adressFact;
                PassWho = passWho;
                Job = job;
                QualLevel = qualLevel;
            }
            else
            {
                MessageBox.Show($"Произошла проблема при поиске сотрудника с данным идентификатором ({id})");
            }
        }

        public static DataSet GetDataSet()
        {
            return databaseAdapter.GetDataSet(
                "Select worker.id, worker.name, surname, patronym, birth_date, email, tg, phone,pass_serie, pass_num, pass_date, adress_pass, adress_fact, qual_level, pass_who, job_position.id as job_id, job_position.name as job_position, qual_level.id as qual_id, qual_level.name as qual_name from worker left join job_position on worker.job_position = job_position.id left join qual_level on worker.qual_level = qual_level.id where is_fired = false"
                );
        }

        public static DataSet GetFio()
        {
            return databaseAdapter.GetDataSet(
                "Select worker.id, worker.name || ' ' || surname || ' ' || patronym as FIO from worker where is_fired = false"
                );
        }



        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();

            if (string.IsNullOrEmpty(Surname) || !isValid(Surname, regRules.lettersOnly))
            {
                response.isValid = false;
                response.Message += "Поле Фамилии должно быть не пустым и содержать только буквы.\n";
            }
            if (string.IsNullOrEmpty(Name) || !isValid(Name, regRules.lettersOnly))
            {
                response.isValid = false;
                response.Message += "Поле Имени должно быть не пустым и содержать только буквы.\n";
            }
            if (!string.IsNullOrEmpty(Patronym) && !isValid(Patronym, regRules.lettersOnly))
            {
                response.isValid = false;
                response.Message += "Поле Отчество должно содержать только буквы.\n";
            }
            if (BirthDate >= DateTime.Now || BirthDate < new DateTime(1700, 01, 01))
            {
                response.isValid = false;
                response.Message += "Введите реальную дату рождения.\n";
            }
            if (!string.IsNullOrEmpty(Email) && !isValid(Email, regRules.email))
            {
                response.isValid = false;
                response.Message += "Введите правильный email. Например, ivan_2@mail.ru \n";
            }
            if (!string.IsNullOrEmpty(Tg) && !isValid(Tg, regRules.tg))
            {
                response.isValid = false;
                response.Message += "Введите правильный ник Telegram. Например, @ivan \n";
            }
            if (!string.IsNullOrEmpty(Phone) && !isValid(Phone, regRules.phone))
            {
                response.isValid = false;
                response.Message += "Введите правильный номер телефона. Например, 89224443311 \n";
            }
            if (!string.IsNullOrEmpty(PassSerie) && !isValid(PassSerie, regRules.passSerie))
            {
                response.isValid = false;
                response.Message += "Введите правильную серию паспорта. Например, 1234 \n";
            }
            if (string.IsNullOrEmpty(PassNum) || !isValid(PassNum, regRules.numberOnly))
            {
                response.isValid = false;
                response.Message += "Введите правильный номер паспорта. Например, 123456 \n";
            }
            if (PassDate >= DateTime.Now || BirthDate < new DateTime(1700, 01, 01))
            {
                response.isValid = false;
                response.Message += "Введите реальную дату выдачи паспорта.\n";
            }
            if (!string.IsNullOrEmpty(AdressPass) && !isValid(AdressPass, regRules.adress))
            {
                response.isValid = false;
                response.Message += "Введите правильный адрес прописки. Например, г.Тюмень, ул. Пушкина 7 \n";
            }
            if (!string.IsNullOrEmpty(AdressFact) && !isValid(AdressFact, regRules.adress))
            {
                response.isValid = false;
                response.Message += "Введите правильный адрес проживания. Например, г.Тюмень, ул. Пушкина 7 \n";
            }
            if (!string.IsNullOrEmpty(PassWho) && !isValid(PassWho, regRules.adress))
            {
                response.isValid = false;
                response.Message += "Введите правильную информацию о выдаче паспорта. " +
                    "Например, УМВД России по Тюменской области \n";
            }
            return response;
        }

        private bool isValid(string field, Regex regex)
        {
            return regex.IsMatch(field);
        }

        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT id, surname, name, patronym, birth_date, email, tg, phone, " +
                "pass_serie, pass_num, pass_date, adress_pass, adress_fact, qual_level, job_position, pass_who"
                + $" FROM public.worker WHERE id={id} and is_fired=false;";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }

        private enum DataType
        {
            ForeignKey,
            Date

        }

        private enum TableType
        {
            Job,
            Qual
        }

        private string PrepareForeignKey<T>(T data, DataType mode, TableType table)
        {
            string result = null;
            bool isin = false;
            if (table == TableType.Job)
            {
                isin = JobPos.IsIn(int.Parse(data.ToString()));
            }
            else if (table == TableType.Qual)
            {
                isin = Sisir.Entity.QualLevel.IsIn(int.Parse(data.ToString()));
            }
            result = isin ? data.ToString() : "null";
            return result;
        }
        private string PrepareDate<T>(T data, DataType mode)
        {
            string result = null;
            var d = DateTime.Parse(data.ToString());
            result = d.ToString("yyyy-MM-dd");

            return result;
        }


        public static DataSet UpdateDataSet()
        {
            try
            {
                var ds = GetDataSet();
                databaseAdapter.UpdateDataSet(ds.Tables[0],
                    "Select worker.id, worker.name, surname, patronym, birth_date, email, tg, phone,\r\npass_serie, pass_num, pass_date, adress_pass, \r\nadress_fact, qual_level, pass_who,\r\njob_position.id as job_id, job_position.name as job_position \r\nfrom worker left join job_position on worker.job_position = job_position.id where is_fired = false"
                    );
                return ds;
            }
            catch (Npgsql.NpgsqlException)
            {
                MessageBox.Show("Произошла ошибка при наполнении таблицы сотрудников.");
                return new DataSet();
            }
        }

        public void Insert()
        {
            try
            {
                var j = new JobPos();
                string job = PrepareForeignKey(Job, DataType.ForeignKey, TableType.Job);
                string qual = PrepareForeignKey(QualLevel, DataType.ForeignKey, TableType.Qual);
                string bday = PrepareDate(BirthDate, DataType.Date);
                string pasdate = PrepareDate(PassDate, DataType.Date);

                var command = $"INSERT INTO public.worker " +
                    $"(surname, name, patronym, birth_date, email, tg, phone," +
                    $"pass_serie, pass_num, pass_date, adress_pass, adress_fact, pass_who, job_position, qual_level, is_fired)" +
                    $"VALUES ('{Name}', '{Surname}', '{Patronym}', '{bday}', '{Email}', '{Tg}', '{Phone}', " +
                    $"'{PassSerie}', '{PassNum}', '{pasdate}', '{AdressPass}', '{AdressFact}', '{PassWho}', {job}, {qual}, false);";


                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.NpgsqlException)
            {
                MessageBox.Show("Произошла ошибка при добавлении сотрудника.");
            }


        }
        public ValidationResponse InsertWithReturn()
        {
            try
            {
                var j = new JobPos();
                string job = PrepareForeignKey(Job, DataType.ForeignKey, TableType.Job);
                string qual = PrepareForeignKey(QualLevel, DataType.ForeignKey, TableType.Qual);
                string bday = PrepareDate(BirthDate, DataType.Date);
                string pasdate = PrepareDate(PassDate, DataType.Date);

                var command = $"INSERT INTO public.worker " +
                    $"(surname, name, patronym, birth_date, email, tg, phone," +
                    $"pass_serie, pass_num, pass_date, adress_pass, adress_fact, pass_who, job_position, qual_level, is_fired)" +
                    $"VALUES ('{Name}', '{Surname}', '{Patronym}', '{bday}', '{Email}', '{Tg}', '{Phone}', " +
                    $"'{PassSerie}', '{PassNum}', '{pasdate}', '{AdressPass}', '{AdressFact}', '{PassWho}', {job}, {qual}, false)  " +
                    $"RETURNING worker.id;";


                var dict = databaseAdapter.ExecuteCommand(command);
                var id = dict[0]["id"];
                var response = new ValidationResponse();
                if (id != null)
                {
                    response.isValid = true;
                    response.Message = id;
                }
                else
                {
                    response.isValid = false;
                    response.Message = "Произошла ошибка при добавлении сотрудника.";
                }

                return response;

            }
            catch (Npgsql.NpgsqlException)
            {
                var response = new ValidationResponse();
                response.isValid = false;
                response.Message = "Произошла ошибка при добавлении сотрудника.";
                return response;
            }


        }


        public bool Update()
        {
            string job = PrepareForeignKey(Job, DataType.ForeignKey, TableType.Job);
            string qual = PrepareForeignKey(QualLevel, DataType.ForeignKey, TableType.Qual);
            string bday = PrepareDate(BirthDate, DataType.Date);
            string pasdate = PrepareDate(PassDate, DataType.Date);

            var command = "UPDATE public.worker " +
                $"SET surname='{Surname}', name='{Name}', patronym='{Patronym}', birth_date='{bday}', email='{Email}', tg='{Tg}', phone='{Phone}', " +
                $"pass_serie='{PassSerie}', pass_num='{PassNum}', pass_date='{pasdate}', adress_pass='{AdressPass}', adress_fact='{AdressFact}'," +
                $"qual_level={qual}, job_position={job}, pass_who='{PassWho}' " +
                $"WHERE id={Id};";

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
            var command = "UPDATE public.worker " +
    $"SET is_fired='true' " +
    $"WHERE id={Id};";

            databaseAdapter.ExecuteCommandNoReturn(command);

        }

        internal static bool IsIn(int existingId)
        {
            var data = Select(existingId);
            if (data.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
