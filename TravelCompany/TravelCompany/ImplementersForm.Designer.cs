namespace TravelCompany.Forms
{
	partial class ImplementersForm
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
			dataGridView1 = new DataGridView();
			CreateButton = new Button();
			ChangeButton = new Button();
			DeleteButton = new Button();
			RefreshButton = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(12, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.Size = new Size(565, 426);
			dataGridView1.TabIndex = 0;
			// 
			// CreateButton
			// 
			CreateButton.Location = new Point(583, 12);
			CreateButton.Name = "CreateButton";
			CreateButton.Size = new Size(205, 29);
			CreateButton.TabIndex = 1;
			CreateButton.Text = "Создать";
			CreateButton.UseVisualStyleBackColor = true;
			CreateButton.Click += CreateButton_Click;
			// 
			// ChangeButton
			// 
			ChangeButton.Location = new Point(583, 47);
			ChangeButton.Name = "ChangeButton";
			ChangeButton.Size = new Size(205, 29);
			ChangeButton.TabIndex = 2;
			ChangeButton.Text = "Изменить";
			ChangeButton.UseVisualStyleBackColor = true;
			ChangeButton.Click += ChangeButton_Click;
			// 
			// DeleteButton
			// 
			DeleteButton.Location = new Point(583, 82);
			DeleteButton.Name = "DeleteButton";
			DeleteButton.Size = new Size(205, 29);
			DeleteButton.TabIndex = 3;
			DeleteButton.Text = "Удалить";
			DeleteButton.UseVisualStyleBackColor = true;
			DeleteButton.Click += DeleteButton_Click;
			// 
			// RefreshButton
			// 
			RefreshButton.Location = new Point(583, 117);
			RefreshButton.Name = "RefreshButton";
			RefreshButton.Size = new Size(205, 29);
			RefreshButton.TabIndex = 4;
			RefreshButton.Text = "Обновить";
			RefreshButton.UseVisualStyleBackColor = true;
			RefreshButton.Click += RefreshButton_Click;
			// 
			// ImplementersForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(RefreshButton);
			Controls.Add(DeleteButton);
			Controls.Add(ChangeButton);
			Controls.Add(CreateButton);
			Controls.Add(dataGridView1);
			Name = "ImplementersForm";
			Text = "Исполнители";
			Load += ImplementersForm_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dataGridView1;
		private Button CreateButton;
		private Button ChangeButton;
		private Button DeleteButton;
		private Button RefreshButton;
	}
}