using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClsDataAccessLayer;

namespace ClsBusinessLayer
{
    public class clsUsers
    {
        enum EMode
        {
            eAddNew, eUpdate
        }
        private EMode _mode;
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public clsUsers()
        {
            this.UserID = -1;
            this.Email = "";
            this.Password = "";
            _mode = EMode.eAddNew;
        }

        protected clsUsers(int UserID, string Email, string Password)
        {
            this.UserID = UserID;
            this.Email = Email; this.Password = Password;
            _mode = EMode.eUpdate;
        }

        //-----------------****Find*** ---------------------
        public static clsUsers Find(int UserID)
        {
            string Email = "";
            string Password = "";
            if (ClsDataAccessUsers.FindUserID(UserID, ref Email, ref Password))
            {
                return new clsUsers(UserID, Email, Password);
            }
            return null;
        }

        public static clsUsers FindByEmail(string Email)
        {
            int UserID = -1;
            string Password = "";
            if (ClsDataAccessUsers.FindUserByEmail(ref UserID, Email, ref Password))
            {
                return new clsUsers(UserID, Email, Password);
            }
            return null;
        }

        //--------------------*** Add New ***------------------
        private bool _AddNewUsers()
        {
            this.UserID = ClsDataAccessUsers.AddNewUsers(this.Email, this.Password);


            return (this.UserID <= -1);
        }

        //-------------------*** Update ***-------------------
        private bool _UpdateUsers()
        {
            return ClsDataAccessUsers.UpdateUsers(this.UserID, this.Email, this.Password);
        }

        //-------------------*** Save ***-------------------
        public bool Save()
        {

            switch (_mode)
            {

                case EMode.eAddNew:
                    if (_AddNewUsers())
                    {
                        _mode = EMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EMode.eUpdate:
                    return _UpdateUsers();
            }
            return false;
        }

        //-------------------*** Delete ***-------------------
        public bool DeleteUsers(int UserID)
        {

            return ClsDataAccessUsers.DeleteUsers(UserID);

        }

        //-------------------*** Is Exist ***-------------------
        public bool IsExistsUsers(int UserID)
        {
            return ClsDataAccessUsers.IsExistsUsers(UserID);

        }

        //-----------------*** Get All ***---------------------
        public static DataTable GetAllUsers()
        {

            return ClsDataAccessUsers.GetAllUsers();

        }



    }
}
