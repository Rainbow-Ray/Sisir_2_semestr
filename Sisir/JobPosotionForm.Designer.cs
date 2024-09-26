namespace Sisir
{
    partial class JobPosotionForm
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
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OkButtonForm = new System.Windows.Forms.Button();
            this.groupBoxAddForm = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.CancelButoonForm = new System.Windows.Forms.Button();
            this.dataGridViewWorkers = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxAddForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(630, 157);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(163, 31);
            this.DeleteButton.TabIndex = 17;
            this.DeleteButton.Text = "Удалить запись";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(630, 80);
            this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(163, 31);
            this.EditButton.TabIndex = 16;
            this.EditButton.Text = "Изменить запись";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(630, 45);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(163, 31);
            this.AddButton.TabIndex = 15;
            this.AddButton.Text = "Добавить запись";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Должности";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.OkButtonForm.Click += new System.EventHandler(this.OkButtonForm_Click_1);
            // 
            // groupBoxAddForm
            // 
            this.groupBoxAddForm.Controls.Add(this.numericUpDown1);
            this.groupBoxAddForm.Controls.Add(this.OkButtonForm);
            this.groupBoxAddForm.Controls.Add(this.label27);
            this.groupBoxAddForm.Controls.Add(this.textBox20);
            this.groupBoxAddForm.Controls.Add(this.label26);
            this.groupBoxAddForm.Controls.Add(this.CancelButoonForm);
            this.groupBoxAddForm.Location = new System.Drawing.Point(17, 45);
            this.groupBoxAddForm.Name = "groupBoxAddForm";
            this.groupBoxAddForm.Size = new System.Drawing.Size(354, 297);
            this.groupBoxAddForm.TabIndex = 18;
            this.groupBoxAddForm.TabStop = false;
            this.groupBoxAddForm.Text = "Форма добавления новой должности";
            this.groupBoxAddForm.Visible = false;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Location = new System.Drawing.Point(5, 84);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(152, 22);
            this.numericUpDown1.TabIndex = 28;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 65);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(128, 16);
            this.label27.TabIndex = 8;
            this.label27.Text = "Заработная плата";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(5, 40);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(152, 22);
            this.textBox20.TabIndex = 11;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 21);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 16);
            this.label26.TabIndex = 10;
            this.label26.Text = "Название";
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
            this.CancelButoonForm.Click += new System.EventHandler(this.CancelButoonForm_Click_1);
            // 
            // dataGridViewWorkers
            // 
            this.dataGridViewWorkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewWorkers.ColumnHeadersHeight = 29;
            this.dataGridViewWorkers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16});
            this.dataGridViewWorkers.Location = new System.Drawing.Point(17, 45);
            this.dataGridViewWorkers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewWorkers.Name = "dataGridViewWorkers";
            this.dataGridViewWorkers.ReadOnly = true;
            this.dataGridViewWorkers.RowHeadersWidth = 51;
            this.dataGridViewWorkers.RowTemplate.Height = 24;
            this.dataGridViewWorkers.Size = new System.Drawing.Size(607, 389);
            this.dataGridViewWorkers.TabIndex = 13;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Название";
            this.Column15.MinimumWidth = 6;
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 102;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "Зарплата";
            this.Column16.MinimumWidth = 6;
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            // 
            // JobPosotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxAddForm);
            this.Controls.Add(this.dataGridViewWorkers);
            this.Name = "JobPosotionForm";
            this.Text = "Справочник должностей";
            this.Load += new System.EventHandler(this.JobPosotionForm_Load);
            this.groupBoxAddForm.ResumeLayout(false);
            this.groupBoxAddForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OkButtonForm;
        private System.Windows.Forms.GroupBox groupBoxAddForm;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button CancelButoonForm;
        private System.Windows.Forms.DataGridView dataGridViewWorkers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
    }
}