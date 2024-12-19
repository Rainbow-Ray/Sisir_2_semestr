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
using System.IO;


namespace Sisir.Summary
{
    public partial class Summary : FormWithStripMenu
    {
        public Summary()
        {
            InitializeComponent();
        }

        internal string FileName()
        {
            var date = new DateTime(DateTime.Now.Ticks);
            var d = date.Ticks.ToString();
             return $"{d}"
                
                ;
        }

        private void Summary_Load(object sender, EventArgs e)
        {

        }
        internal string FormatDateForDB(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        internal void Fill(string template, Content valuesToFill, string filePath)
        {
            if (CopyTemplate(template, filePath))
            {
                using (var outputDocument = new TemplateProcessor(@filePath)
    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                }
                //MessageBox.Show("Отчет сохранен в " + filePath);
                System.Diagnostics.Process.Start(@filePath);
            }
        }
        private bool CopyTemplate(string templatePath, string destinationPath)
        {
            //try
            //{
                File.Copy(@templatePath, @destinationPath);
                return true;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Файл с таким именем уже существует.");
            //    return false;
            //}
        }

        public void CreateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
