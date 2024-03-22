namespace TravelCompany.Forms
{
    partial class FormSellTravels
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
            labelTravel = new Label();
            comboBoxTravel = new ComboBox();
            labelCount = new Label();
            textBoxCount = new TextBox();
            buttonSell = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelTravel
            // 
            labelTravel.AutoSize = true;
            labelTravel.Location = new Point(10, 10);
            labelTravel.Name = "labelTravel";
            labelTravel.Size = new Size(57, 15);
            labelTravel.TabIndex = 0;
            labelTravel.Text = "Путёвка: ";
            // 
            // comboBoxTravel
            // 
            comboBoxTravel.FormattingEnabled = true;
            comboBoxTravel.Location = new Point(101, 8);
            comboBoxTravel.Margin = new Padding(3, 2, 3, 2);
            comboBoxTravel.Name = "comboBoxTravel";
            comboBoxTravel.Size = new Size(210, 23);
            comboBoxTravel.TabIndex = 1;
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(10, 41);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(78, 15);
            labelCount.TabIndex = 2;
            labelCount.Text = "Количество: ";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(101, 39);
            textBoxCount.Margin = new Padding(3, 2, 3, 2);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(210, 23);
            textBoxCount.TabIndex = 3;
            // 
            // buttonSell
            // 
            buttonSell.Location = new Point(112, 74);
            buttonSell.Margin = new Padding(3, 2, 3, 2);
            buttonSell.Name = "buttonSell";
            buttonSell.Size = new Size(82, 22);
            buttonSell.TabIndex = 4;
            buttonSell.Text = "Продать";
            buttonSell.UseVisualStyleBackColor = true;
            buttonSell.Click += ButtonSell_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(212, 74);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // FormSellTravels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 105);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSell);
            Controls.Add(textBoxCount);
            Controls.Add(labelCount);
            Controls.Add(comboBoxTravel);
            Controls.Add(labelTravel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSellTravels";
            Text = "Продажа путёвок";
            Load += FormSellingTravel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTravel;
        private ComboBox comboBoxTravel;
        private Label labelCount;
        private TextBox textBoxCount;
        private Button buttonSell;
        private Button buttonCancel;
    }
}