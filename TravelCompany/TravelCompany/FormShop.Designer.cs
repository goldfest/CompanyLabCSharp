namespace TravelCompanyView
{
    partial class FormShop
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
            labelName = new Label();
            textBoxName = new TextBox();
            textBoxAdress = new TextBox();
            labelAdress = new Label();
            buttonCancel = new Button();
            buttonSave = new Button();
            dataGridView = new DataGridView();
            label1 = new Label();
            dateTimeOpen = new DateTimePicker();
            id = new DataGridViewTextBoxColumn();
            TravelName = new DataGridViewTextBoxColumn();
            Count = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(10, 11);
            labelName.Name = "labelName";
            labelName.Size = new Size(65, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название: ";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(89, 9);
            textBoxName.Margin = new Padding(3, 2, 3, 2);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(242, 23);
            textBoxName.TabIndex = 1;
            // 
            // textBoxAdress
            // 
            textBoxAdress.Location = new Point(89, 44);
            textBoxAdress.Margin = new Padding(3, 2, 3, 2);
            textBoxAdress.Name = "textBoxAdress";
            textBoxAdress.Size = new Size(374, 23);
            textBoxAdress.TabIndex = 3;
            // 
            // labelAdress
            // 
            labelAdress.AutoSize = true;
            labelAdress.Location = new Point(10, 46);
            labelAdress.Name = "labelAdress";
            labelAdress.Size = new Size(46, 15);
            labelAdress.TabIndex = 2;
            labelAdress.Text = "Адрес: ";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(395, 343);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(114, 33);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(276, 343);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(114, 33);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { id, TravelName, Count });
            dataGridView.Location = new Point(10, 108);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(498, 230);
            dataGridView.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 77);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 8;
            label1.Text = "Дата открытия";
            // 
            // dateTimeOpen
            // 
            dateTimeOpen.Location = new Point(112, 77);
            dateTimeOpen.Margin = new Padding(3, 2, 3, 2);
            dateTimeOpen.Name = "dateTimeOpen";
            dateTimeOpen.Size = new Size(351, 23);
            dateTimeOpen.TabIndex = 9;
            // 
            // id
            // 
            id.HeaderText = "id";
            id.MinimumWidth = 6;
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // TravelName
            // 
            TravelName.HeaderText = "Путёвка";
            TravelName.MinimumWidth = 6;
            TravelName.Name = "TravelName";
            TravelName.ReadOnly = true;
            // 
            // Count
            // 
            Count.HeaderText = "Количество";
            Count.MinimumWidth = 6;
            Count.Name = "Count";
            Count.ReadOnly = true;
            // 
            // FormShop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 385);
            Controls.Add(dateTimeOpen);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxAdress);
            Controls.Add(labelAdress);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormShop";
            Text = "Магазин";
            Load += FormShop_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private TextBox textBoxName;
        private TextBox textBoxAdress;
        private Label labelAdress;
        private Button buttonCancel;
        private Button buttonSave;
        private DataGridView dataGridView;
        private Label label1;
        private DateTimePicker dateTimeOpen;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn TravelName;
        private DataGridViewTextBoxColumn Count;
    }
}