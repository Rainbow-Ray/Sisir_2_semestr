using System;

namespace Sisir
{
    public partial class MainForm : FormWithStripMenu
    {
        private DatabaseAdapter adapter = new DatabaseAdapter();
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(DatabaseAdapter databaseAdapter)
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var command = $"Select * from\r\n(Select project.id, project.name, count(project_worker.worker_id) filter(WHERE is_lead=false) as c \r\nfrom project \r\nleft join project_worker on project.id = project_worker.project_id\r\ngroup by project.id) as t\r\nwhere t.c=0";
       
            var ds = adapter.GetDataSet(command);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Update();
        }

        private void dataGridView1_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }
    }
}
