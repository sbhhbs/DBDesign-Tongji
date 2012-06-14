using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin
{

   

    class Utility
    { 
          public static string[] actions = new string[]{"获取信息","充值","获取出行记录","挂失","更改类型"};
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

    class ManagermentAction1
    {
        int manager_id;

        public int Manager_id
        {
            get { return manager_id; }
            set { manager_id = value; }
        }
     

	    private int card_id;

        public int Card_id
        {
            get { return card_id; }
            set { card_id = value; }
        }

        int action;

        public int Action
        {
            get { return action; }
            set { action = value; }
        }

        string action_time;

        public string Action_time
        {
            get { return action_time; }
            set { action_time = value; }
        }

        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        float money;

        public float Money
        {
            get { return money; }
            set { money = value; }
        }

        public ManagermentAction1(int manager_id, int card_id, int action,
        string action_time,
        string description,
        float money)
        {
            this.manager_id = manager_id;
            this.card_id = card_id;
            this.action = action;
            this.action_time = action_time;
            this.description = description;
            this.money = money;
        }
    }


    public class TripRecord1
    {
        int trip_records_id;

        public int Trip_records_id
        {
            get { return trip_records_id; }
            set { trip_records_id = value; }
        }
        DateTime start_time;

        public DateTime Start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }
        DateTime end_time;

        public DateTime End_time
        {
            get { return end_time; }
            set { end_time = value; }
        }
        string start_station_name;

        public string Start_station_name
        {
            get { return start_station_name; }
            set { start_station_name = value; }
        }
        string end_startion_name;

        public string End_startion_name
        {
            get { return end_startion_name; }
            set { end_startion_name = value; }
        }
        int card_id;

        public int Card_id
        {
            get { return card_id; }
            set { card_id = value; }
        }
        int discounted;

        public int Discounted
        {
            get { return discounted; }
            set { discounted = value; }
        }
        int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }


        public TripRecord1(int trip_records_id,
        DateTime start_time,
        DateTime end_time,
        string start_station_name,
        string end_startion_name,
        int card_id,
        int discounted,
        int price)
        {
            this.trip_records_id = trip_records_id;
            this.start_time = start_time;
            this.end_time = end_time;
            this.start_station_name = start_station_name;
            this.end_startion_name = end_startion_name;
            this.card_id = card_id;
            this.discounted = discounted;
            this.price = price;
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
