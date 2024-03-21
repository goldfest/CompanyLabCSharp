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
            ToPdfButton = new Button();
            MakeButton = new Button();
            label2 = new Label();
            label1 = new Label();
            dateTimePickerTo = new DateTimePicker();
            dateTimePickerFrom = new DateTimePicker();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(ToPdfButton);
            panel.Controls.Add(MakeButton);
            panel.Controls.Add(label2);
            panel.Controls.Add(label1);
            panel.Controls.Add(dateTimePickerTo);
            panel.Controls.Add(dateTimePickerFrom);
            panel.Location = new Point(12, 12);
            panel.Name = "panel";
            panel.Size = new Size(776, 43);
            panel.TabIndex = 0;
            // 
            // ToPdfButton
            // 
            ToPdfButton.Location = new Point(623, 17);
            ToPdfButton.Name = "ToPdfButton";
            ToPdfButton.Size = new Size(150, 23);
            ToPdfButton.TabIndex = 5;
            ToPdfButton.Text = "В Pdf";
            ToPdfButton.UseVisualStyleBackColor = true;
            // 
            // MakeButton
            // 
            MakeButton.Location = new Point(470, 17);
            MakeButton.Name = "MakeButton";
            MakeButton.Size = new Size(147, 23);
            MakeButton.TabIndex = 4;
            MakeButton.Text = "Сформировать";
            MakeButton.UseVisualStyleBackColor = true;
            MakeButton.Click += MakeButton_Click;
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
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(264, 17);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(200, 23);
            dateTimePickerTo.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(29, 17);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(200, 23);
            dateTimePickerFrom.TabIndex = 0;
            // 
            // ReportOrdersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel);
            Name = "ReportOrdersForm";
            Text = "Заказы";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private Button ToPdfButton;
        private Button MakeButton;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerTo;
        private DateTimePicker dateTimePickerFrom;
    }
}