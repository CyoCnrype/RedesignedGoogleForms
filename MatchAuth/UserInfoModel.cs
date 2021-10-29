using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchAuth
{
    public class UserInfoModel
    {
        #region 帳號下轄參數
        public Guid MgrID { get; set; }
        public string MgrName { get; set; }
        public string MgrPhone { get; set; }
        public string MgrEmail { get; set; }
        public bool MgrStatus { get; set; }
        public byte MgrLevel { get; set; }
        public string MgrAccount { get; set; }
        public string MgrPassword { get; set; }
        #endregion
    }
}
