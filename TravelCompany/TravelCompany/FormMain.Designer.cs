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
            магазиныToolStripMenuItem = new ToolStripMenuItem();
            operationToolStripMenuItem = new ToolStripMenuItem();
            transactionToolStripMenuItem = new ToolStripMenuItem();
            продажаToolStripMenuItem = new ToolStripMenuItem();
            отчётыToolStripMenuItem = new ToolStripMenuItem();
            изделияToolStripMenuItem = new ToolStripMenuItem();
            списокИзделийToolStripMenuItem = new ToolStripMenuItem();
            пиццаСИнгридиентамиToolStripMenuItem = new ToolStripMenuItem();
            магазинToolStripMenuItem = new ToolStripMenuItem();
            информацияToolStripMenuItem = new ToolStripMenuItem();
            загруженностьToolStripMenuItem = new ToolStripMenuItem();
            заказыToolStripMenuItem = new ToolStripMenuItem();
            заказыToolStripMenuItem1 = new ToolStripMenuItem();
            заказыПоГруппамToolStripMenuItem = new ToolStripMenuItem();
            buttonCreateOrder = new Button();
            buttonTakeOrderInWork = new Button();
            buttonOrderReady = new Button();
            buttonIssuedOrder = new Button();
            buttonRef = new Button();
            dataGridView = new DataGridView();
            отчётыToolStripMenuItem1 = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, operationToolStripMenuItem, отчётыToolStripMenuItem });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(969, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { компонентыToolStripMenuItem, ПутёвкиToolStripMenuItem, магазиныToolStripMenuItem });
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
            // магазиныToolStripMenuItem
            // 
            магазиныToolStripMenuItem.Name = "магазиныToolStripMenuItem";
            магазиныToolStripMenuItem.Size = new Size(174, 22);
            магазиныToolStripMenuItem.Text = "Магазины";
            магазиныToolStripMenuItem.Click += shopsToolStripMenuItem_Click;
            // 
            // operationToolStripMenuItem
            // 
            operationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { transactionToolStripMenuItem, продажаToolStripMenuItem, отчётыToolStripMenuItem1 });
            operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            operationToolStripMenuItem.Size = new Size(75, 25);
            operationToolStripMenuItem.Text = "Операции";
            // 
            // transactionToolStripMenuItem
            // 
            transactionToolStripMenuItem.Name = "transactionToolStripMenuItem";
            transactionToolStripMenuItem.Size = new Size(180, 22);
            transactionToolStripMenuItem.Text = "Поставка";
            transactionToolStripMenuItem.Click += transactionToolStripMenuItem_Click;
            // 
            // продажаToolStripMenuItem
            // 
            продажаToolStripMenuItem.Name = "продажаToolStripMenuItem";
            продажаToolStripMenuItem.Size = new Size(180, 22);
            продажаToolStripMenuItem.Text = "Продажа";
            продажаToolStripMenuItem.Click += SellToolStripMenuItem_Click;
            // 
            // отчётыToolStripMenuItem
            // 
            отчётыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { изделияToolStripMenuItem, магазинToolStripMenuItem, заказыToolStripMenuItem });
            отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            отчётыToolStripMenuItem.Size = new Size(60, 25);
            отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // изделияToolStripMenuItem
            // 
            изделияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { списокИзделийToolStripMenuItem, пиццаСИнгридиентамиToolStripMenuItem });
            изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            изделияToolStripMenuItem.Size = new Size(180, 22);
            изделияToolStripMenuItem.Text = "Путевки";
            // 
            // списокИзделийToolStripMenuItem
            // 
            списокИзделийToolStripMenuItem.Name = "списокИзделийToolStripMenuItem";
            списокИзделийToolStripMenuItem.Size = new Size(213, 22);
            списокИзделийToolStripMenuItem.Text = "Список путевок";
            списокИзделийToolStripMenuItem.Click += ComponentsToolStripMenuItem_Click;
            // 
            // пиццаСИнгридиентамиToolStripMenuItem
            // 
            пиццаСИнгридиентамиToolStripMenuItem.Name = "пиццаСИнгридиентамиToolStripMenuItem";
            пиццаСИнгридиентамиToolStripMenuItem.Size = new Size(213, 22);
            пиццаСИнгридиентамиToolStripMenuItem.Text = "Путевка с компонентами";
            пиццаСИнгридиентамиToolStripMenuItem.Click += ComponentTravelToolStripMenuItem_Click;
            // 
            // магазинToolStripMenuItem
            // 
            магазинToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { информацияToolStripMenuItem, загруженностьToolStripMenuItem });
            магазинToolStripMenuItem.Name = "магазинToolStripMenuItem";
            магазинToolStripMenuItem.Size = new Size(180, 22);
            магазинToolStripMenuItem.Text = "Магазин";
            // 
            // информацияToolStripMenuItem
            // 
            информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            информацияToolStripMenuItem.Size = new Size(158, 22);
            информацияToolStripMenuItem.Text = "Информация";
            информацияToolStripMenuItem.Click += InfoToolStripMenuItem_Click;
            // 
            // загруженностьToolStripMenuItem
            // 
            загруженностьToolStripMenuItem.Name = "загруженностьToolStripMenuItem";
            загруженностьToolStripMenuItem.Size = new Size(158, 22);
            загруженностьToolStripMenuItem.Text = "Загруженность";
            загруженностьToolStripMenuItem.Click += BusyShopsToolStripMenuItem_Click;
            // 
            // заказыToolStripMenuItem
            // 
            заказыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { заказыToolStripMenuItem1, заказыПоГруппамToolStripMenuItem });
            заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            заказыToolStripMenuItem.Size = new Size(180, 22);
            заказыToolStripMenuItem.Text = "Заказы";
            // 
            // заказыToolStripMenuItem1
            // 
            заказыToolStripMenuItem1.Name = "заказыToolStripMenuItem1";
            заказыToolStripMenuItem1.Size = new Size(180, 22);
            заказыToolStripMenuItem1.Text = "Заказы";
            заказыToolStripMenuItem1.Click += OrdersToolStripMenuItem_Click;
            // 
            // заказыПоГруппамToolStripMenuItem
            // 
            заказыПоГруппамToolStripMenuItem.Name = "заказыПоГруппамToolStripMenuItem";
            заказыПоГруппамToolStripMenuItem.Size = new Size(180, 22);
            заказыПоГруппамToolStripMenuItem.Text = "Заказы по группам";
            заказыПоГруппамToolStripMenuItem.Click += GroupOrdersToolStripMenuItem_Click;
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
            // отчётыToolStripMenuItem1
            // 
            отчётыToolStripMenuItem1.Name = "отчётыToolStripMenuItem1";
            отчётыToolStripMenuItem1.Size = new Size(180, 22);
            отчётыToolStripMenuItem1.Text = "Отчёты";
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
        private ToolStripMenuItem магазиныToolStripMenuItem;
        private ToolStripMenuItem operationToolStripMenuItem;
        private ToolStripMenuItem transactionToolStripMenuItem;
        private ToolStripMenuItem продажаToolStripMenuItem;
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem изделияToolStripMenuItem;
        private ToolStripMenuItem списокИзделийToolStripMenuItem;
        private ToolStripMenuItem пиццаСИнгридиентамиToolStripMenuItem;
        private ToolStripMenuItem магазинToolStripMenuItem;
        private ToolStripMenuItem информацияToolStripMenuItem;
        private ToolStripMenuItem загруженностьToolStripMenuItem;
        private ToolStripMenuItem заказыToolStripMenuItem;
        private ToolStripMenuItem заказыToolStripMenuItem1;
        private ToolStripMenuItem заказыПоГруппамToolStripMenuItem;
        private ToolStripMenuItem отчётыToolStripMenuItem1;
    }
}