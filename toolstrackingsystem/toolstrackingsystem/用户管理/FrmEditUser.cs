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
using ViewEntity.toolstrackingsystem;

namespace toolstrackingsystem
{
    public partial class FrmEditUser : Office2007Form
    {
        public FrmEditUser()
        {
            InitializeComponent();
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            #region 初始化角色combox

            #endregion
            UserInfoEntity userInfo = (UserInfoEntity)this.Tag;
            UserCode_textBox.Text = userInfo.UserCode;
            UserName_textBox.Text = userInfo.UserName;
            Description_textBox.Text = userInfo.Description;

        }
    }
}
