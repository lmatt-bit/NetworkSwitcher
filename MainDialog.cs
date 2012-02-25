using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace NetworkManagementTool
{
    public partial class MainDialog : Form
    {
        [DllImport("user32")]
        static extern UInt32 SendMessage(IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);
        const uint BCM_SETSHIELD = 0x0000160C;

        private string configFileName = ".\\config.xml";
        private string tempBatchFile = ".\\run.bat";
        private string regName = "NetworkManagementSimplifyTool";
        private List<NetworkConfig> networkconfigs = new List<NetworkConfig>(); 
        public MainDialog()
        {
            Directory.SetCurrentDirectory(Application.StartupPath);//change current dir
            checkConfigFile();
            InitializeComponent();
            setUACShield();
            loadAllConfig();
        }

        private bool isProfileOk()
        {
            if (dhcpCheckBox.Checked && string.IsNullOrEmpty(profileBox.Text) == false) return true;
            if (isValidIpaddress(profileIpaddress.Text) == false) return false;
            if (isValidIpaddress(profileMask.Text) == false) return false;

            if (string.IsNullOrEmpty(profileGateway.Text) == false && isValidIpaddress(profileGateway.Text) == false) return false;
            if (string.IsNullOrEmpty(profileMainDNS.Text) == false && isValidIpaddress(profileMainDNS.Text) == false) return false;
            if (string.IsNullOrEmpty(profileSecondDNS.Text) == false && isValidIpaddress(profileSecondDNS.Text) == false) return false;
            
            return true;
        }

        private void disableManualConfig()
        {

            profileIpaddress.Enabled = false;
            profileMask.Enabled = false;
            profileGateway.Enabled = false;
            profileMainDNS.Enabled = false;
            profileSecondDNS.Enabled = false;
        }

        private void enableManualIPConfig()
        {
            profileIpaddress.Enabled = true;
            profileMask.Enabled = true;
            profileGateway.Enabled = true;
            profileMainDNS.Enabled = true;
            profileSecondDNS.Enabled = true;
        }

        private bool isValidIpaddress(string ip)
        {
            string[] parts = ip.Split('.');
            if (parts.Length == 4)
            {
                bool ok = true;
                for (int i = 0; i < 4 && ok; i++)
                {
                    int temp;
                    bool cs = Int32.TryParse(parts[i], out temp);
                    if (cs && temp >= 0 && temp <= 255) continue;
                    else ok = false;
                }

                return ok;
            }
            return false;
        }

        private void onSaveButton(object sender, MouseEventArgs e)
        {
            string pname = profileBox.Text;
            string pip = profileIpaddress.Text;
            string pmask = profileMask.Text;
            string pgateway = profileGateway.Text;
            string pmaindns = profileMainDNS.Text;
            string pseconddns = profileSecondDNS.Text;
            bool dhcp = dhcpCheckBox.Checked;

            if (isProfileOk())
            {
                NetworkConfig nc = new NetworkConfig(pname, dhcp, pip, pmask, pgateway, pmaindns, pseconddns);
                int find = -1;
                int index = 0;
                foreach (NetworkConfig t in networkconfigs)
                {
                    if (t.name.Equals(pname))
                    {
                        find = index;
                        break;
                    }
                    index++;
                }

                if (find > -1)
                {
                    networkconfigs.RemoveAt(find);
                    networkconfigs.Insert(find, nc);
                }
                else networkconfigs.Add(nc);
                updateAllConfig();
            }
        }

        private void onUseButton(object sender, MouseEventArgs e)
        {
            if (isProfileOk())
            {
                changeNetworkConfig();
            }
            else
            {
                MessageBox.Show("网络配置存在错误!", "错误");
            }
        }

        private void onLoadButton(object sender, MouseEventArgs e)
        {
            if (profileList.SelectedIndex >= 0)
            {
                NetworkConfig nc = networkconfigs.ElementAt(profileList.SelectedIndex);
                updateDisplayConfig(nc);
            }
        }

        private void updateProfileList()
        {
            profileList.Items.Clear();
            configMenuItem.DropDownItems.Clear();
            configMenuItem.DropDownItems.Add(addConfigMenuItem);
            foreach (NetworkConfig nc in networkconfigs)
            {
                profileList.Items.Add(nc.name);
                ToolStripMenuItem pmenu = new ToolStripMenuItem();
                pmenu.Name = nc.name;
                pmenu.Text = nc.name;
                pmenu.Click += new System.EventHandler(this.useConfig);

                configMenuItem.DropDownItems.Add(pmenu);
            }
        }

        private void updateDisplayConfig(NetworkConfig nc)
        {
            profileBox.Text = nc.name;
            dhcpCheckBox.Checked = nc.dhcp;
            profileIpaddress.Text = nc.ip;
            profileMask.Text = nc.mask;
            profileGateway.Text = nc.gateway;
            profileMainDNS.Text = nc.maindns;
            profileSecondDNS.Text = nc.seconddns;
        }


        private void useConfig(object sender, EventArgs e)
        {
            ToolStripMenuItem tm = (ToolStripMenuItem)sender;
            string name = tm.Text;


            foreach (NetworkConfig nc in networkconfigs)
            {
                if (name.Equals(nc.name))
                {
                    updateDisplayConfig(nc);
                    break;
                }
            }

            changeNetworkConfig();
        }

        private bool executeCMD(string commandLine, bool runAsAdmin = false)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            //ps.RedirectStandardOutput = true;
            //ps.RedirectStandardError = true;
            //ps.UseShellExecute = false; if set useshellexecute to false, then cannot use runas.
            ps.CreateNoWindow = true;
            string[] cs = commandLine.Split(new char[]{' '}, 2);
            ps.FileName = cs[0];
            if(cs.Length > 1)
                ps.Arguments = cs[1];
            if (runAsAdmin && System.Environment.OSVersion.Version.Major >= 6)
            {
                ps.Verb = "runas";
            }

            try
            {
                Process proc = Process.Start(ps);
                //string so = proc.StandardOutput.ReadToEnd();
                //string se = proc.StandardError.ReadToEnd();
                proc.WaitForExit();
            }
            catch (Win32Exception)
            {
                return false;
            }
            return true;
        }

        private bool generateBatch()
        {
            string networkInf = "本地连接";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(tempBatchFile, false, Encoding.Default))
            {

                if (dhcpCheckBox.Checked)
                {
                    file.WriteLine("netsh interface ip set address \"" + networkInf + "\" dhcp");
                    file.WriteLine("netsh interface ip set dns \"" + networkInf + "\" dhcp");
                }
                else
                {
                    if (string.IsNullOrEmpty(profileGateway.Text))
                    {
                        file.WriteLine("netsh interface ip set address \"" + networkInf + "\" static " + profileIpaddress.Text
                                  + " " + profileMask.Text);
                    }
                    else
                    {
                        file.WriteLine("netsh interface ip set address \"" + networkInf + "\" static " + profileIpaddress.Text
                                  + " " + profileMask.Text + " " + profileGateway.Text + " 1");
                    }

                    if (string.IsNullOrEmpty(profileMainDNS.Text))
                    {
                        file.WriteLine("netsh interface ip set dns \"" + networkInf + "\" static none");
                    }
                    else
                    {
                        file.WriteLine("netsh interface ip set dns \"" + networkInf + "\" static " + profileMainDNS.Text);
                        if (!string.IsNullOrEmpty(profileSecondDNS.Text))
                        {
                            file.WriteLine("netsh interface ip add dns \"" + networkInf + "\" " + profileSecondDNS.Text);
                        }
                    }
                }
            }
            return true;
        }

        private bool changeNetworkConfig()
        {
            if (isProfileOk() && generateBatch())
            {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;

                if (executeCMD(tempBatchFile, true))
                {
                    MessageBox.Show("网络配置修改成功", "消息");
                }
                else
                {
                    MessageBox.Show("网络配置修改失败", "错误");
                }
            }
            else
            {
                MessageBox.Show("配置存在错误！", "错误");
            }
            return true;
        }

        private void checkConfigFile()
        {
            if (File.Exists(configFileName) == false)
            {
                FileStream fs = File.Create(configFileName);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("<config></config>");
                sw.Close();
                fs.Close();
            }
        }

        private bool updateAllConfig()
        {
            FileStream fs = File.Create(configFileName);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<config>");
            foreach (NetworkConfig nc in networkconfigs)
            {
                sw.Write(nc.toXMLString());
            }
            sw.WriteLine("</config>");
            sw.Close();
            fs.Close();

            updateProfileList();

            return true;
        }

        private bool loadAllConfig()
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(configFileName);
                XmlElement root = xd.DocumentElement;

                XmlNodeList ps = root.GetElementsByTagName("profile");

                networkconfigs.Clear();
                foreach(XmlElement prof in ps)
                {
                    string pname = prof.GetAttribute("name");
                    XmlNodeList pp = prof.GetElementsByTagName("dhcp");
                    string pip = "";
                    string pmask = "";
                    string pgateway = "";
                    string pmaindns = "";
                    string pseconddns = "";
                    bool dhcp = true;
                    if (pp.Count == 0)
                    {
                        pip = prof.GetElementsByTagName("ip").Item(0).FirstChild.Value;
                        pmask = prof.GetElementsByTagName("mask").Item(0).FirstChild.Value;
                        XmlNode temp = prof.GetElementsByTagName("gateway").Item(0).FirstChild;
                        pgateway = temp != null ? temp.Value : "";
                        temp = prof.GetElementsByTagName("maindns").Item(0).FirstChild;
                        pmaindns = temp != null ? temp.Value : "";
                        temp = prof.GetElementsByTagName("seconddns").Item(0).FirstChild;
                        pseconddns = temp != null ? temp.Value : "";
                        dhcp = false;
                    }

                    networkconfigs.Add(new NetworkConfig(pname, dhcp, pip, pmask, pgateway, pmaindns, pseconddns));
                }

                updateProfileList();
            }
            catch (Exception ex)
            {
                //
                return false;
            }
            return true;
        }

        private void onCheckDHCP(object sender, EventArgs e)
        {
            if (dhcpCheckBox.Checked)
            {
                disableManualConfig();
            }
            else
            {
                enableManualIPConfig();
            }
        }

        private void onDeleteButton(object sender, MouseEventArgs e)
        {
            if (profileList.SelectedIndex > -1)
            {
                if (MessageBox.Show("确定删除", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    networkconfigs.RemoveAt(profileList.SelectedIndex);
                    updateProfileList();
                }
            }
        }

        private void onResizeForm(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notify.BalloonTipTitle = "最小化";
                notify.BalloonTipText = "程序已最小化到系统托盘";
                notify.ShowBalloonTip(200);
            }
        }

        private void onDoubleClickTray(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void onExitMenu(object sender, EventArgs e)
        {
            notify.Dispose();
            Application.Exit();
        }

        private void onShowMenu(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void onAddCurrentConfig(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void setUACShield()
        {  
            WindowsPrincipal pri = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (!pri.IsInRole(WindowsBuiltInRole.Administrator))
            {
                useButton.FlatStyle = FlatStyle.System;
                SendMessage(useButton.Handle, BCM_SETSHIELD, 0, 1);
            }
        }

        private bool isAutoStart()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp.GetValue(regName) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void setAtuoStart(bool start)
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (start)
            {
                rkApp.SetValue(regName, Application.ExecutablePath);
            }
            else
            {
                rkApp.DeleteValue(regName, false);
            }
        }

        private void onClickAutoStartMenu(object sender, EventArgs e)
        {
            if (isAutoStart())
            {
                setAtuoStart(false);
            }
            else
            {
                setAtuoStart(true);
            }
        }

        private void onPopMenu(object sender, CancelEventArgs e)
        {
            if (isAutoStart())
            {
                autoStartMenu.Checked = true;
            }
            else
            {
                autoStartMenu.Checked = false;
            }
        }
    }
    public class NetworkConfig
    {
        public string name;
        public bool dhcp;
        public string ip;
        public string mask;
        public string gateway;
        public string maindns;
        public string seconddns;

        public NetworkConfig(string name, bool dhcp, string ip, string mask, string gateway, string maindns, string seconddns)
        {
            this.name = name;
            this.dhcp = dhcp;
            this.ip = ip;
            this.mask = mask;
            this.gateway = gateway;
            this.maindns = maindns;
            this.seconddns = seconddns;
        }

        public string toXMLString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<profile name=\"{0}\">\n", name);
            if (dhcp)
            {
                sb.Append("<dhcp>true</dhcp>\n");
            }
            else
            {
                sb.AppendFormat("<ip>{0}</ip>\n", ip);
                sb.AppendFormat("<mask>{0}</mask>\n", mask);
                sb.AppendFormat("<gateway>{0}</gateway>\n", gateway);
                sb.AppendFormat("<maindns>{0}</maindns>\n", maindns);
                sb.AppendFormat("<seconddns>{0}</seconddns>\n", seconddns);
            }

            sb.Append("</profile>\n");
            return sb.ToString();
        }
    }



}
