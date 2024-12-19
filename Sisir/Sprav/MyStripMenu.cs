using System.Windows.Forms;

namespace Sisir
{
    public partial class MyStripMenu : MenuStrip
    {
        //Две вкладки меню
        internal ToolStripMenuItem MenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem SpravToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem SummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        //Все подвкладки
        internal ToolStripMenuItem WorkersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem JobPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem QualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem SkillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem ProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

        internal ToolStripMenuItem WorkerAciveSumm = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem WorkerSalarySumm = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem ProjectSumm = new System.Windows.Forms.ToolStripMenuItem();


        internal ToolStripSeparator separator = new ToolStripSeparator();

        public MyStripMenu(string name = "menuStrip1")
        {
            //Все меню сверху
            InitializeComponent();
            this.Name = "UserControl1";
            this.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(800, 28);
            this.TabIndex = 13;
            this.Text = name;
            //
            // Вкладка Меню
            //
            MenuStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            ExitToolStripMenuItem});
            MenuStripMenuItem.Name = "MenuStripMenuItem";
            MenuStripMenuItem.Size = new System.Drawing.Size(65, 24);
            MenuStripMenuItem.Text = "Меню";
            //
            //Вкладка Справочники
            // 
            SpravToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                ProjectToolStripMenuItem,
                WorkersToolStripMenuItem1,
                separator,
                JobPosToolStripMenuItem,
                QualToolStripMenuItem,
                SkillToolStripMenuItem,
            });
            SpravToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            SpravToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            SpravToolStripMenuItem.Text = "Справочники";

            //
            //Вкладка Отчеты
            // 
            SummaryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                WorkerAciveSumm,
                WorkerSalarySumm,
                ProjectSumm
            });
            SummaryToolStripMenuItem.Name = "SummaryToolStripMenuItem";
            SummaryToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            SummaryToolStripMenuItem.Text = "Отчеты";

            // 
            //Подвкладка сотрудникиToolStripMenuItem1
            // 
            WorkersToolStripMenuItem1.Name = "WorkersToolStripMenuItem";
            WorkersToolStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            WorkersToolStripMenuItem1.Text = "Сотрудники";
            // 
            //Подвкладка должностиToolStripMenuItem1
            // 
            JobPosToolStripMenuItem.Name = "JobPosToolStripMenuItem";
            JobPosToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            JobPosToolStripMenuItem.Text = "Должности";
            // 
            //Подвкладка уровниКвалификацииToolStripMenuItem
            // 
            QualToolStripMenuItem.Name = "QualToolStripMenuItem";
            QualToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            QualToolStripMenuItem.Text = "Уровни квалификации";
            //Подвкладка НавыкиSkillToolStripMenuItem
            // 
            SkillToolStripMenuItem.Name = "SkillToolStripMenuItem";
            SkillToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            SkillToolStripMenuItem.Text = "Навыки";
            //Подвкладка ПроектыSkillToolStripMenuItem
            // 
            ProjectToolStripMenuItem.Name = "ProjectlToolStripMenuItem";
            ProjectToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            ProjectToolStripMenuItem.Text = "Проекты";
            // 
            //Подвкладка выходToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            ExitToolStripMenuItem.Text = "Выход";
            //
            // 
            //Подвкладка WorkerAciveSumm
            // 
            WorkerAciveSumm.Name = "WorkerAciveSumm";
            WorkerAciveSumm.Size = new System.Drawing.Size(224, 26);
            WorkerAciveSumm.Text = "Загруженность сотрудников";
            // 
            //Подвкладка WorkerSalarySumm
            // 
            WorkerSalarySumm.Name = "WorkerSalarySumm";
            WorkerSalarySumm.Size = new System.Drawing.Size(224, 26);
            WorkerSalarySumm.Text = "Зарплаты сотрудников";
            //
            //Подвкладка ProjectSumm
            // 
            ProjectSumm.Name = "ProjectSumm";
            ProjectSumm.Size = new System.Drawing.Size(224, 26);
            ProjectSumm.Text = "Просроченные проекты";
            //



            Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MenuStripMenuItem,
            SpravToolStripMenuItem,
            SummaryToolStripMenuItem
            });
        }
    }
}
