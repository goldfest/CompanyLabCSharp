namespace TravelCompany.Forms
{
	partial class ImplementerForm
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
			FIOTextBox = new TextBox();
			PasswordTextBox = new TextBox();
			QualificationTextBox = new TextBox();
			WorkExperienceTextBox = new TextBox();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			SaveButton = new Button();
			CancelButton = new Button();
			SuspendLayout();
			// 
			// FIOTextBox
			// 
			FIOTextBox.Location = new Point(124, 19);
			FIOTextBox.Name = "FIOTextBox";
			FIOTextBox.Size = new Size(411, 27);
			FIOTextBox.TabIndex = 0;
			// 
			// PasswordTextBox
			// 
			PasswordTextBox.Location = new Point(124, 52);
			PasswordTextBox.Name = "PasswordTextBox";
			PasswordTextBox.Size = new Size(411, 27);
			PasswordTextBox.TabIndex = 1;
			// 
			// QualificationTextBox
			// 
			QualificationTextBox.Location = new Point(124, 85);
			QualificationTextBox.Name = "QualificationTextBox";
			QualificationTextBox.Size = new Size(411, 27);
			QualificationTextBox.TabIndex = 2;
			// 
			// WorkExperienceTextBox
			// 
			WorkExperienceTextBox.Location = new Point(124, 118);
			WorkExperienceTextBox.Name = "WorkExperienceTextBox";
			WorkExperienceTextBox.Size = new Size(411, 27);
			WorkExperienceTextBox.TabIndex = 3;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 19);
			label1.Name = "label1";
			label1.Size = new Size(42, 20);
			label1.TabIndex = 4;
			label1.Text = "ФИО";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(9, 52);
			label2.Name = "label2";
			label2.Size = new Size(62, 20);
			label2.TabIndex = 5;
			label2.Text = "Пароль";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(9, 85);
			label3.Name = "label3";
			label3.Size = new Size(111, 20);
			label3.TabIndex = 6;
			label3.Text = "Квалификация";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(9, 118);
			label4.Name = "label4";
			label4.Size = new Size(99, 20);
			label4.TabIndex = 7;
			label4.Text = "Стаж работы";
			// 
			// SaveButton
			// 
			SaveButton.Location = new Point(341, 151);
			SaveButton.Name = "SaveButton";
			SaveButton.Size = new Size(94, 29);
			SaveButton.TabIndex = 8;
			SaveButton.Text = "Сохранить";
			SaveButton.UseVisualStyleBackColor = true;
			SaveButton.Click += SaveButton_Click;
			// 
			// CancelButton
			// 
			CancelButton.Location = new Point(441, 151);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new Size(94, 29);
			CancelButton.TabIndex = 9;
			CancelButton.Text = "Отмена";
			CancelButton.UseVisualStyleBackColor = true;
			CancelButton.Click += CancelButton_Click;
			// 
			// ImplementerForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(548, 186);
			Controls.Add(CancelButton);
			Controls.Add(SaveButton);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(WorkExperienceTextBox);
			Controls.Add(QualificationTextBox);
			Controls.Add(PasswordTextBox);
			Controls.Add(FIOTextBox);
			Name = "ImplementerForm";
			Text = "Исполнитель";
			Load += ImplementerForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox FIOTextBox;
		private TextBox PasswordTextBox;
		private TextBox QualificationTextBox;
		private TextBox WorkExperienceTextBox;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Button SaveButton;
		private Button CancelButton;
	}
}