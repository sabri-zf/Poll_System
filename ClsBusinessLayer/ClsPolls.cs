using ClsBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClsDataAccessLayer;
using System.Data;

namespace ClsBusinessLayer
{
    public class ClsPolls
    {

        enum EMode
        {
            eAddNew, eUpdate
        }

        private EMode _mode;
        public int Poll_ID { get; set; }
        public string Title { get; set; }
        public int UserID { get; set; }

        public ClsPolls()
        {
            this.Poll_ID = -1;
            this.Title = ""; this.UserID = 0;
            _mode = EMode.eAddNew;
        }

        private ClsPolls(int Poll_Id, string Title, int UserID)
        {
            this.Poll_ID = Poll_Id;
            this.Title = Title;
            this.UserID = UserID;
            _mode = EMode.eUpdate;
        }

        //-----------------****Find*** ---------------------
        public static ClsPolls Find(int Poll_ID)
        {
            string Title = "";
            int UserID = 0;
            if (ClsDataAccessPolls.FindPoll_ID(Poll_ID, ref Title, ref UserID))
            {
                return new ClsPolls(Poll_ID, Title, UserID);
            }
            return null;
        }
        //--------------------*** Add New ***------------------
        private bool _AddNewPolls()
        {

            this.Poll_ID = ClsDataAccessPolls.AddNewPolls(this.Title, this.UserID);


            return (this.Poll_ID <= -1);
        }

        //-------------------*** Update ***-------------------
        private bool _UpdatePolls()
        {
            return ClsDataAccessPolls.UpdatePolls(this.Poll_ID, this.Title, this.UserID);
        }

        //-------------------*** Save ***-------------------
        public bool Save()
        {

            switch (_mode)
            {

                case EMode.eAddNew:
                    if (_AddNewPolls())
                    {
                        _mode = EMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EMode.eUpdate:
                    return _UpdatePolls();
            }
            return false;
        }

        //-------------------*** Delete ***-------------------
        public bool DeletePolls(int Poll_ID)
        {

            return ClsDataAccessPolls.DeletePolls(Poll_ID);

        }

        //-------------------*** Is Exist ***-------------------
        public bool IsExistsPolls(int Poll_ID)
        {
            return ClsDataAccessPolls.IsExistsPolls(Poll_ID);

        }

        //-----------------*** Get All ***---------------------
        public static DataTable GetAllPolls()
        {

            return ClsDataAccessPolls.GetAllPolls();

        }

    }
}
