namespace Sisir.Summary
{
    partial class Summary
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
            this.summaryNameTextBox = new System.Windows.Forms.TextBox();
            this.WorkerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // summaryNameTextBox
            // 
            this.summaryNameTextBox.Location = new System.Drawing.Point(34, 73);
            this.summaryNameTextBox.Name = "summaryNameTextBox";
            this.summaryNameTextBox.Size = new System.Drawing.Size(236, 22);
            this.summaryNameTextBox.TabIndex = 19;
            this.summaryNameTextBox.Visible = false;
            // 
            // WorkerComboBox
            // 
            this.WorkerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkerComboBox.FormattingEnabled = true;
            this.WorkerComboBox.Location = new System.Drawing.Point(34, 190);
            this.WorkerComboBox.Name = "WorkerComboBox";
            this.WorkerComboBox.Size = new System.Drawing.Size(261, 24);
            this.WorkerComboBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Название файла";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Сформировал";
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WorkerComboBox);
            this.Controls.Add(this.summaryNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Summary";
            this.Text = "Summary";
            this.Load += new System.EventHandler(this.Summary_Load);
            this.Controls.SetChildIndex(this.summaryNameTextBox, 0);
            this.Controls.SetChildIndex(this.WorkerComboBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox summaryNameTextBox;
        internal System.Windows.Forms.ComboBox WorkerComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}