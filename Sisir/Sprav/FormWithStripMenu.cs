using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Sisir.Sprav;
using Npgsql;



namespace Sisir
{
    public partial class FormWithStripMenu : Form
    {
        internal MyStripMenu menuStrip;

        public FormWithStripMenu()
        {

            InitializeComponent();
            this.menuStrip = new MyStripMenu();

            this.Controls.Add(menuStrip);
            this.menuStrip.ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            this.menuStrip.WorkersToolStripMenuItem1.Click += WorkersToolStripMenuItem1_Click;
            this.menuStrip.JobPosToolStripMenuItem.Click += JobPosToolStripMenuItem_Click;
            this.menuStrip.QualToolStripMenuItem.Click += QualToolStripMenuItem_Click;
            this.menuStrip.SkillToolStripMenuItem.Click += SkillToolStripMenuItem_Click;
            this.menuStrip.ProjectToolStripMenuItem.Click += ProjectToolStripMenuItem_Click;


        }



        private void ProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSprav<ProjectForm>();
        }

        private void SkillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSprav<SkillForm>();
        }

        private bool IsFormAlreadyOpen(Type type)
        {
            foreach (Form frm in Application.OpenForms)
            {
                Debug.WriteLine(frm.Name);
                if (frm.GetType() == type)
                {
                    return true;
                }
            }
            return false;
        }

        private void QualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSprav<QualificationForm>();
        }

        private void JobPosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSprav<JobPosotionForm>();
        }

        private void WorkersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenSprav<WorkersForm>();
        }

        private void OpenSprav<T>() where T : Form, ISprav, new()
        {
            var isOpen = IsFormAlreadyOpen(typeof(T));
            if (isOpen)
            {
                var f = Application.OpenForms.OfType<T>().FirstOrDefault<T>();
                f.parentForm = null;
                f.Focus();
                var width = Screen.GetBounds(f).Width;
                var height = Screen.GetBounds(f).Height;
                f.Location = new Point((width - f.Width)/2, (height - f.Height)/2);
            }
            else
            {
                T f = new T();
                f.Show();
            }
        }

        public virtual T OpenSprav<T>(bool is_helper = false) where T : Form, ISprav, new()
        {
            var isOpen = IsFormAlreadyOpen(typeof(T));
            if (isOpen)
            {
                var f = Application.OpenForms.OfType<T>().FirstOrDefault<T>();
                if (is_helper)
                {
                    f.Close();
                    f = new T();
                    f.parentForm = this;
                }
                f.Focus();
                f.ShowDialog();
                var width = Screen.GetBounds(f).Width;
                var height = Screen.GetBounds(f).Height;
                f.Location = new Point((width - f.Width) / 2, (height - f.Height) / 2);
                return f;
            }
            else
            {
                T f = new T();
                if (is_helper)
                {
                    f.parentForm = this;
                    f.ShowDialog();
                }
                else
                {
                    f.Show();
                }
                return f;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void SpravParentForm_Load(object sender, EventArgs e)
        {

        }

    }
}
