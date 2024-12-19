namespace Sisir
{
    partial class QualificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.CancelButoonForm = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBoxAddForm = new System.Windows.Forms.GroupBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.salaryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.OkButtonForm = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewWorkers = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.должностиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.уровниКвалификацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxAddForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(5, 42);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(152, 22);
            this.nameTextBox.TabIndex = 11;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 72);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(166, 16);
            this.label27.TabIndex = 8;
            this.label27.Text = "Коэффициент прибавки";
            // 
            // CancelButoonForm
            // 
            this.CancelButoonForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButoonForm.Location = new System.Drawing.Point(224, 260);
            this.CancelButoonForm.Name = "CancelButoonForm";
            this.CancelButoonForm.Size = new System.Drawing.Size(124, 31);
            this.CancelButoonForm.TabIndex = 22;
            this.CancelButoonForm.Text = "Отмена";
            this.CancelButoonForm.UseVisualStyleBackColor = true;
            this.CancelButoonForm.Click += new System.EventHandler(this.CancelButoonForm_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 23);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 16);
            this.label26.TabIndex = 10;
            this.label26.Text = "Название";
            // 
            // groupBoxAddForm
            // 
            this.groupBoxAddForm.Controls.Add(this.idLabel);
            this.groupBoxAddForm.Controls.Add(this.salaryNumericUpDown);
            this.groupBoxAddForm.Controls.Add(this.OkButtonForm);
            this.groupBoxAddForm.Controls.Add(this.label27);
            this.groupBoxAddForm.Controls.Add(this.nameTextBox);
            this.groupBoxAddForm.Controls.Add(this.label26);
            this.groupBoxAddForm.Controls.Add(this.CancelButoonForm);
            this.groupBoxAddForm.Location = new System.Drawing.Point(17, 70);
            this.groupBoxAddForm.Name = "groupBoxAddForm";
            this.groupBoxAddForm.Size = new System.Drawing.Size(354, 297);
            this.groupBoxAddForm.TabIndex = 12;
            this.groupBoxAddForm.TabStop = false;
            this.groupBoxAddForm.Visible = false;
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(6, 116);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(0, 16);
            this.idLabel.TabIndex = 29;
            this.idLabel.Visible = false;
            // 
            // salaryNumericUpDown
            // 
            this.salaryNumericUpDown.DecimalPlaces = 1;
            this.salaryNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.salaryNumericUpDown.Location = new System.Drawing.Point(5, 91);
            this.salaryNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.salaryNumericUpDown.Name = "salaryNumericUpDown";
            this.salaryNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.salaryNumericUpDown.TabIndex = 28;
            this.salaryNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OkButtonForm
            // 
            this.OkButtonForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButtonForm.Location = new System.Drawing.Point(94, 260);
            this.OkButtonForm.Name = "OkButtonForm";
            this.OkButtonForm.Size = new System.Drawing.Size(124, 31);
            this.OkButtonForm.TabIndex = 27;
            this.OkButtonForm.Text = "Ок";
            this.OkButtonForm.UseVisualStyleBackColor = true;
            this.OkButtonForm.Click += new System.EventHandler(this.OkButtonForm_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(630, 182);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(163, 31);
            this.DeleteButton.TabIndex = 11;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(630, 105);
            this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(163, 31);
            this.EditButton.TabIndex = 10;
            this.EditButton.Text = "Изменить";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(630, 70);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(163, 31);
            this.AddButton.TabIndex = 9;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Уровни квалификации";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewWorkers
            // 
            this.dataGridViewWorkers.AllowUserToAddRows = false;
            this.dataGridViewWorkers.AllowUserToDeleteRows = false;
            this.dataGridViewWorkers.AllowUserToResizeRows = false;
            this.dataGridViewWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewWorkers.ColumnHeadersHeight = 29;
            this.dataGridViewWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.coeff});
            this.dataGridViewWorkers.Location = new System.Drawing.Point(17, 70);
            this.dataGridViewWorkers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewWorkers.Name = "dataGridViewWorkers";
            this.dataGridViewWorkers.ReadOnly = true;
            this.dataGridViewWorkers.RowHeadersVisible = false;
            this.dataGridViewWorkers.RowHeadersWidth = 51;
            this.dataGridViewWorkers.RowTemplate.Height = 24;
            this.dataGridViewWorkers.Size = new System.Drawing.Size(607, 389);
            this.dataGridViewWorkers.TabIndex = 7;
            this.dataGridViewWorkers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWorkers_CellClick);
            this.dataGridViewWorkers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWorkers_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 47;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Название";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 102;
            // 
            // coeff
            // 
            this.coeff.DataPropertyName = "coeff";
            this.coeff.HeaderText = "Коэффициент прибавки";
            this.coeff.MinimumWidth = 6;
            this.coeff.Name = "coeff";
            this.coeff.ReadOnly = true;
            this.coeff.Width = 195;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(65, 24);
            this.toolStripMenuItem1.Text = "Меню";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникиToolStripMenuItem1,
            this.должностиToolStripMenuItem1,
            this.уровниКвалификацииToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // сотрудникиToolStripMenuItem1
            // 
            this.сотрудникиToolStripMenuItem1.Name = "сотрудникиToolStripMenuItem1";
            this.сотрудникиToolStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.сотрудникиToolStripMenuItem1.Text = "Сотрудники";
            // 
            // должностиToolStripMenuItem1
            // 
            this.должностиToolStripMenuItem1.Name = "должностиToolStripMenuItem1";
            this.должностиToolStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.должностиToolStripMenuItem1.Text = "Должности";
            // 
            // уровниКвалификацииToolStripMenuItem
            // 
            this.уровниКвалификацииToolStripMenuItem.Name = "уровниКвалификацииToolStripMenuItem";
            this.уровниКвалификацииToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.уровниКвалификацииToolStripMenuItem.Text = "Уровни квалификации";
            // 
            // QualificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.groupBoxAddForm);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewWorkers);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QualificationForm";
            this.Text = "Справочник уровней квалификации";
            this.Activated += new System.EventHandler(this.QualificationForm_Activated);
            this.Load += new System.EventHandler(this.Qualification_Load);
            this.ParentChanged += new System.EventHandler(this.QualificationForm_ParentChanged);
            this.Controls.SetChildIndex(this.dataGridViewWorkers, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.AddButton, 0);
            this.Controls.SetChildIndex(this.EditButton, 0);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            this.Controls.SetChildIndex(this.groupBoxAddForm, 0);
            this.groupBoxAddForm.ResumeLayout(false);
            this.groupBoxAddForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salaryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button CancelButoonForm;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBoxAddForm;
        private System.Windows.Forms.Button OkButtonForm;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewWorkers;
        private System.Windows.Forms.NumericUpDown salaryNumericUpDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem должностиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem уровниКвалификацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeff;
        private System.Windows.Forms.Label idLabel;
    }
}