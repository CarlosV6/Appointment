using HelperData;
using HelperModels;
using HelperSerialize;
using System.Data;

namespace HelperBusiness
{
    public class BsUserManagement: InterfaceMessage
    {
        private DataUserManagement _DataUserManagement = new DataUserManagement();
        public BsUserManagement()
        {
        }
        public string ProcessMessage(string messageInPut)
        {
            string messageoutput = string.Empty;
            try
            {
                dataModelProcess _dataModelProcess = (dataModelProcess)messageInPut.Deserialize(typeof(dataModelProcess))!;
                if (_dataModelProcess.operation == EnumOperationProcess.Consult)
                {
                    if (_dataModelProcess.metod == EnunMetodProcess.GetUserProfile)
                    {
                        messageoutput = GetUserProfile(_dataModelProcess);
                    }
                    if (_dataModelProcess.metod == EnunMetodProcess.GetSystemUsers)
                    {
                        messageoutput = GetSystemUsers(_dataModelProcess);
                    }
                    if (_dataModelProcess.metod == EnunMetodProcess.GetUserProfileSystemUsers)
                    {
                        messageoutput = GetUserProfileSystemUsers(_dataModelProcess);
                    }
                }
                else if (_dataModelProcess.operation == EnumOperationProcess.Insert)
                {
                    if (_dataModelProcess.metod == EnunMetodProcess.InsertTblUserProfile)
                    {
                        messageoutput = InsertTblUserProfile(_dataModelProcess);
                    }
                    else if (_dataModelProcess.metod == EnunMetodProcess.InsertTblSystemUsers)
                    {
                        messageoutput = InsertTblSystemUsers(_dataModelProcess);
                    }
                }
                else if (_dataModelProcess.operation == EnumOperationProcess.Update)
                {
                    if (_dataModelProcess.metod == EnunMetodProcess.UpdateTblUserProfile)
                    {
                        messageoutput = UpdateTblUserProfile(_dataModelProcess);
                    }
                    else if (_dataModelProcess.metod == EnunMetodProcess.UpdateTblSystemUsers)
                    {
                        messageoutput = UpdateTblSystemUsers(_dataModelProcess);
                    }
                }
                else if (_dataModelProcess.operation == EnumOperationProcess.Delete)
                {
                    if (_dataModelProcess.metod == EnunMetodProcess.DeleteTblUserProfile)
                    {
                        messageoutput = DeleteTblUserProfile(_dataModelProcess);
                    }
                    else if (_dataModelProcess.metod == EnunMetodProcess.DeleteTblSystemUsers)
                    {
                        messageoutput = DeleteTblSystemUsers(_dataModelProcess);
                    }
                }
            }
            catch
            {
                throw;
            }

            return messageoutput;
        }
        private string GetUserProfile(dataModelProcess _dataModelProcess)
        {
            List<tblUserprofiledata> _tblUserprofiledata = (List<tblUserprofiledata>)(from d in _DataUserManagement.GetUserProfile().AsEnumerable()
                                                                                      select (new tblUserprofiledata
                                                                                      {
                                                                                          IdSUserProfile = d["IdSUserProfile"].ToString() ?? "",
                                                                                          UserProfile = d["UserProfile"].ToString() ?? ""
                                                                                      })).ToList();
            tblUserProfile _tblUserProfile = new tblUserProfile();
            _tblUserProfile.operation = _dataModelProcess.operation;
            _tblUserProfile.metod = _dataModelProcess.metod;

            if (_tblUserprofiledata.Count > 0)
                _tblUserProfile.message = "Success GetUserProfile";
            else
                _tblUserProfile.message = "Fail GetUserProfile";

            foreach (tblUserprofiledata data in _tblUserprofiledata)
            {
                _tblUserProfile.tblUserProfileData.Add(data);
            }

            return _tblUserProfile.SerializeText() ?? "";
        }
        private string GetSystemUsers(dataModelProcess _dataModelProcess)
        {
            List<tblSystemUsersData> _tblSystemUsersData = (List<tblSystemUsersData>)(from d in _DataUserManagement.GetSystemUsers().AsEnumerable()
                                                                          select (new tblSystemUsersData
                                                                          {
                                                                              IdSystemUsers = d["IdSystemUsers"].ToString() ?? "",
                                                                              IdSUserProfile = d["IdSUserProfile"].ToString() ?? "",
                                                                              SystemUsers = d["SystemUsers"].ToString() ?? "",
                                                                              SystemUsersPass = d["SystemUsersPass"].ToString() ?? "",
                                                                              SitSystemUsers = d["SitSystemUsers"].ToString() ?? ""
                                                                          })).ToList();
            tblSystemUsers _tblSystemUsers = new tblSystemUsers();
            _tblSystemUsers.operation = _dataModelProcess.operation;
            _tblSystemUsers.metod = _dataModelProcess.metod;

            if (_tblSystemUsersData.Count > 0)
                _tblSystemUsers.message = "Success GetSystemUsers";
            else
                _tblSystemUsers.message = "Fail GetSystemUsers";

            foreach (tblSystemUsersData data in _tblSystemUsersData)
            {
                _tblSystemUsers.tblSystemUsersData.Add(data);
            }

            return _tblSystemUsers.SerializeText() ?? "";
        }
        private string GetUserProfileSystemUsers(dataModelProcess _dataModelProcess)
        {
            List<tblUserProfileSystemUsersData> _tblUserProfileSystemUsersData = (List<tblUserProfileSystemUsersData>)(from d in _DataUserManagement.GetUserProfileSystemUsers().AsEnumerable()
                                                                                                                       select (new tblUserProfileSystemUsersData
                                                                                                                       {
                                                                                                                           IdSUserProfile = d["IdSUserProfile"].ToString() ?? "",
                                                                                                                           UserProfile = d["UserProfile"].ToString() ?? "",
                                                                                                                           IdSystemUsers = d["IdSystemUsers"].ToString() ?? "",
                                                                                                                           SystemUsers = d["SystemUsers"].ToString() ?? "",
                                                                                                                           SystemUsersPass = d["SystemUsersPass"].ToString() ?? "",
                                                                                                                           SitSystemUsers = d["SitSystemUsers"].ToString() ?? ""
                                                                                                                       })).ToList();
            tblUserProfileSystemUsers _tblUserProfileSystemUsers = new tblUserProfileSystemUsers();
            _tblUserProfileSystemUsers.operation = _dataModelProcess.operation;
            _tblUserProfileSystemUsers.metod = _dataModelProcess.metod;
            
            if (_tblUserProfileSystemUsersData.Count > 0)
                _tblUserProfileSystemUsers.message = "Success GetUserProfileSystemUsers";
            else
                _tblUserProfileSystemUsers.message = "Fail GetUserProfileSystemUsers";

            foreach (tblUserProfileSystemUsersData data in _tblUserProfileSystemUsersData)
            {
                _tblUserProfileSystemUsers.tblUserProfileSystemUsersData.Add(data);
            }

            return _tblUserProfileSystemUsers.SerializeText() ?? "";
        }
        private string InsertTblUserProfile(dataModelProcess _dataModelProcess)
        {
            tblUserprofiledata _tblUserprofiledata = (tblUserprofiledata)_dataModelProcess.data.Deserialize(typeof(tblUserprofiledata))!;
            tblUserProfile _tblUserProfile = new tblUserProfile();
            _tblUserProfile.operation = _dataModelProcess.operation;
            _tblUserProfile.metod = _dataModelProcess.metod;
            _tblUserProfile.message = _DataUserManagement.InsertTblUserProfile(_tblUserprofiledata);
            return _tblUserProfile.SerializeText() ?? "";
        }
        private string InsertTblSystemUsers(dataModelProcess _dataModelProcess)
        {
            tblSystemUsersData _tblSystemUsersData = (tblSystemUsersData)_dataModelProcess.data.Deserialize(typeof(tblSystemUsersData))!;
            tblSystemUsers _tblSystemUsers = new tblSystemUsers();
            _tblSystemUsers.operation = _dataModelProcess.operation;
            _tblSystemUsers.message = _DataUserManagement.InsertTblSystemUsers(_tblSystemUsersData);
            return _tblSystemUsers.SerializeText() ?? "";
        }
        private string UpdateTblUserProfile(dataModelProcess _dataModelProcess)
        {
            tblUserprofiledata _tblUserprofiledata = (tblUserprofiledata)_dataModelProcess.data.Deserialize(typeof(tblUserprofiledata))!;
            tblUserProfile _tblUserProfile = new tblUserProfile();
            _tblUserProfile.operation = _dataModelProcess.operation;
            _tblUserProfile.metod = _dataModelProcess.metod;
            _tblUserProfile.message = _DataUserManagement.UpdateTblUserProfile(_tblUserprofiledata);
            return _tblUserProfile.SerializeText() ?? "";
        }
        private string UpdateTblSystemUsers(dataModelProcess _dataModelProcess)
        {
            tblSystemUsersData _tblSystemUsersData = (tblSystemUsersData)_dataModelProcess.data.Deserialize(typeof(tblSystemUsersData))!;
            tblSystemUsers _tblSystemUsers = new tblSystemUsers();
            _tblSystemUsers.operation = _dataModelProcess.operation;
            _tblSystemUsers.message = _DataUserManagement.UpdateTblSystemUsers(_tblSystemUsersData);
            return _tblSystemUsers.SerializeText() ?? "";
        }
        private string DeleteTblUserProfile(dataModelProcess _dataModelProcess)
        {
            tblUserprofiledata _tblUserprofiledata = (tblUserprofiledata)_dataModelProcess.data.Deserialize(typeof(tblUserprofiledata))!;
            tblUserProfile _tblUserProfile = new tblUserProfile();
            _tblUserProfile.operation = _dataModelProcess.operation;
            _tblUserProfile.metod = _dataModelProcess.metod;
            _tblUserProfile.message = _DataUserManagement.DeleteTblUserProfile(_tblUserprofiledata);
            return _tblUserProfile.SerializeText() ?? "";
        }
        private string DeleteTblSystemUsers(dataModelProcess _dataModelProcess)
        {
            tblSystemUsersData _tblSystemUsersData = (tblSystemUsersData)_dataModelProcess.data.Deserialize(typeof(tblSystemUsersData))!;
            tblSystemUsers _tblSystemUsers = new tblSystemUsers();
            _tblSystemUsers.operation = _dataModelProcess.operation;
            _tblSystemUsers.message = _DataUserManagement.DeleteTblSystemUsers(_tblSystemUsersData);
            return _tblSystemUsers.SerializeText() ?? "";
        }
    }
}
