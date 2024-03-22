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
            panel = new Panel();
            buttonCreateToPdf = new Button();
            buttonCreateReport = new Button();
            label2 = new Label();
            label1 = new Label();
            dateTimePickerFrom = new DateTimePicker();
            dateTimePickerTo = new DateTimePicker();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(buttonCreateToPdf);
            panel.Controls.Add(buttonCreateReport);
            panel.Controls.Add(label2);
            panel.Controls.Add(label1);
            panel.Controls.Add(dateTimePickerFrom);
            panel.Controls.Add(dateTimePickerTo);
            panel.Location = new Point(12, 12);
            panel.Name = "panel";
            panel.Size = new Size(776, 43);
            panel.TabIndex = 0;
            // 
            // buttonCreateToPdf
            // 
            buttonCreateToPdf.Location = new Point(623, 17);
            buttonCreateToPdf.Name = "buttonCreateToPdf";
            buttonCreateToPdf.Size = new Size(150, 23);
            buttonCreateToPdf.TabIndex = 5;
            buttonCreateToPdf.Text = "В Pdf";
            buttonCreateToPdf.UseVisualStyleBackColor = true;
            buttonCreateToPdf.Click += buttonCreateToPdf_Click;
            // 
            // buttonCreateReport
            // 
            buttonCreateReport.Location = new Point(470, 17);
            buttonCreateReport.Name = "buttonCreateReport";
            buttonCreateReport.Size = new Size(147, 23);
            buttonCreateReport.TabIndex = 4;
            buttonCreateReport.Text = "Сформировать";
            buttonCreateReport.UseVisualStyleBackColor = true;
            buttonCreateReport.Click += buttonCreateReport_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 23);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 3;
            label2.Text = "По";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 23);
            label1.Name = "label1";
            label1.Size = new Size(15, 15);
            label1.TabIndex = 2;
            label1.Text = "С";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(29, 17);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(200, 23);
            dateTimePickerFrom.TabIndex = 0;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(264, 17);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(200, 23);
            dateTimePickerTo.TabIndex = 1;
            // 
            // FormReportOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel);
            Name = "FormReportOrders";
            Text = "Заказы";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Button buttonCreateToPdf;
        private Button buttonCreateReport;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerFrom;
        private DateTimePicker dateTimePickerTo;
    }
}
