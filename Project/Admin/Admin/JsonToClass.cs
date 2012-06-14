using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Admin
{
    class JsonToClasses
    {
        private List<ItemListClass> listViewItems;
        public JsonToClasses()
        {}
        public bool JsonToItemListClass(string jstr)  //从Json到一个ItemListClass构成的List
        {
            listViewItems = new List<ItemListClass>();
            JsonReader reader = new JsonTextReader(new StringReader(jstr));
 
            while (reader.Read())
            {
                //Console.WriteLine(reader.ValueType + "\t\t" + reader.Value);
                if (reader.Value.Equals("ItemListClass")) //读入一个个ItemListClass
                {
                    reader.Read();
                    ItemListClass item = new ItemListClass();
                    item = (ItemListClass)reader.Value;
                }
            }
            
            return true;
        }
    }
}
