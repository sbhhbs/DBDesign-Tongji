using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;

namespace crazy
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //    }
    //}

    public class StationNode
    {
        public StationNode(string sname)
        {
            this.name = sname;
            this.lines = new HashSet<LineInfo>();
        }
        public StationNode(StationNode sn)
        {
            this.name = sn.name;
            this.lines = sn.lines;
        }

        public string name;
        public HashSet<LineInfo> lines;
    }

    public struct LSPair
    {
        public LineInfo line;
        public string station;
        public LSPair(ref LineInfo line, string station)
        {
            this.line = line;
            this.station = station;
        }

    }

    public enum COLOR { BLACK, GRAY, WHITE };

    public class LineInfo
    {
        public LineInfo(string name)
        {
            this.name = name;
            this.reachable_line = new HashSet<LSPair>();
            this.color = COLOR.WHITE;
        }
        public COLOR color;
        public string name;
        public HashSet<LSPair> reachable_line;
    }

    class RouteQuery
    {
        private static float fuzzyaccuracy = 0.5f;
        private static int DFScontrol = 4;
        private static int maxquerycount = 5;

        private bool isDataInitialized;
        private LineInfo[] lin  = new LineInfo[11];
        private List<StationNode> station_collection;
        private List<LineInfo> lineinfo;
        private string[,] station_sequence;
        private HashSet<LineInfo> des_collection;
        private string destination;
        private string[,] result;
        private List<string> eleven_1 = new List<string>();
        private List<string> eleven_2 = new List<string>();

        public RouteQuery()
        {
            isDataInitialized = false;
            station_collection = new List<StationNode>();
            lineinfo = new List<LineInfo>();
            station_sequence = new string[11, 32];   //11表示11条地铁，31表示一条线中最大的站数
            des_collection = new HashSet<LineInfo>();
            destination = null;
            result = null;
            for (int i = 0; i < 11; i++)
            {
                lin[i] = new LineInfo((i+1).ToString());
            }
            eleven_1.Add("嘉定北");
            eleven_1.Add("嘉定西");
            eleven_1.Add("白银路");
            eleven_2.Add("安亭");
            eleven_2.Add("上海汽车城");
            eleven_2.Add("昌吉东路");
            eleven_2.Add("上海赛车场");

        }

        /*
         * 这个函数用以从数据库中查询出全部站点数据,强烈建议在程序初始化时候调用
         */
        public bool InitData()
        {
            if (isDataInitialized)
            {
                return false;
            }
            //SQL connection here

            //SQL query here

            //SQL release connection here
            //all not done yet

            //这是直接query belongs_To的部分




            //FileStream fs;
            //for (int i = 1; i <= 11; i++)
            //{
            //    fs = new FileStream("C:\\Users\\fog\\Desktop\\belongs_To\\belongs_To\\" + i.ToString() + ".txt", FileMode.Open, FileAccess.Read);
            //    StreamReader r = new StreamReader(fs);
            //    String temp;
            //    while ((temp = r.ReadLine()) != null)
            //    {
            //        String[] assets = temp.Split(' ');
            //        station_sequence[int.Parse(assets[1]) - 1, int.Parse(assets[2])] = assets[0];       //[,]中前一个是地铁线路，要数字，后面一个就是后来加的站的顺序，asset[0]要换成站名；
            //    }
            //}



            Station station = new Station(SQLSERVER.sqlstring);
            Line line = new Line(SQLSERVER.sqlstring);
            SqlDataReader myreader = line.set_line(); //= belongsto.read();

            int station_id, line1_id, line2_id,line_id,position;
            string station_name;
            while (myreader.Read())
            {
                line1_id = int.Parse(myreader["first"].ToString());
                line2_id = int.Parse(myreader["second"].ToString());
                station_id = int.Parse(myreader["station_id"].ToString());
                station_name = station.get_station_name(station_id);

                SetUpAll(line1_id,line2_id,station_name,1);
                //System.Console.WriteLine(line1_id + "   " + line2_id + "  " + station_name);
            }

            myreader.Close();
            myreader = line.set_line(); 
            while (myreader.Read())
            {
                line1_id = int.Parse(myreader["first"].ToString());
                line2_id = int.Parse(myreader["second"].ToString());
                station_id = int.Parse(myreader["station_id"].ToString());
                station_name = station.get_station_name(station_id);
                SetUpAll(line1_id,line2_id,station_name,2);
               // System.Console.WriteLine(line1_id + "   " + line2_id + "  " + station_name);
            }
            myreader.Close();
            line = new Line(SQLSERVER.sqlstring);
            myreader = line.set_single_station();

            while (myreader.Read())
            {
                line1_id = int.Parse(myreader["line_id"].ToString());
                station_id = int.Parse(myreader["station_id"].ToString());
                station_name = station.get_station_name(station_id);
                StationNode sn = new StationNode(station_name);
                sn.lines.Add(lin[line1_id - 1]);
                station_collection.Add(sn);
              //  System.Console.Write(myreader["station_id"].ToString() + "  ");
              //  System.Console.Write(myreader["line_id"].ToString() + "  ");
               // System.Console.WriteLine();
            }

            myreader.Close();

            BelongsTo belongsto = new BelongsTo(SQLSERVER.sqlstring);
            myreader = belongsto.read();
            while (myreader.Read())
            {
                line_id = int.Parse(myreader["line_id"].ToString());
                station_id = int.Parse(myreader["station_id"].ToString());
                station_name = station.get_station_name(station_id);
                position = int.Parse(myreader["position"].ToString());
                station_sequence[line_id-1, position] = station_name;
            }
            myreader.Close();

            for (int i = 0; i < 11; i++)
            {
                lineinfo.Add(lin[i]);
            }


            //myreader.Close();


            //SqlDataReader myreader2 = line.set_line2(); //= belongsto.read();
            //while (myreader2.Read())
            //{
            //    line1_id = int.Parse(myreader2["first"].ToString());
            //    line2_id = int.Parse(myreader2["second"].ToString());
            //    System.Console.WriteLine(line1_id + "   " + line2_id);
            //}
            //myreader2.Close();
            line.con.Close();

            //对线路进行query
            //query结果格式应为[line1,line2],[line1,line3],[line2,line1],[line2,line4]...这样，然后转进lineinfo
            //LineInfo[] li = new LineInfo[11];
            

            //对站名进行query
            //query结果格式应为[station_name1,line1],[station_name1,line2],[station_name2,line1]...这样，然后转进station_collection
            //这部分还是写sql语句来实现更方便，下个部分同
 

            
            isDataInitialized = true;
            return true;
        }

        /*
         *  这个函数用以模糊查询站名
         */
        public List<StationNode> FuzzySearch(string station_name)
        {
            List<StationNode> result = new List<StationNode>();
            foreach (StationNode sn in station_collection)
            {
                if (StringCompare(station_name, sn.name))
                    result.Add(sn);
            }
            return result;
        }


        private void SetUpAll(int line1, int line2, String name, int a)
        {
            if (a == 1)
            {
                LSPair ls1 = new LSPair(ref lin[line1 - 1], name);
                LSPair ls2 = new LSPair(ref lin[line2 - 1], name);
                //if (!li[line1 - 1].reachable_line.Contains(ls2))
                bool flag = false;
                foreach (LSPair ls in lin[line1 - 1].reachable_line)
                {
                    if (ls.station == name && ls.line.name == line1.ToString())
                    {
                        lin[line1 - 1].reachable_line.Remove(ls);
                        lin[line1 - 1].reachable_line.Add(ls2);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    lin[line1 - 1].reachable_line.Add(ls2);
                flag = false;
                foreach (LSPair ls in lin[line2 - 1].reachable_line)
                {
                    if (ls.station == name && ls.line.name == line2.ToString())
                    {
                        lin[line2 - 1].reachable_line.Remove(ls);
                        lin[line2 - 1].reachable_line.Add(ls1);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                    lin[line2 - 1].reachable_line.Add(ls1);
            }
            if (a == 2)
            {
                StationNode sn = GetStation(name);
                if (sn == null)
                {
                    sn = new StationNode(name);
                    sn.lines.Add(lin[line1 - 1]);
                    sn.lines.Add(lin[line2 - 1]);
                    station_collection.Add(sn);
                }
                else
                {
                    HashSet<LineInfo> t = new HashSet<LineInfo>();
                    t.Add(lin[line1 - 1]);
                    t.Add(lin[line2 - 1]);
                    sn.lines.UnionWith(t);
                }
            }
        }


        /*
         * 查询具体路线就用这个函数
         */
        public List<string> Query(string depature, string destination)
        {
            this.GetRoute(depature, destination);
            List<string> route = new List<string>();

            if (eleven_1.Contains(depature) && eleven_2.Contains(destination))
            {
                route.Add(depature);
                bool flag = false;
                foreach (string str in eleven_1)
                {
                    if (flag)
                        route.Add(str);
                    if (str == depature)
                    {
                        flag = true;
                    }
                }
                route.Add("嘉定新城");
                flag = false;
                for (int i = eleven_2.Count; i > eleven_2.IndexOf(destination); i--)
                {
                    route.Add(eleven_2[i-1]);
                }
                return route;
            }
            else if (eleven_2.Contains(depature) && eleven_1.Contains(destination))
            {
                bool flag = false;
                foreach (string str in eleven_2)
                {
                    if (flag)
                        route.Add(str);
                    if (str == depature)
                    {
                        flag = true;
                        route.Add(depature);
                    }
                }
                route.Add("嘉定新城");
                flag = false;
                for (int i = eleven_1.Count; i > eleven_1.IndexOf(destination); i--)
                {
                    route.Add(eleven_1[i - 1]);
                }
                return route;
            }


            int min = 10;
            int c = 0;
            for (int i = 0; i < maxquerycount; i++)
            {
                for (int j = 0; j < DFScontrol; j++)
                {
                    if (result[i, j] == null)
                        break;
                    if (result[i, j] == null && j > 1 && j < min)
                    {
                        min = j;
                        c = i;
                    }
                }
            }
            for (int i = 0; i < DFScontrol; i++)
            {
                if (result[c, i + 1] == null)
                    break;
                string[] assets1 = result[c, i].Split('@');
                string[] assets2 = result[c, i + 1].Split('@');
                if (assets1[0] == assets2[0])
                    continue;
                addstation(route, int.Parse(assets1[1]), assets1[0], assets2[0]);
            }
            route.Add(destination);
            return route;
        }

        private void addstation(List<string> route, int line, string from, string to)
        {
            int f = 0, t = 0;
            for (int i = 0; i < 32; i++)
            {
                if (station_sequence[line - 1, i] == from)
                {
                    f = i;
                }
                else if (station_sequence[line - 1, i] == to)
                {
                    t = i;
                }
            }
            if (f > t)
            {
                for (int i = f; i > t; i--)
                {
                    if (station_sequence[line-1,i]=="嘉定新城" && eleven_2.Contains(destination) )
                    {
                        route.Add("嘉定新城");
                        i-=3;
                        continue;
                    }
                    if (station_sequence[line - 1, i] == destination)
                        break;
                    route.Add(station_sequence[line - 1, i]);
                }
            }
            else
            {
                for (int i = f; i < t; i++)
                {
                    if (station_sequence[line - 1, i] == destination)
                        break;
                    if (station_sequence[line-1,i]=="上海赛车场" )
                    {
                        route.Add("上海赛车场");
                        i+=3;
                        continue;
                    }
                    route.Add(station_sequence[line - 1, i]);
                }
            }
        }

        private void GetRoute(string depature, string destination)
        {
            des_collection.Clear();
            result = new string[maxquerycount, DFScontrol+2];
            this.destination = destination;
            StationNode dep = GetStation(depature);
            StationNode des = GetStation(destination);
            if (dep == null || des == null)
            {
                return;// null;
            }
            foreach (LineInfo li in lineinfo)
            {
                li.color = COLOR.WHITE;
                foreach (LSPair ls in li.reachable_line)
                {
                    ls.line.color = COLOR.WHITE;
                }
            }
            HashSet<LineInfo> dep_collection = dep.lines;
            des_collection = des.lines;

            //用最深深度为DFScontrol的DFS
            int count = 0;
            foreach (LineInfo li in dep_collection)
            {
                if (li.color == COLOR.WHITE)
                {
                    if(DFSGetRoute(li, count, 0))
                        result[count, 0] = dep.name + "@" + li.name;
                    //foreach(LineInfo li2 in dep_collection)
                    //{
                    //    string[] temp =result[count,1].Split('@');
                    //    if(temp[1]==li2.name)
                    //        result[count, 0] = dep.name + "@" + li2.name;
                    //}

                    
                }
                if (count >= maxquerycount)
                {
                    break;
                }
                count++;
            }
            //return result;
        }

        private bool DFSGetRoute(LineInfo current, int count, int depth)
        {
            if (depth >= DFScontrol )
            {
                return false;
            }
            if(des_collection.Contains(current))
            {
                result[count,depth+1]=destination+"@"+current.name;
                return true;
            }

            foreach (LSPair ls in current.reachable_line)
            {
                if (des_collection.Contains(ls.line))
                {
                    result[count, depth + 1] = ls.station + "@" + ls.line.name;
                    result[count, depth + 2] = destination + "@" + ls.line.name;
                    return true;
                }
            }
            current.color = COLOR.GRAY;
            bool flag = false;
            int c = 0;
            foreach (LSPair li in current.reachable_line)
            {
                if (li.line.color == COLOR.WHITE)
                {
                    flag = DFSGetRoute(li.line, count, depth + 1);
                    if (flag)
                    {
                        c++;
                        result[count, depth+1] = li.station + "@" + li.line.name;
                    }
                }
            }
            current.color = COLOR.BLACK;
            return c>0?true:false;
        }
        /*
         * 类中的fuzzyaccuracy可以设置这个算法的精度。
         */
        private bool StringCompare(string str, string comparedstr)
        {
            int len = str.Length;
            int percent = 0;
            while (len > 0)
            {
                if (comparedstr.Contains(str.Substring(len - 1, len - 1)))
                    percent++;
                len--;
            }
            if (((float)percent / str.Length) >= fuzzyaccuracy)       //这里可以设置比较精度，测试的时候注意。
                return true;
            else return false;
        }

        public StationNode GetStation(string station_name)
        {
            //StationNode s = null;
            foreach (StationNode sn in station_collection)
            {
                if (sn.name == station_name)
                {
                    return sn;
                }
            }
            return null;
        }
    }
}
