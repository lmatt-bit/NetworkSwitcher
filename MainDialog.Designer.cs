namespace NetworkManagementTool
{
    partial class MainDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.profileBox = new System.Windows.Forms.TextBox();
            this.dhcpCheckBox = new System.Windows.Forms.CheckBox();
            this.profileIpaddress = new System.Windows.Forms.TextBox();
            this.profileMask = new System.Windows.Forms.TextBox();
            this.profileGateway = new System.Windows.Forms.TextBox();
            this.profileMainDNS = new System.Windows.Forms.TextBox();
            this.profileSecondDNS = new System.Windows.Forms.TextBox();
            this.profileList = new System.Windows.Forms.ListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.useButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoStartMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.configMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "IP地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "子网掩码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "网关";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "首选DNS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "备选DNS";
            // 
            // profileBox
            // 
            this.profileBox.Location = new System.Drawing.Point(122, 37);
            this.profileBox.Name = "profileBox";
            this.profileBox.Size = new System.Drawing.Size(132, 21);
            this.profileBox.TabIndex = 0;
            // 
            // dhcpCheckBox
            // 
            this.dhcpCheckBox.AutoSize = true;
            this.dhcpCheckBox.Location = new System.Drawing.Point(39, 85);
            this.dhcpCheckBox.Name = "dhcpCheckBox";
            this.dhcpCheckBox.Size = new System.Drawing.Size(48, 16);
            this.dhcpCheckBox.TabIndex = 1;
            this.dhcpCheckBox.Text = "DHCP";
            this.dhcpCheckBox.UseVisualStyleBackColor = true;
            this.dhcpCheckBox.CheckedChanged += new System.EventHandler(this.onCheckDHCP);
            // 
            // profileIpaddress
            // 
            this.profileIpaddress.Location = new System.Drawing.Point(120, 126);
            this.profileIpaddress.Name = "profileIpaddress";
            this.profileIpaddress.Size = new System.Drawing.Size(134, 21);
            this.profileIpaddress.TabIndex = 2;
            // 
            // profileMask
            // 
            this.profileMask.Location = new System.Drawing.Point(120, 163);
            this.profileMask.Name = "profileMask";
            this.profileMask.Size = new System.Drawing.Size(134, 21);
            this.profileMask.TabIndex = 3;
            // 
            // profileGateway
            // 
            this.profileGateway.Location = new System.Drawing.Point(120, 200);
            this.profileGateway.Name = "profileGateway";
            this.profileGateway.Size = new System.Drawing.Size(134, 21);
            this.profileGateway.TabIndex = 4;
            // 
            // profileMainDNS
            // 
            this.profileMainDNS.Location = new System.Drawing.Point(120, 237);
            this.profileMainDNS.Name = "profileMainDNS";
            this.profileMainDNS.Size = new System.Drawing.Size(134, 21);
            this.profileMainDNS.TabIndex = 5;
            // 
            // profileSecondDNS
            // 
            this.profileSecondDNS.Location = new System.Drawing.Point(120, 274);
            this.profileSecondDNS.Name = "profileSecondDNS";
            this.profileSecondDNS.Size = new System.Drawing.Size(134, 21);
            this.profileSecondDNS.TabIndex = 6;
            // 
            // profileList
            // 
            this.profileList.FormattingEnabled = true;
            this.profileList.ItemHeight = 12;
            this.profileList.Location = new System.Drawing.Point(303, 73);
            this.profileList.Name = "profileList";
            this.profileList.Size = new System.Drawing.Size(167, 220);
            this.profileList.TabIndex = 9;
            this.profileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onLoadButton);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(179, 331);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onSaveButton);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(303, 331);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 10;
            this.loadButton.Text = "载入";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onLoadButton);
            // 
            // useButton
            // 
            this.useButton.Location = new System.Drawing.Point(85, 331);
            this.useButton.Name = "useButton";
            this.useButton.Size = new System.Drawing.Size(75, 23);
            this.useButton.TabIndex = 7;
            this.useButton.Text = "使用";
            this.useButton.UseVisualStyleBackColor = true;
            this.useButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onUseButton);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(395, 331);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 11;
            this.deleteButton.Text = "删除";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onDeleteButton);
            // 
            // notify
            // 
            this.notify.ContextMenuStrip = this.contextMenu;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "网络管理";
            this.notify.Visible = true;
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onDoubleClickTray);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.autoStartMenu,
            this.configMenuItem,
            this.exitMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.ShowCheckMargin = true;
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(153, 114);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.onPopMenu);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openMenuItem.Text = "显示程序";
            this.openMenuItem.Click += new System.EventHandler(this.onShowMenu);
            // 
            // autoStartMenu
            // 
            this.autoStartMenu.Name = "autoStartMenu";
            this.autoStartMenu.Size = new System.Drawing.Size(152, 22);
            this.autoStartMenu.Text = "自启动";
            this.autoStartMenu.Click += new System.EventHandler(this.onClickAutoStartMenu);
            // 
            // configMenuItem
            // 
            this.configMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addConfigMenuItem});
            this.configMenuItem.Name = "configMenuItem";
            this.configMenuItem.Size = new System.Drawing.Size(152, 22);
            this.configMenuItem.Text = "配置列表";
            // 
            // addConfigMenuItem
            // 
            this.addConfigMenuItem.Name = "addConfigMenuItem";
            this.addConfigMenuItem.Size = new System.Drawing.Size(166, 22);
            this.addConfigMenuItem.Text = "添加当前网络配置";
            this.addConfigMenuItem.Click += new System.EventHandler(this.onAddCurrentConfig);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitMenuItem.Text = "退出";
            this.exitMenuItem.Click += new System.EventHandler(this.onExitMenu);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(301, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "配置列表";
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 385);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.useButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.profileList);
            this.Controls.Add(this.profileSecondDNS);
            this.Controls.Add(this.profileMainDNS);
            this.Controls.Add(this.profileGateway);
            this.Controls.Add(this.profileMask);
            this.Controls.Add(this.profileIpaddress);
            this.Controls.Add(this.dhcpCheckBox);
            this.Controls.Add(this.profileBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainDialog";
            this.Text = "网络管理";
            this.Resize += new System.EventHandler(this.onResizeForm);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox profileBox;
        private System.Windows.Forms.CheckBox dhcpCheckBox;
        private System.Windows.Forms.TextBox profileIpaddress;
        private System.Windows.Forms.TextBox profileMask;
        private System.Windows.Forms.TextBox profileGateway;
        private System.Windows.Forms.TextBox profileMainDNS;
        private System.Windows.Forms.TextBox profileSecondDNS;
        private System.Windows.Forms.ListBox profileList;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button useButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addConfigMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoStartMenu;
    }
}

