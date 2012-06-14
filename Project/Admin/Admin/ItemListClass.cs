using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Admin
{
    class ItemListClass
    {
        private String datetime;

        public System.String Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }
        private String cardID;
        public System.String CardID
        {
            get { return cardID; }
            set { cardID = value; }
        }
        private String type;
        public System.String Type
        {
            get { return type; }
            set { type = value; }
        }
        private String money;
        public System.String Money
        {
            get { return money; }
            set { money = value; }
        }
        private String description;
        public System.String Description
        {
            get { return description; }
            set { description = value; }
        }
        public ItemListClass()
        {}

        public ItemListClass(ItemListClass anotherItemListClass)  //复制构造函数
        {
            datetime = anotherItemListClass.datetime;
            cardID = anotherItemListClass.cardID;
            money = anotherItemListClass.money;
            type = anotherItemListClass.type;
            description = anotherItemListClass.description;
        }
    }
}
