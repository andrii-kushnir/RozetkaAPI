
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
            this.button5 = new System.Windows.Forms.Button();
            this._tcMain = new System.Windows.Forms.TabControl();
            this._tpOrders = new System.Windows.Forms.TabPage();
            this._scOrders = new System.Windows.Forms.SplitContainer();
            this._btOrdersForStatus = new System.Windows.Forms.Button();
            this._cbOrderStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._btOrdersExpand = new System.Windows.Forms.Button();
            this._cbOrderType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._dgvOrders = new System.Windows.Forms.DataGridView();
            this._tpOrder = new System.Windows.Forms.TabPage();
            this._cbOrderStatus1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._btChangeStatus = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this._tbId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._tpStatuses = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._dgvStatuses = new System.Windows.Forms.DataGridView();
            this._tbStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._tbTTN = new System.Windows.Forms.TextBox();
            this._bSendTTN = new System.Windows.Forms.Button();
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
            this._scMain.Panel1.Controls.Add(this.button1);
            this._scMain.Panel1.Controls.Add(this.button2);
            // 
            // _scMain.Panel2
            // 
            this._scMain.Panel2.Controls.Add(this._tcMain);
            this._scMain.Size = new System.Drawing.Size(1344, 715);
            this._scMain.SplitterDistance = 72;
            this._scMain.TabIndex = 5;
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
            // _tcMain
            // 
            this._tcMain.Controls.Add(this._tpOrders);
            this._tcMain.Controls.Add(this._tpOrder);
            this._tcMain.Controls.Add(this._tpStatuses);
            this._tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tcMain.Location = new System.Drawing.Point(0, 0);
            this._tcMain.Name = "_tcMain";
            this._tcMain.SelectedIndex = 0;
            this._tcMain.Size = new System.Drawing.Size(1344, 639);
            this._tcMain.TabIndex = 5;
            // 
            // _tpOrders
            // 
            this._tpOrders.Controls.Add(this._scOrders);
            this._tpOrders.Location = new System.Drawing.Point(4, 22);
            this._tpOrders.Name = "_tpOrders";
            this._tpOrders.Padding = new System.Windows.Forms.Padding(3);
            this._tpOrders.Size = new System.Drawing.Size(1336, 613);
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
            this._scOrders.Size = new System.Drawing.Size(1330, 607);
            this._scOrders.SplitterDistance = 63;
            this._scOrders.TabIndex = 0;
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
            this._cbOrderStatus.Size = new System.Drawing.Size(158, 21);
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
            this._dgvOrders.Size = new System.Drawing.Size(1330, 540);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1246, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Всього: ";
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
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 0;
            // 
            // _dgvStatuses
            // 
            this._dgvStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvStatuses.Location = new System.Drawing.Point(0, 0);
            this._dgvStatuses.Name = "_dgvStatuses";
            this._dgvStatuses.Size = new System.Drawing.Size(1330, 542);
            this._dgvStatuses.TabIndex = 0;
            // 
            // _tbStatus
            // 
            this._tbStatus.Location = new System.Drawing.Point(252, 22);
            this._tbStatus.Name = "_tbStatus";
            this._tbStatus.Size = new System.Drawing.Size(100, 20);
            this._tbStatus.TabIndex = 5;
            this._tbStatus.Text = "0";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "TTN:";
            // 
            // _tbTTN
            // 
            this._tbTTN.Location = new System.Drawing.Point(153, 160);
            this._tbTTN.Name = "_tbTTN";
            this._tbTTN.Size = new System.Drawing.Size(188, 20);
            this._tbTTN.TabIndex = 12;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 715);
            this.Controls.Add(this._scMain);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._scMain.Panel1.ResumeLayout(false);
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
    }
}

