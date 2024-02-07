namespace TravelCompany.Forms
{
    partial class FormTravels
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
            buttonRef = new Button();
            buttonDel = new Button();
            buttonUpd = new Button();
            buttonAdd = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(648, 135);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(112, 26);
            buttonRef.TabIndex = 9;
            buttonRef.Text = "Обновить";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += buttonRef_Click;
            // 
            // buttonDel
            // 
            buttonDel.Location = new Point(648, 97);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(112, 26);
            buttonDel.TabIndex = 8;
            buttonDel.Text = "Удалить";
            buttonDel.UseVisualStyleBackColor = true;
            buttonDel.Click += buttonDel_Click;
            // 
            // buttonUpd
            // 
            buttonUpd.Location = new Point(648, 58);
            buttonUpd.Name = "buttonUpd";
            buttonUpd.Size = new Size(112, 26);
            buttonUpd.TabIndex = 7;
            buttonUpd.Text = "Изменить";
            buttonUpd.UseVisualStyleBackColor = true;
            buttonUpd.Click += buttonUpd_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(648, 20);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(112, 26);
            buttonAdd.TabIndex = 6;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(-1, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 24;
            dataGridView.Size = new Size(620, 426);
            dataGridView.TabIndex = 5;
            // 
            // FormTravels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 428);
            Controls.Add(buttonRef);
            Controls.Add(buttonDel);
            Controls.Add(buttonUpd);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormTravels";
            Text = "Список туристических путёвок";
            Load += FormTravels_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonRef;
        private Button buttonDel;
        private Button buttonUpd;
        private Button buttonAdd;
        private DataGridView dataGridView;
    }
}