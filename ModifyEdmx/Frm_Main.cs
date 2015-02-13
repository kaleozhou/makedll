using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml;
namespace ModifyEdmx
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btnFromFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Edmx files (*.edmx)|*.edmx";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtOldEdmx.Text = openFileDialog1.FileName;
        }

        private void btnFromSave_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Edmx files (*.edmx)|*.edmx";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.FileName = txtOldEdmx.Text.Substring(txtOldEdmx.Text.LastIndexOf("\\") + 1);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtNewEdmx.Text = saveFileDialog1.FileName;
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            Info model = new Info();
            model.ServerIP = txtServerIP.Text;
            model.BaseName = txtDataBase.Text;
            model.UserName = txtUser.Text;
            model.Pwd = txtPwd.Text;
            model.OldPath = txtOldEdmx.Text;
            model.NewPath = txtNewEdmx.Text;
            Tool.WriteTxt(Tool.AppPath + "info.dat", JsonConvert.SerializeObject(model));
            ConnectData.StaticServerIP = model.ServerIP;
            ConnectData.StaticDataName = model.BaseName;
            ConnectData.StaticUserName = model.UserName;
            ConnectData.StaticPwd = model.Pwd;
            ConnectData mydata = GetConnect.GetConn();
            string Content = Tool.ReadTxt(txtOldEdmx.Text);
            string[] tableList = Tool.GetArray(Tool.GetBody(Content, " <edmx:ConceptualModels>((.|\\\n)+?)</edmx:ConceptualModels>"), "(<EntityType(.|\\\n)+?</EntityType>)");
            List<string> tempList = new List<string>();
            foreach (var item in tableList)
            {
                string tableName = Tool.GetBody(item,"<EntityType Name=\"(.+?)\">");
                if (tempList.Contains(tableName))
                {
                    continue;                  
                }
                tempList.Add(tableName);
                string KeyStr=Tool.GetBody(item,"(<Key(.|\\\n)+?</Key>)");
                string[] FeildList = Tool.GetArray(item, "(<Property .+?>)");
                string NewStr = "<EntityType Name=\"" + tableName + "\">";
                string intro = GetTableSummany(tableName, mydata);
                if (!string.IsNullOrEmpty(intro))
                {
                    NewStr = NewStr + "\r\n\t" + " <Documentation>\r\n\t\t<Summary>" + intro + "</Summary>\r\n\t</Documentation>";
                }
                NewStr = NewStr+"\r\n\t"+KeyStr;
                foreach (var subitem in FeildList)
                {
                    string feildname = Tool.GetBody(subitem, "<Property Name=\"(.+?)\"");
                    intro = GetFeildSummany(tableName, feildname, mydata);
                    if (!string.IsNullOrEmpty(intro))
                    {
                        NewStr = NewStr + "\r\n\t" + subitem.Replace("/>", ">");
                        NewStr = NewStr + "\r\n\t" + " <Documentation>\r\n\t\t<Summary>" + intro + "</Summary>\r\n\t</Documentation>\r\n</Property>";
                    }
                    else
                    {
                        NewStr = NewStr + "\r\n\t" + subitem;
                    }
                }
                string otherProp = Tool.GetBody(item, FeildList[FeildList.Count()-1] + "((.|\\\n)+?)</EntityType>");
                NewStr = NewStr+otherProp + "\r\n" + "</EntityType>";
                Content = Content.Replace(item, NewStr);
            }
            Tool.WriteTxt(txtNewEdmx.Text, Content, "utf-8");
            MessageBox.Show("转换成功！");
            btnOk.Enabled = true;
        }
        public string GetTableSummany(string tableName,ConnectData mydata)
        {
            
            return mydata.GetData("SELECT [value] FROM fn_listextendedproperty ('MS_Description', 'schema', 'dbo','table','"+tableName+"',null, null)");
        }
        public string GetFeildSummany(string tableName,string feilename, ConnectData mydata)        {

            return mydata.GetData("SELECT [value] FROM fn_listextendedproperty ('MS_Description','schema', 'dbo','table', '"+tableName+"','column', '"+feilename+"')");
        }
        private void Frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                string Content = Tool.ReadTxt(Tool.AppPath + "info.dat");
                Info model = JsonConvert.DeserializeObject<Info>(Content);
                txtServerIP.Text = model.ServerIP;
                txtDataBase.Text = model.BaseName;
                txtUser.Text = model.UserName;
                txtPwd.Text = model.Pwd;
                txtOldEdmx.Text = model.OldPath;
                txtNewEdmx.Text = model.NewPath;
                MODEL.Salary newmode = new MODEL.Salary();
            }
            catch (Exception)
            {
                
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ConnectSql mydata=new ConnectSql();
            MessageBox.Show(mydata.TestOpen(txtServerIP.Text, txtDataBase.Text, txtUser.Text, txtPwd.Text));
        }
    }
    [Serializable]
    public class Info
    {
        public string ServerIP { get; set; }
        public string BaseName { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string  OldPath { get; set; }
        public string  NewPath { get; set; }
    }
}
