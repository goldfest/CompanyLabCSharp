namespace TravelCompany.Forms
{
    partial class FormReportOrders
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
            this.panel = new System.Windows.Forms.Panel();
            this.buttonCreateToPdf = new System.Windows.Forms.Button();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.buttonCreateToPdf);
            this.panel.Controls.Add(this.buttonCreateReport);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.dateTimePickerEnd);
            this.panel.Controls.Add(this.dateTimePickerStart);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(861, 56);
            this.panel.TabIndex = 0;
            // 
            // buttonCreateToPdf
            // 
            this.buttonCreateToPdf.Location = new System.Drawing.Point(684, 29);
            this.buttonCreateToPdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateToPdf.Name = "buttonCreateToPdf";
            this.buttonCreateToPdf.Size = new System.Drawing.Size(166, 23);
            this.buttonCreateToPdf.TabIndex = 5;
            this.buttonCreateToPdf.Text = "PDF";
            this.buttonCreateToPdf.UseVisualStyleBackColor = true;
            this.buttonCreateToPdf.Click += new System.EventHandler(this.buttonCreateToPdf_Click);
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Location = new System.Drawing.Point(485, 29);
            this.buttonCreateReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(166, 23);
            this.buttonCreateReport.TabIndex = 4;
            this.buttonCreateReport.Text = "Сформировать";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Конец:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Начало:";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(269, 29);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(164, 23);
            this.dateTimePickerEnd.TabIndex = 1;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(31, 29);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(164, 23);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 338);
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormReportOrders";
            this.Text = "Заказы";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel;
        private DateTimePicker dateTimePickerEnd;
        private DateTimePicker dateTimePickerStart;
        private Button buttonCreateToPdf;
        private Button buttonCreateReport;
        private Label label2;
        private Label label1;
    }
}