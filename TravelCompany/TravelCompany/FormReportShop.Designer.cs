namespace TravelCompany.Forms
{
    partial class FormReportShop
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
            buttonSaveToExcel = new Button();
            dataGridView = new DataGridView();
            ColumnShop = new DataGridViewTextBoxColumn();
            ColumnTravel = new DataGridViewTextBoxColumn();
            ColumnCount = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // buttonSaveToExcel
            // 
            buttonSaveToExcel.Location = new Point(0, 4);
            buttonSaveToExcel.Margin = new Padding(3, 2, 3, 2);
            buttonSaveToExcel.Name = "buttonSaveToExcel";
            buttonSaveToExcel.Size = new Size(195, 22);
            buttonSaveToExcel.TabIndex = 3;
            buttonSaveToExcel.Text = "Сохранить в Excel";
            buttonSaveToExcel.UseVisualStyleBackColor = true;
            buttonSaveToExcel.Click += ButtonSaveToExcel_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnShop, ColumnTravel, ColumnCount });
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(0, 36);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(523, 302);
            dataGridView.TabIndex = 2;
            // 
            // ColumnShop
            // 
            ColumnShop.FillWeight = 130F;
            ColumnShop.HeaderText = "Магазин";
            ColumnShop.MinimumWidth = 6;
            ColumnShop.Name = "ColumnShop";
            ColumnShop.ReadOnly = true;
            // 
            // ColumnTravel
            // 
            ColumnTravel.FillWeight = 140F;
            ColumnTravel.HeaderText = "Путевка";
            ColumnTravel.MinimumWidth = 6;
            ColumnTravel.Name = "ColumnTravel";
            ColumnTravel.ReadOnly = true;
            // 
            // ColumnCount
            // 
            ColumnCount.FillWeight = 90F;
            ColumnCount.HeaderText = "Количество";
            ColumnCount.MinimumWidth = 6;
            ColumnCount.Name = "ColumnCount";
            ColumnCount.ReadOnly = true;
            // 
            // FormReportShop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 338);
            Controls.Add(buttonSaveToExcel);
            Controls.Add(dataGridView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormReportShop";
            Text = "Наполненость магазинов";
            Load += FormReportShop_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonSaveToExcel;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ColumnShop;
        private DataGridViewTextBoxColumn ColumnTravel;
        private DataGridViewTextBoxColumn ColumnCount;
    }
}