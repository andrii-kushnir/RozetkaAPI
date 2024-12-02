
namespace RozetkaUI
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._scMain = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this._tcMain = new System.Windows.Forms.TabControl();
            this._tpOrders = new System.Windows.Forms.TabPage();
            this._scOrders = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this._btOrdersForStatus = new System.Windows.Forms.Button();
            this._cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._btOrdersExpand = new System.Windows.Forms.Button();
            this._cbOrderType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._dgvOrders = new System.Windows.Forms.DataGridView();
            this._tpOrder = new System.Windows.Forms.TabPage();
            this._bSendTTN = new System.Windows.Forms.Button();
            this._tbTTN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._cbOrderStatus1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._btChangeStatus = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this._tbId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._tpStatuses = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this._tbStatus = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this._dgvStatuses = new System.Windows.Forms.DataGridView();
            this._tpMessages = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._bSetMessagesCount = new System.Windows.Forms.Button();
            this._bOpenChat = new System.Windows.Forms.Button();
            this._bSetMessagesAnswer = new System.Windows.Forms.Button();
            this._bGetMessagesDeleted = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this._bGetMessagesSeller = new System.Windows.Forms.Button();
            this._bGetMessagesItem = new System.Windows.Forms.Button();
            this._bGetMessagesOrder = new System.Windows.Forms.Button();
            this._dgvMessages = new System.Windows.Forms.DataGridView();
            this._btOrdersForPay = new System.Windows.Forms.Button();
            this._cbPays = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._btOrdersDeliveryRoz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._scMain)).BeginInit();
            this._scMain.Panel1.SuspendLayout();
            this._scMain.Panel2.SuspendLayout();
            this._scMain.SuspendLayout();
            this._tcMain.SuspendLayout();
            this._tpOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._scOrders)).BeginInit();
            this._scOrders.Panel1.SuspendLayout();
            this._scOrders.Panel2.SuspendLayout();
            this._scOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvOrders)).BeginInit();
            this._tpOrder.SuspendLayout();
            this._tpStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvStatuses)).BeginInit();
            this._tpMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Логін";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1169, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Вихід";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _scMain
            // 
            this._scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._scMain.Location = new System.Drawing.Point(0, 0);
            this._scMain.Name = "_scMain";
            this._scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _scMain.Panel1
            // 
            this._scMain.Panel1.Controls.Add(this.textBox1);
            this._scMain.Panel1.Controls.Add(this.button6);
            this._scMain.Panel1.Controls.Add(this.button3);
            this._scMain.Panel1.Controls.Add(this.button1);
            this._scMain.Panel1.Controls.Add(this.button2);
            // 
            // _scMain.Panel2
            // 
            this._scMain.Panel2.Controls.Add(this._tcMain);
            this._scMain.Size = new System.Drawing.Size(1344, 911);
            this._scMain.SplitterDistance = 72;
            this._scMain.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(773, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(591, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(163, 50);
            this.button6.TabIndex = 3;
            this.button6.Text = "Тест";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(318, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "Товар";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // _tcMain
            // 
            this._tcMain.Controls.Add(this._tpOrders);
            this._tcMain.Controls.Add(this._tpOrder);
            this._tcMain.Controls.Add(this._tpStatuses);
            this._tcMain.Controls.Add(this._tpMessages);
            this._tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tcMain.Location = new System.Drawing.Point(0, 0);
            this._tcMain.Name = "_tcMain";
            this._tcMain.SelectedIndex = 0;
            this._tcMain.Size = new System.Drawing.Size(1344, 835);
            this._tcMain.TabIndex = 5;
            // 
            // _tpOrders
            // 
            this._tpOrders.Controls.Add(this._scOrders);
            this._tpOrders.Location = new System.Drawing.Point(4, 22);
            this._tpOrders.Name = "_tpOrders";
            this._tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this._tpOrders.Size = new System.Drawing.Size(1336, 809);
            this._tpOrders.TabIndex = 0;
            this._tpOrders.Text = "Список замовлень";
            this._tpOrders.UseVisualStyleBackColor = true;
            // 
            // _scOrders
            // 
            this._scOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this._scOrders.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._scOrders.Location = new System.Drawing.Point(3, 3);
            this._scOrders.Name = "_scOrders";
            this._scOrders.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _scOrders.Panel1
            // 
            this._scOrders.Panel1.Controls.Add(this._btOrdersDeliveryRoz);
            this._scOrders.Panel1.Controls.Add(this._cbPays);
            this._scOrders.Panel1.Controls.Add(this.label9);
            this._scOrders.Panel1.Controls.Add(this._btOrdersForPay);
            this._scOrders.Panel1.Controls.Add(this.label5);
            this._scOrders.Panel1.Controls.Add(this._btOrdersForStatus);
            this._scOrders.Panel1.Controls.Add(this._cbOrderStatus);
            this._scOrders.Panel1.Controls.Add(this.label3);
            this._scOrders.Panel1.Controls.Add(this._btOrdersExpand);
            this._scOrders.Panel1.Controls.Add(this._cbOrderType);
            this._scOrders.Panel1.Controls.Add(this.label1);
            this._scOrders.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // _scOrders.Panel2
            // 
            this._scOrders.Panel2.Controls.Add(this._dgvOrders);
            this._scOrders.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._scOrders.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._scOrders.Size = new System.Drawing.Size(1330, 803);
            this._scOrders.SplitterDistance = 118;
            this._scOrders.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1246, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Всього: ";
            // 
            // _btOrdersForStatus
            // 
            this._btOrdersForStatus.Location = new System.Drawing.Point(572, 6);
            this._btOrdersForStatus.Name = "_btOrdersForStatus";
            this._btOrdersForStatus.Size = new System.Drawing.Size(193, 50);
            this._btOrdersForStatus.TabIndex = 9;
            this._btOrdersForStatus.Text = "Список замовлень(розширений) по статусу";
            this._btOrdersForStatus.UseVisualStyleBackColor = true;
            this._btOrdersForStatus.Click += new System.EventHandler(this._btOrdersForStatus_Click);
            // 
            // _cbOrderStatus
            // 
            this._cbOrderStatus.FormattingEnabled = true;
            this._cbOrderStatus.Location = new System.Drawing.Point(893, 22);
            this._cbOrderStatus.Name = "_cbOrderStatus";
            this._cbOrderStatus.Size = new System.Drawing.Size(240, 21);
            this._cbOrderStatus.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(783, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Статус замовлень:";
            // 
            // _btOrdersExpand
            // 
            this._btOrdersExpand.Location = new System.Drawing.Point(6, 6);
            this._btOrdersExpand.Name = "_btOrdersExpand";
            this._btOrdersExpand.Size = new System.Drawing.Size(193, 50);
            this._btOrdersExpand.TabIndex = 6;
            this._btOrdersExpand.Text = "Список замовлень(розширений) по типу";
            this._btOrdersExpand.UseVisualStyleBackColor = true;
            this._btOrdersExpand.Click += new System.EventHandler(this._btOrdersExpand_Click);
            // 
            // _cbOrderType
            // 
            this._cbOrderType.FormattingEnabled = true;
            this._cbOrderType.Location = new System.Drawing.Point(311, 22);
            this._cbOrderType.Name = "_cbOrderType";
            this._cbOrderType.Size = new System.Drawing.Size(158, 21);
            this._cbOrderType.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Тип замовлень:";
            // 
            // _dgvOrders
            // 
            this._dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvOrders.Location = new System.Drawing.Point(0, 0);
            this._dgvOrders.Name = "_dgvOrders";
            this._dgvOrders.Size = new System.Drawing.Size(1330, 681);
            this._dgvOrders.TabIndex = 0;
            this._dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dgvOrders_CellDoubleClick);
            // 
            // _tpOrder
            // 
            this._tpOrder.Controls.Add(this._bSendTTN);
            this._tpOrder.Controls.Add(this._tbTTN);
            this._tpOrder.Controls.Add(this.label7);
            this._tpOrder.Controls.Add(this._cbOrderStatus1);
            this._tpOrder.Controls.Add(this.label4);
            this._tpOrder.Controls.Add(this._btChangeStatus);
            this._tpOrder.Controls.Add(this.button4);
            this._tpOrder.Controls.Add(this._tbId);
            this._tpOrder.Controls.Add(this.label2);
            this._tpOrder.Location = new System.Drawing.Point(4, 22);
            this._tpOrder.Name = "_tpOrder";
            this._tpOrder.Padding = new System.Windows.Forms.Padding(3);
            this._tpOrder.Size = new System.Drawing.Size(1336, 613);
            this._tpOrder.TabIndex = 1;
            this._tpOrder.Text = "Пошук замовлення";
            this._tpOrder.UseVisualStyleBackColor = true;
            // 
            // _bSendTTN
            // 
            this._bSendTTN.Location = new System.Drawing.Point(398, 160);
            this._bSendTTN.Name = "_bSendTTN";
            this._bSendTTN.Size = new System.Drawing.Size(160, 50);
            this._bSendTTN.TabIndex = 13;
            this._bSendTTN.Text = "Послати ТТН в Розетку";
            this._bSendTTN.UseVisualStyleBackColor = true;
            this._bSendTTN.Click += new System.EventHandler(this._bSendTTN_Click);
            // 
            // _tbTTN
            // 
            this._tbTTN.Location = new System.Drawing.Point(153, 160);
            this._tbTTN.Name = "_tbTTN";
            this._tbTTN.Size = new System.Drawing.Size(188, 20);
            this._tbTTN.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "TTN:";
            // 
            // _cbOrderStatus1
            // 
            this._cbOrderStatus1.FormattingEnabled = true;
            this._cbOrderStatus1.Location = new System.Drawing.Point(153, 87);
            this._cbOrderStatus1.Name = "_cbOrderStatus1";
            this._cbOrderStatus1.Size = new System.Drawing.Size(188, 21);
            this._cbOrderStatus1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Статус замовлень:";
            // 
            // _btChangeStatus
            // 
            this._btChangeStatus.Location = new System.Drawing.Point(398, 87);
            this._btChangeStatus.Name = "_btChangeStatus";
            this._btChangeStatus.Size = new System.Drawing.Size(160, 50);
            this._btChangeStatus.TabIndex = 6;
            this._btChangeStatus.Text = "Зміна статусу в Розетці";
            this._btChangeStatus.UseVisualStyleBackColor = true;
            this._btChangeStatus.Click += new System.EventHandler(this._btChangeStatus_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(398, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 50);
            this.button4.TabIndex = 5;
            this.button4.Text = "Отримати замовлення";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // _tbId
            // 
            this._tbId.Location = new System.Drawing.Point(153, 17);
            this._tbId.Name = "_tbId";
            this._tbId.Size = new System.Drawing.Size(188, 20);
            this._tbId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Введіть id замовлення:";
            // 
            // _tpStatuses
            // 
            this._tpStatuses.Controls.Add(this.splitContainer1);
            this._tpStatuses.Location = new System.Drawing.Point(4, 22);
            this._tpStatuses.Name = "_tpStatuses";
            this._tpStatuses.Padding = new System.Windows.Forms.Padding(3);
            this._tpStatuses.Size = new System.Drawing.Size(1336, 613);
            this._tpStatuses.TabIndex = 2;
            this._tpStatuses.Text = "     Статуси     ";
            this._tpStatuses.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this._tbStatus);
            this.splitContainer1.Panel1.Controls.Add(this.button5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._dgvStatuses);
            this.splitContainer1.Size = new System.Drawing.Size(1330, 607);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Статус:";
            // 
            // _tbStatus
            // 
            this._tbStatus.Location = new System.Drawing.Point(252, 22);
            this._tbStatus.Name = "_tbStatus";
            this._tbStatus.Size = new System.Drawing.Size(100, 20);
            this._tbStatus.TabIndex = 5;
            this._tbStatus.Text = "0";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(5, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "Статуси";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // _dgvStatuses
            // 
            this._dgvStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvStatuses.Location = new System.Drawing.Point(0, 0);
            this._dgvStatuses.Name = "_dgvStatuses";
            this._dgvStatuses.Size = new System.Drawing.Size(1330, 543);
            this._dgvStatuses.TabIndex = 0;
            // 
            // _tpMessages
            // 
            this._tpMessages.Controls.Add(this.splitContainer2);
            this._tpMessages.Location = new System.Drawing.Point(4, 22);
            this._tpMessages.Name = "_tpMessages";
            this._tpMessages.Padding = new System.Windows.Forms.Padding(3);
            this._tpMessages.Size = new System.Drawing.Size(1336, 613);
            this._tpMessages.TabIndex = 3;
            this._tpMessages.Text = "Переписка з клієнтом";
            this._tpMessages.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this._bSetMessagesCount);
            this.splitContainer2.Panel1.Controls.Add(this._bOpenChat);
            this.splitContainer2.Panel1.Controls.Add(this._bSetMessagesAnswer);
            this.splitContainer2.Panel1.Controls.Add(this._bGetMessagesDeleted);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this._bGetMessagesSeller);
            this.splitContainer2.Panel1.Controls.Add(this._bGetMessagesItem);
            this.splitContainer2.Panel1.Controls.Add(this._bGetMessagesOrder);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._dgvMessages);
            this.splitContainer2.Size = new System.Drawing.Size(1330, 607);
            this.splitContainer2.SplitterDistance = 64;
            this.splitContainer2.TabIndex = 0;
            // 
            // _bSetMessagesCount
            // 
            this._bSetMessagesCount.Location = new System.Drawing.Point(837, 7);
            this._bSetMessagesCount.Name = "_bSetMessagesCount";
            this._bSetMessagesCount.Size = new System.Drawing.Size(160, 50);
            this._bSetMessagesCount.TabIndex = 15;
            this._bSetMessagesCount.Text = "Кількість чатів";
            this._bSetMessagesCount.UseVisualStyleBackColor = true;
            this._bSetMessagesCount.Click += new System.EventHandler(this._bSetMessagesCount_Click);
            // 
            // _bOpenChat
            // 
            this._bOpenChat.Location = new System.Drawing.Point(505, 7);
            this._bOpenChat.Name = "_bOpenChat";
            this._bOpenChat.Size = new System.Drawing.Size(160, 50);
            this._bOpenChat.TabIndex = 14;
            this._bOpenChat.Text = "Відкрити чат";
            this._bOpenChat.UseVisualStyleBackColor = true;
            this._bOpenChat.Click += new System.EventHandler(this._bOpenChat_Click);
            // 
            // _bSetMessagesAnswer
            // 
            this._bSetMessagesAnswer.Location = new System.Drawing.Point(671, 7);
            this._bSetMessagesAnswer.Name = "_bSetMessagesAnswer";
            this._bSetMessagesAnswer.Size = new System.Drawing.Size(160, 50);
            this._bSetMessagesAnswer.TabIndex = 13;
            this._bSetMessagesAnswer.Text = "Відповідь";
            this._bSetMessagesAnswer.UseVisualStyleBackColor = true;
            this._bSetMessagesAnswer.Click += new System.EventHandler(this._bSetMessagesAnswer_Click);
            // 
            // _bGetMessagesDeleted
            // 
            this._bGetMessagesDeleted.Location = new System.Drawing.Point(339, 7);
            this._bGetMessagesDeleted.Name = "_bGetMessagesDeleted";
            this._bGetMessagesDeleted.Size = new System.Drawing.Size(160, 50);
            this._bGetMessagesDeleted.TabIndex = 12;
            this._bGetMessagesDeleted.Text = "Архів";
            this._bGetMessagesDeleted.UseVisualStyleBackColor = true;
            this._bGetMessagesDeleted.Click += new System.EventHandler(this._bGetMessagesDeleted_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1240, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Всього: ";
            // 
            // _bGetMessagesSeller
            // 
            this._bGetMessagesSeller.Location = new System.Drawing.Point(173, 7);
            this._bGetMessagesSeller.Name = "_bGetMessagesSeller";
            this._bGetMessagesSeller.Size = new System.Drawing.Size(160, 50);
            this._bGetMessagesSeller.TabIndex = 7;
            this._bGetMessagesSeller.Text = "Запитання продавцю";
            this._bGetMessagesSeller.UseVisualStyleBackColor = true;
            this._bGetMessagesSeller.Click += new System.EventHandler(this._bGetMessagesSeller_Click);
            // 
            // _bGetMessagesItem
            // 
            this._bGetMessagesItem.Location = new System.Drawing.Point(1057, 7);
            this._bGetMessagesItem.Name = "_bGetMessagesItem";
            this._bGetMessagesItem.Size = new System.Drawing.Size(160, 50);
            this._bGetMessagesItem.TabIndex = 6;
            this._bGetMessagesItem.Text = "Відгуки про товари";
            this._bGetMessagesItem.UseVisualStyleBackColor = true;
            this._bGetMessagesItem.Click += new System.EventHandler(this._bGetMessagesItem_Click);
            // 
            // _bGetMessagesOrder
            // 
            this._bGetMessagesOrder.Location = new System.Drawing.Point(7, 7);
            this._bGetMessagesOrder.Name = "_bGetMessagesOrder";
            this._bGetMessagesOrder.Size = new System.Drawing.Size(160, 50);
            this._bGetMessagesOrder.TabIndex = 5;
            this._bGetMessagesOrder.Text = "Питання про замовлення";
            this._bGetMessagesOrder.UseVisualStyleBackColor = true;
            this._bGetMessagesOrder.Click += new System.EventHandler(this._bGetMessagesOrder_Click);
            // 
            // _dgvMessages
            // 
            this._dgvMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvMessages.Location = new System.Drawing.Point(0, 0);
            this._dgvMessages.Name = "_dgvMessages";
            this._dgvMessages.Size = new System.Drawing.Size(1330, 539);
            this._dgvMessages.TabIndex = 1;
            // 
            // _btOrdersForPay
            // 
            this._btOrdersForPay.Location = new System.Drawing.Point(6, 62);
            this._btOrdersForPay.Name = "_btOrdersForPay";
            this._btOrdersForPay.Size = new System.Drawing.Size(193, 50);
            this._btOrdersForPay.TabIndex = 11;
            this._btOrdersForPay.Text = "Список замовлень по оплаті";
            this._btOrdersForPay.UseVisualStyleBackColor = true;
            this._btOrdersForPay.Click += new System.EventHandler(this._btOrdersForPay_Click);
            // 
            // _cbPays
            // 
            this._cbPays.FormattingEnabled = true;
            this._cbPays.Location = new System.Drawing.Point(311, 78);
            this._cbPays.Name = "_cbPays";
            this._cbPays.Size = new System.Drawing.Size(158, 21);
            this._cbPays.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Оплата:";
            // 
            // _btOrdersDeliveryRoz
            // 
            this._btOrdersDeliveryRoz.Location = new System.Drawing.Point(572, 62);
            this._btOrdersDeliveryRoz.Name = "_btOrdersDeliveryRoz";
            this._btOrdersDeliveryRoz.Size = new System.Drawing.Size(193, 50);
            this._btOrdersDeliveryRoz.TabIndex = 14;
            this._btOrdersDeliveryRoz.Text = "Замовлення доставка Розетка і оплата після отримання";
            this._btOrdersDeliveryRoz.UseVisualStyleBackColor = true;
            this._btOrdersDeliveryRoz.Click += new System.EventHandler(this._btOrdersDeliveryRoz_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 911);
            this.Controls.Add(this._scMain);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._scMain.Panel1.ResumeLayout(false);
            this._scMain.Panel1.PerformLayout();
            this._scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._scMain)).EndInit();
            this._scMain.ResumeLayout(false);
            this._tcMain.ResumeLayout(false);
            this._tpOrders.ResumeLayout(false);
            this._scOrders.Panel1.ResumeLayout(false);
            this._scOrders.Panel1.PerformLayout();
            this._scOrders.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._scOrders)).EndInit();
            this._scOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvOrders)).EndInit();
            this._tpOrder.ResumeLayout(false);
            this._tpOrder.PerformLayout();
            this._tpStatuses.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvStatuses)).EndInit();
            this._tpMessages.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer _scMain;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl _tcMain;
        private System.Windows.Forms.TabPage _tpOrders;
        private System.Windows.Forms.TabPage _tpOrder;
        private System.Windows.Forms.SplitContainer _scOrders;
        private System.Windows.Forms.DataGridView _dgvOrders;
        private System.Windows.Forms.ComboBox _cbOrderType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btOrdersExpand;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox _tbId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btChangeStatus;
        private System.Windows.Forms.Button _btOrdersForStatus;
        private System.Windows.Forms.ComboBox _cbOrderStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _cbOrderStatus1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage _tpStatuses;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView _dgvStatuses;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbStatus;
        private System.Windows.Forms.Button _bSendTTN;
        private System.Windows.Forms.TextBox _tbTTN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage _tpMessages;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button _bGetMessagesOrder;
        private System.Windows.Forms.DataGridView _dgvMessages;
        private System.Windows.Forms.Button _bGetMessagesItem;
        private System.Windows.Forms.Button _bGetMessagesSeller;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button _bGetMessagesDeleted;
        private System.Windows.Forms.Button _bSetMessagesAnswer;
        private System.Windows.Forms.Button _bOpenChat;
        private System.Windows.Forms.Button _bSetMessagesCount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button _btOrdersForPay;
        private System.Windows.Forms.ComboBox _cbPays;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button _btOrdersDeliveryRoz;
    }
}

