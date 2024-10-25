namespace Sisir.Sprav
{
    partial class SkillForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.groupBoxAddForm = new System.Windows.Forms.GroupBox();
            this.OkButtonForm = new System.Windows.Forms.Button();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.CancelButoonForm = new System.Windows.Forms.Button();
            this.labelBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.levelOkButton = new System.Windows.Forms.Button();
            this.levelCancel = new System.Windows.Forms.Button();
            this.leveltextBox = new System.Windows.Forms.TextBox();
            this.levelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxAddForm.SuspendLayout();
            this.labelBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(371, 304);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Навык";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Навыки";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(389, 174);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(163, 31);
            this.DeleteButton.TabIndex = 18;
            this.DeleteButton.Text = "Удалить запись";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(389, 97);
            this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(163, 31);
            this.EditButton.TabIndex = 17;
            this.EditButton.Text = "Изменить запись";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(389, 62);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(163, 31);
            this.AddButton.TabIndex = 16;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // groupBoxAddForm
            // 
            this.groupBoxAddForm.Controls.Add(this.OkButtonForm);
            this.groupBoxAddForm.Controls.Add(this.textBox20);
            this.groupBoxAddForm.Controls.Add(this.label26);
            this.groupBoxAddForm.Controls.Add(this.CancelButoonForm);
            this.groupBoxAddForm.Location = new System.Drawing.Point(12, 62);
            this.groupBoxAddForm.Name = "groupBoxAddForm";
            this.groupBoxAddForm.Size = new System.Drawing.Size(354, 297);
            this.groupBoxAddForm.TabIndex = 19;
            this.groupBoxAddForm.TabStop = false;
            this.groupBoxAddForm.Text = "Форма добавления нового навыка";
            this.groupBoxAddForm.Visible = false;
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
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(5, 42);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(152, 22);
            this.textBox20.TabIndex = 11;
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
            // CancelButoonForm
            // 
            this.CancelButoonForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButoonForm.Location = new System.Drawing.Point(224, 260);
            this.CancelButoonForm.Name = "CancelButoonForm";
            this.CancelButoonForm.Size = new System.Drawing.Size(124, 31);
            this.CancelButoonForm.TabIndex = 22;
            this.CancelButoonForm.Text = "Отмена";
            this.CancelButoonForm.UseVisualStyleBackColor = true;
            // 
            // labelBox
            // 
            this.labelBox.Controls.Add(this.label2);
            this.labelBox.Controls.Add(this.levelOkButton);
            this.labelBox.Controls.Add(this.levelCancel);
            this.labelBox.Controls.Add(this.leveltextBox);
            this.labelBox.Controls.Add(this.levelLabel);
            this.labelBox.Location = new System.Drawing.Point(150, 95);
            this.labelBox.Name = "labelBox";
            this.labelBox.Size = new System.Drawing.Size(244, 179);
            this.labelBox.TabIndex = 28;
            this.labelBox.TabStop = false;
            this.labelBox.Text = "Введите уровень навыка";
            this.labelBox.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Уровень владения";
            // 
            // levelOkButton
            // 
            this.levelOkButton.Location = new System.Drawing.Point(48, 135);
            this.levelOkButton.Name = "levelOkButton";
            this.levelOkButton.Size = new System.Drawing.Size(152, 31);
            this.levelOkButton.TabIndex = 3;
            this.levelOkButton.Text = "Ок";
            this.levelOkButton.UseVisualStyleBackColor = true;
            this.levelOkButton.Click += new System.EventHandler(this.levelOkButton_Click);
            // 
            // levelCancel
            // 
            this.levelCancel.Location = new System.Drawing.Point(209, 3);
            this.levelCancel.Name = "levelCancel";
            this.levelCancel.Size = new System.Drawing.Size(29, 28);
            this.levelCancel.TabIndex = 2;
            this.levelCancel.Text = "X";
            this.levelCancel.UseVisualStyleBackColor = true;
            // 
            // leveltextBox
            // 
            this.leveltextBox.Location = new System.Drawing.Point(48, 101);
            this.leveltextBox.Name = "leveltextBox";
            this.leveltextBox.Size = new System.Drawing.Size(152, 22);
            this.leveltextBox.TabIndex = 1;
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(11, 30);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(55, 16);
            this.levelLabel.TabIndex = 0;
            this.levelLabel.Text = "Навык: ";
            // 
            // SkillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 377);
            this.Controls.Add(this.labelBox);
            this.Controls.Add(this.groupBoxAddForm);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SkillForm";
            this.Text = "Справочник уровней";
            this.Activated += new System.EventHandler(this.SkillForm_Activated);
            this.Load += new System.EventHandler(this.Skill_Load);
            this.ParentChanged += new System.EventHandler(this.SkillForm_ParentChanged);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.AddButton, 0);
            this.Controls.SetChildIndex(this.EditButton, 0);
            this.Controls.SetChildIndex(this.DeleteButton, 0);
            this.Controls.SetChildIndex(this.groupBoxAddForm, 0);
            this.Controls.SetChildIndex(this.labelBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxAddForm.ResumeLayout(false);
            this.groupBoxAddForm.PerformLayout();
            this.labelBox.ResumeLayout(false);
            this.labelBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox groupBoxAddForm;
        private System.Windows.Forms.Button OkButtonForm;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button CancelButoonForm;
        private System.Windows.Forms.GroupBox labelBox;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.TextBox leveltextBox;
        private System.Windows.Forms.Button levelCancel;
        private System.Windows.Forms.Button levelOkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}