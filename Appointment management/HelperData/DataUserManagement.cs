using HelperModels;
using HelperSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperData
{
    public class DataUserManagement()
    {
        private readonly ExecSQL _ExecSQL = new ExecSQL();
        public DataTable GetProfile()
        {
            DataTable dt = new DataTable();
            string sql = String.Empty;

            try
            {
                sql = @$"SELECT up.IdSUserProfile,
                                up.UserProfile
                         FROM tblUserProfile up";
                dt = _ExecSQL.RunScript(sql);
            }
            catch
            {
                throw;
            }

            return dt;
        }
        public DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            string sql = String.Empty;

            try
            {
                sql = @$"SELECT su.SitSystemUsers,
                                su.SystemUsers,
                                su.SystemUsersPass,
                                su.SitSystemUsers
                         FROM tblSystemUsers su ";
                dt = _ExecSQL.RunScript(sql);
            }
            catch
            {
                throw;
            }

            return dt;
        }
        public DataTable GetProfileUser()
        {
            DataTable dt = new DataTable();
            string sql = String.Empty;

            try
            {
                sql = @$"SELECT up.IdSUserProfile,
                                up.UserProfile,
                                su.SitSystemUsers,
                                su.SystemUsers,
                                su.SystemUsersPass,
                                su.SitSystemUsers
                         FROM tblUserProfile up 
                         INNER JOIN tblSystemUsers su 
                         ON up.IdSUserProfile = su.IdSUserProfile";
                dt =  _ExecSQL.RunScript(sql);
            }
            catch
            {
                throw;
            }

            return dt;
        }
    }
}
