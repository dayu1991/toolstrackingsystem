using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using log4net;
using service.toolstrackingsystem;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ViewEntity.toolstrackingsystem;
using dbentity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class frmEditUserinfo : Office2007RibbonForm
    {
        ILog logger = log4net.LogManager.GetLogger(typeof(FormLogin));
        private IUserManageService _userManageService;
        private int selectIndex = 0;
        public frmEditUserinfo()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void frmEditUserinfo_Load(object sender, EventArgs e)
        {
            _userManageService = Program.container.Resolve<IUserManageService>() as UserManageService;
            
        }
        //查找用户
        private void Search_buttonX_Click(object sender, EventArgs e)
        {
            string UserCode = UserCode_textBox.Text;
            string UserName = UserName_textBox.Text;

            List<UserInfoEntity> resultEntity = _userManageService.GetUserInfo(UserCode, UserName, 1);

            UserList_dataGridViewX.DataSource = resultEntity;
            for (int i = 0; i < UserList_dataGridViewX.Columns.Count; i++) 
            {
                UserList_dataGridViewX.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            UserList_dataGridViewX.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            UserList_dataGridViewX.Columns[0].HeaderText = "用户编号";
            UserList_dataGridViewX.Columns[1].HeaderText = "用户名称";
            UserList_dataGridViewX.Columns[2].HeaderText = "用户角色";
            UserList_dataGridViewX.Columns[3].HeaderText = "是否有效";
            UserList_dataGridViewX.Columns[4].HeaderText = "说明";
        }
        private void UserList_dataGridViewX_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);  
        }

        private void UserList_dataGridViewX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectIndex = e.RowIndex;
            Sys_User_Info userInfo = new Sys_User_Info();

            userInfo.UserCode = UserList_dataGridViewX.Rows[selectIndex].Cells[0].Value.ToString();
            userInfo.UserName = UserList_dataGridViewX.Rows[selectIndex].Cells[1].Value.ToString();
            userInfo.UserRole = UserList_dataGridViewX.Rows[selectIndex].Cells[2].Value.ToString();
            userInfo.IsActive = UserList_dataGridViewX.Rows[selectIndex].Cells[3].Value.ToString() == "是" ? 1 : 0;
            userInfo.Description = UserList_dataGridViewX.Rows[selectIndex].Cells[4].Value == null ? "" : UserList_dataGridViewX.Rows[selectIndex].Cells[4].Value.ToString();
            userInfo = _userManageService.GetUserInfo(UserList_dataGridViewX.Rows[selectIndex].Cells[0].Value.ToString());
            this.Tag = userInfo;
        }
        /// <summary>
        /// 单击修改用户信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_buttonX_Click(object sender, EventArgs e)
        {
            Sys_User_Info userInfo = (Sys_User_Info)this.Tag;
            if (userInfo != null)
            {
                FrmEditUser formEditUser =  new FrmEditUser();
                formEditUser.Tag = userInfo;
                formEditUser.ShowDialog();
                if (formEditUser.DialogResult == DialogResult.OK)
                {
                    Search_buttonX_Click(sender, e);
                }
            }
            else {
                MessageBox.Show("请选中一个用户");
            }
        }
    }
}
