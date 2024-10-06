using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisir
{
    public partial class MyStripMenu : MenuStrip
    {
        //Две вкладки меню
        internal ToolStripMenuItem MenuStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem SpravToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        //Все подвкладки
        internal ToolStripMenuItem WorkersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem JobPosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem QualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        internal ToolStripMenuItem ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

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
            WorkersToolStripMenuItem1,
            JobPosToolStripMenuItem,
            QualToolStripMenuItem});
            SpravToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            SpravToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            SpravToolStripMenuItem.Text = "Справочники";
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
            // 
            //Подвкладка выходToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            ExitToolStripMenuItem.Text = "Выход";
            //
            Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            MenuStripMenuItem,
            SpravToolStripMenuItem});
        }
    }
}
