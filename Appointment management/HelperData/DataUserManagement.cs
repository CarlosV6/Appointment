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
        public DataTable GetUserProfile()
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
        public DataTable GetSystemUsers()
        {
            DataTable dt = new DataTable();
            string sql = String.Empty;

            try
            {
                sql = @$"SELECT su.IdSystemUsers,
                                su.IdSUserProfile,
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
        public DataTable GetUserProfileSystemUsers()
        {
            DataTable dt = new DataTable();
            string sql = String.Empty;

            try
            {
                sql = @$"SELECT up.IdSUserProfile, 
                                up.UserProfile, 
	                            su.IdSystemUsers,
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
        public string InsertTblUserProfile(tblUserprofiledata _tblUserprofiledata)
        {
            string sql = String.Empty;
            string messsageOutPut = String.Empty;  
            try
            {
                sql = @$"INSERT INTO tblUserProfile VALUES('{_tblUserprofiledata.UserProfile}')";
                _ExecSQL.RunScript(sql);
                messsageOutPut = "Insert Success in tblUserProfile";
            }
            catch
            {
                messsageOutPut = "Insert Fail in tblUserProfile";
                throw;
            }
            return messsageOutPut;
        }
        public string InsertTblSystemUsers(tblSystemUsersData _tblSystemUsersData)
        {
            string sql = String.Empty;
            string messsageOutPut = String.Empty;
            try
            {
                sql = @$"INSERT INTO tblSystemUsers VALUES({_tblSystemUsersData.IdSUserProfile},'{_tblSystemUsersData.SystemUsers}','{_tblSystemUsersData.SystemUsersPass}',{_tblSystemUsersData.SitSystemUsers})";
                _ExecSQL.RunScript(sql);
                messsageOutPut = "Insert Success in tblSystemUsers";
            }
            catch
            {
                messsageOutPut = "Insert Fail in tblSystemUsers";
                throw;
            }
            return messsageOutPut;
        }
        public string UpdateTblUserProfile(tblUserprofiledata _tblUserprofiledata)
        {
            string sql = String.Empty;
            string messsageOutPut = String.Empty;
            try
            {
                sql = @$"UPDATE tblUserProfile
                         SET    UserProfile = '{_tblUserprofiledata.UserProfile}'
                         WHERE  NOT IdSUserProfile IN (1,2,3)
                         AND    IdSUserProfile = {_tblUserprofiledata.IdSUserProfile}";
                _ExecSQL.RunScript(sql);
                messsageOutPut = "Update Success in tblUserProfile";
            }
            catch
            {
                messsageOutPut = "Update Fail in tblUserProfile";
                throw;
            }
            return messsageOutPut;
        }
        public string UpdateTblSystemUsers(tblSystemUsersData _tblSystemUsersData)
        {
            string sql = String.Empty;
            string messsageOutPut = String.Empty;
            try
            {
                sql = @$"UPDATE tblSystemUsers
                         SET    IdSUserProfile = {_tblSystemUsersData.IdSUserProfile},
                                SystemUsers = '{_tblSystemUsersData.SystemUsers}',
                                SystemUsersPass = '{_tblSystemUsersData.SystemUsersPass}',
                                SitSystemUsers = {_tblSystemUsersData.SitSystemUsers}
                         WHERE  IdSystemUsers = {_tblSystemUsersData.IdSystemUsers}";
                _ExecSQL.RunScript(sql);
                messsageOutPut = "Update Success in tblSystemUsers";
            }
            catch
            {
                messsageOutPut = "Update Fail in tblSystemUsers";
                throw;
            }
            return messsageOutPut;
        }
        public string DeleteTblUserProfile(tblUserprofiledata _tblUserprofiledata)
        {
            string sql = String.Empty;
            string messsageOutPut = String.Empty;
            try
            {
                sql = @$"DELETE tblUserProfile
                         WHERE  NOT IdSUserProfile IN (1,2,3)
                         AND    IdSUserProfile = {_tblUserprofiledata.IdSUserProfile}";
                _ExecSQL.RunScript(sql);
                messsageOutPut = "Delete Success in tblUserProfile";
            }
            catch
            {
                messsageOutPut = "Delete Fail in tblUserProfile";
                throw;
            }
            return messsageOutPut;
        }
        public string DeleteTblSystemUsers(tblSystemUsersData _tblSystemUsersData)
        {
            string sql = String.Empty;
            string messsageOutPut = String.Empty;
            try
            {
                sql = @$"DELETE tblSystemUsers
                         WHERE  IdSystemUsers = {_tblSystemUsersData.IdSystemUsers}";
                _ExecSQL.RunScript(sql);
                messsageOutPut = "Delete Success in tblSystemUsers";
            }
            catch
            {
                messsageOutPut = "Delete Fail in tblSystemUsers";
                throw;
            }
            return messsageOutPut;
        }
    }
}
