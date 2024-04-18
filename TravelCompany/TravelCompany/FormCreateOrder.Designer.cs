namespace TravelCompany.Forms
{
    partial class FormCreateOrder
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxCount = new TextBox();
            comboBoxTravel = new ComboBox();
            textBoxSum = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            ClientComboBox = new ComboBox();
            ClientLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 12);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Изделие:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 44);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 1;
            label2.Text = "Количество:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 70);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 2;
            label3.Text = "Сумма:";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(103, 41);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(246, 23);
            textBoxCount.TabIndex = 3;
            textBoxCount.TextChanged += textBoxCount_TextChanged;
            // 
            // comboBoxTravel
            // 
            comboBoxTravel.FormattingEnabled = true;
            comboBoxTravel.Location = new Point(103, 10);
            comboBoxTravel.Name = "comboBoxTravel";
            comboBoxTravel.Size = new Size(246, 23);
            comboBoxTravel.TabIndex = 4;
            comboBoxTravel.SelectedIndexChanged += ComboBoxTravel_SelectedIndexChanged;
            // 
            // textBoxSum
            // 
            textBoxSum.Location = new Point(103, 70);
            textBoxSum.Name = "textBoxSum";
            textBoxSum.ReadOnly = true;
            textBoxSum.Size = new Size(246, 23);
            textBoxSum.TabIndex = 5;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(156, 142);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 27);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(255, 142);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 27);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ClientComboBox
            // 
            ClientComboBox.FormattingEnabled = true;
            ClientComboBox.Location = new Point(103, 99);
            ClientComboBox.Name = "ClientComboBox";
            ClientComboBox.Size = new Size(246, 23);
            ClientComboBox.TabIndex = 10;
            // 
            // ClientLabel
            // 
            ClientLabel.AutoSize = true;
            ClientLabel.Location = new Point(19, 102);
            ClientLabel.Name = "ClientLabel";
            ClientLabel.Size = new Size(46, 15);
            ClientLabel.TabIndex = 11;
            ClientLabel.Text = "Клиент";
            // 
            // FormCreateOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 181);
            Controls.Add(ClientLabel);
            Controls.Add(ClientComboBox);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxSum);
            Controls.Add(comboBoxTravel);
            Controls.Add(textBoxCount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCreateOrder";
            Text = "Заказ";
            Load += FormCreateOrder_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxCount;
        private ComboBox comboBoxTravel;
        private TextBox textBoxSum;
        private Button buttonSave;
        private Button buttonCancel;
        private ComboBox ClientComboBox;
        private Label ClientLabel;
    }
}