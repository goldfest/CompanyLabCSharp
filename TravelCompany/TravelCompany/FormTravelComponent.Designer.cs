namespace TravelCompany.Forms
{
    partial class FormTravelComponent
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
            buttonSave = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            comboBoxComponent = new ComboBox();
            textBoxCount = new TextBox();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(174, 75);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(86, 27);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(270, 75);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 27);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 2;
            label1.Text = "Компонент:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 3;
            label2.Text = "Количество:";
            // 
            // comboBoxComponent
            // 
            comboBoxComponent.FormattingEnabled = true;
            comboBoxComponent.Location = new Point(106, 9);
            comboBoxComponent.Name = "comboBoxComponent";
            comboBoxComponent.Size = new Size(250, 23);
            comboBoxComponent.TabIndex = 4;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(106, 44);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(250, 23);
            textBoxCount.TabIndex = 5;
            // 
            // FormTravelComponent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 112);
            Controls.Add(textBoxCount);
            Controls.Add(comboBoxComponent);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Name = "FormTravelComponent";
            Text = "Компонент туристической путёвки";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private Label label1;
        private Label label2;
        private ComboBox comboBoxComponent;
        private TextBox textBoxCount;
    }
}