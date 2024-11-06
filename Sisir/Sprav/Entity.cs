using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisir.Sprav

{ 

    public interface IEntity
    {
        void Validate();
        void Insert();

        void Update();

        void Delete();
    }

    
    public class Worker :IEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public string SecName { get; set; }
        public string Job { get; set; }

        public Worker(string surname, string name, string secName, string job)
        {
            Surname = surname;
            Name = name;
            SecName = secName;
            Job = job;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }

    public class JobPos
    {
        public string Name { get; set; }
        public int Zp { get; set; }
        public JobPos(string name, int zp)
        {
            Name = name;
            Zp = zp;
        }
    }
    public class itemSkill
    {
        public string Name { get; set; }

        public itemSkill(string name)
        {
            Name = name;
        }
    }

    public class QualLevel
    {
        public string Name { get; set; }
        public double Coef { get; set; }
        public QualLevel(string name, double coef)
        {
            Name = name;
            Coef = coef;
        }
    }



}
