using ClsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Data;

namespace ClsBusinessLayer
{
    public class clsPoll_Answers
    {

        enum EMode
        {
            eAddNew, eUpdate
        }
        private EMode _mode;
        public int Poll_AnsID { get; set; }
        public string Text { get; set; }
        public int Poll_ID { get; set; }

        public clsPoll_Answers()
        {
            this.Poll_AnsID = -1;
            this.Text = ""; this.Poll_ID = 0;
            _mode = EMode.eAddNew;
        }

        private clsPoll_Answers(int Poll_AnsID, string Text, int Poll_ID)
        {
            this.Poll_AnsID = Poll_AnsID;
            this.Text = Text;
            this.Poll_ID = Poll_ID;
            _mode = EMode.eUpdate;
        }

        //-----------------****Find*** ---------------------
        public static clsPoll_Answers Find(int Poll_AnsID)
        {
            string Text = "";
            int Poll_ID = 0;
            if (ClsDataAccessPoll_Answers.FindPoll_AnsID(Poll_AnsID, ref Text, ref Poll_ID))
            {
                return new clsPoll_Answers(Poll_AnsID, Text, Poll_ID);
            }
            return null;
        }

        public static clsPoll_Answers FindText(string Text)
        {
            int Poll_AnsID = -1;
            int Poll_ID = -1;
            if (ClsDataAccessPoll_Answers.FindText(ref Poll_AnsID, Text, ref Poll_ID))
            {
                return new clsPoll_Answers(Poll_AnsID, Text, Poll_ID);
            }
            return null;
        }

        //--------------------*** Add New ***------------------
        private bool _AddNewPoll_Answers()
        {

            this.Poll_AnsID = ClsDataAccessPoll_Answers.AddNewPoll_Answers(this.Text, this.Poll_ID);

            return (this.Poll_AnsID <= -1);
        }

        //-------------------*** Update ***-------------------
        private bool _UpdatePoll_Answers()
        {
            return ClsDataAccessPoll_Answers.UpdatePoll_Answers(this.Poll_AnsID, this.Text, this.Poll_ID);
        }

        //-------------------*** Save ***-------------------
        public bool Save()
        {

            switch (_mode)
            {

                case EMode.eAddNew:
                    if (_AddNewPoll_Answers())
                    {
                        _mode = EMode.eUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EMode.eUpdate:
                    return _UpdatePoll_Answers();
            }
            return false;
        }

        //-------------------*** Delete ***-------------------
        public bool DeletePoll_Answers(int Poll_AnsID)
        {

            return ClsDataAccessPoll_Answers.DeletePoll_Answers(Poll_AnsID);

        }

        //-------------------*** Is Exist ***-------------------
        public bool IsExistsPoll_Answers(int Poll_AnsID)
        {
            return ClsDataAccessPoll_Answers.IsExistsPoll_Answers(Poll_AnsID);

        }

        //-----------------*** Get All ***---------------------
        public DataTable GetAllPoll_Answers()
        {

            return ClsDataAccessPoll_Answers.GetAllPoll_Answers();

        }

    }
}
