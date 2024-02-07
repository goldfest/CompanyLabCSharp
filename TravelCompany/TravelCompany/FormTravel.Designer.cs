namespace TravelCompany.Forms
{
    partial class FormTravel
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
            buttonAdd = new Button();
            buttonUpd = new Button();
            buttonDel = new Button();
            buttonRef = new Button();
            dataGridView = new DataGridView();
            Number = new DataGridViewTextBoxColumn();
            Component = new DataGridViewTextBoxColumn();
            Count = new DataGridViewTextBoxColumn();
            textBoxName = new TextBox();
            textBoxPrice = new TextBox();
            groupBox1 = new GroupBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 15);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Название:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 41);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Стоимость:";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(574, 44);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(97, 28);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpd
            // 
            buttonUpd.Location = new Point(574, 90);
            buttonUpd.Name = "buttonUpd";
            buttonUpd.Size = new Size(97, 28);
            buttonUpd.TabIndex = 1;
            buttonUpd.Text = "Изменить";
            buttonUpd.UseVisualStyleBackColor = true;
            buttonUpd.Click += buttonUpd_Click;
            // 
            // buttonDel
            // 
            buttonDel.Location = new Point(574, 134);
            buttonDel.Name = "buttonDel";
            buttonDel.Size = new Size(97, 28);
            buttonDel.TabIndex = 2;
            buttonDel.Text = "Удалить";
            buttonDel.UseVisualStyleBackColor = true;
            buttonDel.Click += buttonDel_Click;
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(574, 173);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(97, 28);
            buttonRef.TabIndex = 3;
            buttonRef.Text = "Обновить";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += buttonRef_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Number, Component, Count });
            dataGridView.Location = new Point(0, 20);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 24;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.ShowEditingIcon = false;
            dataGridView.Size = new Size(549, 332);
            dataGridView.TabIndex = 4;
            // 
            // Number
            // 
            Number.HeaderText = "Номер";
            Number.MinimumWidth = 6;
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Width = 60;
            // 
            // Component
            // 
            Component.HeaderText = "Компонент";
            Component.MinimumWidth = 6;
            Component.Name = "Component";
            Component.ReadOnly = true;
            Component.Width = 125;
            // 
            // Count
            // 
            Count.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Count.HeaderText = "Количество";
            Count.MinimumWidth = 6;
            Count.Name = "Count";
            Count.ReadOnly = true;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(94, 14);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(246, 23);
            textBoxName.TabIndex = 3;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(94, 39);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.ReadOnly = true;
            textBoxPrice.Size = new Size(85, 23);
            textBoxPrice.TabIndex = 4;
            textBoxPrice.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonRef);
            groupBox1.Controls.Add(buttonDel);
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Controls.Add(buttonUpd);
            groupBox1.Controls.Add(buttonAdd);
            groupBox1.Location = new Point(14, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(689, 367);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Компоненты";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(397, 454);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(114, 28);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(533, 454);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(114, 28);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormTravel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 497);
            Controls.Add(groupBox1);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label1);
            Name = "FormTravel";
            Text = "Туристическая путёвка";
            Load += FormTravel_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button buttonRef;
        private Button buttonDel;
        private Button buttonUpd;
        private Button buttonAdd;
        private DataGridView dataGridView;
        private TextBox textBoxName;
        private TextBox textBoxPrice;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Component;
        private DataGridViewTextBoxColumn Count;
        private Button buttonSave;
        private Button buttonCancel;
    }
}