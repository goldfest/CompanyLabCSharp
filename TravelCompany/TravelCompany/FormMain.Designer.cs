namespace TravelCompany.Forms
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            компонентыToolStripMenuItem = new ToolStripMenuItem();
            ПутёвкиToolStripMenuItem = new ToolStripMenuItem();
            buttonCreateOrder = new Button();
            buttonTakeOrderInWork = new Button();
            buttonOrderReady = new Button();
            buttonIssuedOrder = new Button();
            buttonRef = new Button();
            dataGridView = new DataGridView();
            отчетыToolStripMenuItem = new ToolStripMenuItem();
            списокКомпонентовToolStripMenuItem = new ToolStripMenuItem();
            компонентыПоПутёвкамToolStripMenuItem = new ToolStripMenuItem();
            списокЗаказовToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, отчетыToolStripMenuItem });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(969, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { компонентыToolStripMenuItem, ПутёвкиToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(88, 22);
            toolStripDropDownButton1.Text = "Справочник";
            // 
            // компонентыToolStripMenuItem
            // 
            компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            компонентыToolStripMenuItem.Size = new Size(174, 22);
            компонентыToolStripMenuItem.Text = "Компоненты";
            компонентыToolStripMenuItem.Click += компонентыToolStripMenuItem_Click;
            // 
            // ПутёвкиToolStripMenuItem
            // 
            ПутёвкиToolStripMenuItem.Name = "ПутёвкиToolStripMenuItem";
            ПутёвкиToolStripMenuItem.Size = new Size(174, 22);
            ПутёвкиToolStripMenuItem.Text = "Туристич. путёвки";
            ПутёвкиToolStripMenuItem.Click += консервыToolStripMenuItem_Click;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Location = new Point(800, 56);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(141, 24);
            buttonCreateOrder.TabIndex = 1;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += buttonCreateOrder_Click;
            // 
            // buttonTakeOrderInWork
            // 
            buttonTakeOrderInWork.Location = new Point(800, 100);
            buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            buttonTakeOrderInWork.Size = new Size(141, 24);
            buttonTakeOrderInWork.TabIndex = 2;
            buttonTakeOrderInWork.Text = "Отдать на выполнение";
            buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            buttonTakeOrderInWork.Click += buttonTakeOrderInWork_Click;
            // 
            // buttonOrderReady
            // 
            buttonOrderReady.Location = new Point(800, 142);
            buttonOrderReady.Name = "buttonOrderReady";
            buttonOrderReady.Size = new Size(141, 24);
            buttonOrderReady.TabIndex = 3;
            buttonOrderReady.Text = "Заказ готов";
            buttonOrderReady.UseVisualStyleBackColor = true;
            buttonOrderReady.Click += buttonOrderReady_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Location = new Point(800, 181);
            buttonIssuedOrder.Name = "buttonIssuedOrder";
            buttonIssuedOrder.Size = new Size(141, 24);
            buttonIssuedOrder.TabIndex = 4;
            buttonIssuedOrder.Text = "Заказ выдан";
            buttonIssuedOrder.UseVisualStyleBackColor = true;
            buttonIssuedOrder.Click += buttonIssuedOrder_Click;
            // 
            // buttonRef
            // 
            buttonRef.Location = new Point(800, 222);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(141, 24);
            buttonRef.TabIndex = 5;
            buttonRef.Text = "Обновить список";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += buttonRef_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 26);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 24;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(763, 435);
            dataGridView.TabIndex = 6;
            // 
            // отчетыToolStripMenuItem
            // 
            отчетыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { списокКомпонентовToolStripMenuItem, компонентыПоПутёвкамToolStripMenuItem, списокЗаказовToolStripMenuItem });
            отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            отчетыToolStripMenuItem.Size = new Size(60, 25);
            отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            списокКомпонентовToolStripMenuItem.Size = new Size(216, 22);
            списокКомпонентовToolStripMenuItem.Text = "Список компонентов";
            списокКомпонентовToolStripMenuItem.Click += списокКомпонентовToolStripMenuItem_Click;
            // 
            // компонентыПоПутёвкамToolStripMenuItem
            // 
            компонентыПоПутёвкамToolStripMenuItem.Name = "компонентыПоПутёвкамToolStripMenuItem";
            компонентыПоПутёвкамToolStripMenuItem.Size = new Size(216, 22);
            компонентыПоПутёвкамToolStripMenuItem.Text = "Компоненты по путёвкам";
            компонентыПоПутёвкамToolStripMenuItem.Click += компонентыПоПутёвкамToolStripMenuItem_Click;
            // 
            // списокЗаказовToolStripMenuItem
            // 
            списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            списокЗаказовToolStripMenuItem.Size = new Size(216, 22);
            списокЗаказовToolStripMenuItem.Text = "Список заказов";
            списокЗаказовToolStripMenuItem.Click += списокЗаказовToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 461);
            Controls.Add(dataGridView);
            Controls.Add(buttonRef);
            Controls.Add(buttonIssuedOrder);
            Controls.Add(buttonOrderReady);
            Controls.Add(buttonTakeOrderInWork);
            Controls.Add(buttonCreateOrder);
            Controls.Add(toolStrip1);
            Name = "FormMain";
            Text = "Туристическая фирма";
            Load += FormMain_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private Button buttonCreateOrder;
        private Button buttonTakeOrderInWork;
        private Button buttonOrderReady;
        private Button buttonIssuedOrder;
        private Button buttonRef;
        private DataGridView dataGridView;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem компонентыToolStripMenuItem;
        private ToolStripMenuItem ПутёвкиToolStripMenuItem;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private ToolStripMenuItem компонентыПоПутёвкамToolStripMenuItem;
        private ToolStripMenuItem списокЗаказовToolStripMenuItem;
    }
}