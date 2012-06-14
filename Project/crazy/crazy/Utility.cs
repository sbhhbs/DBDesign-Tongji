using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crazy
{
    class Utility
    {
    }

    class CardInfo
    {
        string cardID;

        public string CardID
        {
            get { return cardID; }
            set { cardID = value; }
        }
        string balance;

        public string Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        string missing;

        public string Missing
        {
            get { return missing; }
            set { missing = value; }
        }
        string validateTime;

        public string ValidateTime
        {
            get { return validateTime; }
            set { validateTime = value; }
        }
        string cardType;

        public string CardType
        {
            get { return cardType; }
            set { cardType = value; }
        }
        string recentTripID;

        public string RecentTripID
        {
            get { return recentTripID; }
            set { recentTripID = value; }
        }
        string userID;

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        string cardValue;

        public string CardValue
        {
            get { return cardValue; }
            set { cardValue = value; }
        }
        string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }

    }

    public class UserInfo
    {
        string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        string birthday;

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        string telephone;

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        string staffId;

        public string StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }
        string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        string workStartTime;

        public string WorkStartTime
        {
            get { return workStartTime; }
            set { workStartTime = value; }
        }
        string emergencyTel;

        public string EmergencyTel
        {
            get { return emergencyTel; }
            set { emergencyTel = value; }
        }
    }
}
