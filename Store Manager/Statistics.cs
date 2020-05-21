using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Xml;
using System.Windows.Forms;

namespace Store_Manager
{
    public class Statistics
    {
        //Variables
        public static double PriceSum;
        static int TotalItemsSold;
        public static int[] ItemsPerMonth = new int[12];

        //DB access
        static OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Store.accdb");
        static List<string> Products = new List<string>();
        static List<double> Prices = new List<double>();

        //File Statistics
        public static void StatsManager(int Mode) //1 to load and 2 to update
        {
            XmlDocument XmlStats = new XmlDocument();
            XmlStats.Load("..\\..\\Data.xml");
            if (Mode == 1)
            {
                int I = 0;
                foreach (XmlNode N in XmlStats.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode M in N)
                    {
                        ItemsPerMonth[I] = int.Parse(M.InnerText.ToString());
                        I++;
                    }
                }
            }
            if (Mode == 2)
            {
                int I = 0;
                foreach (XmlNode N in XmlStats.DocumentElement.ChildNodes)
                {
                    foreach (XmlNode M in N)
                    {
                        M.InnerText = (ItemsPerMonth[I]).ToString();
                        I++;
                    }
                }

                XmlStats.Save("..\\..\\Data.xml");
                StatsManager(1);
            }
        }

        //File Logger
        public static void Logger(string Str)
        {
            Str = "[" + DateTime.Now + "]:   " + Str;
            XmlDocument XmlLog = new XmlDocument();
            XmlLog.Load("..\\..\\Log.xml");
            XmlNode Action = XmlLog.CreateElement("Action");
            Action.InnerText = Str;
            XmlLog.DocumentElement.AppendChild(Action);
            XmlLog.Save("..\\..\\Log.xml");
        }


        public static void GetData()
        {
            connection.Open();
            OleDbDataReader reader = null;
            OleDbCommand command = new OleDbCommand("SELECT Nom, Prix  FROM  Products", connection);

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Products.Add(reader[0].ToString());
                Prices.Add(double.Parse(reader[1].ToString()));
            }
            connection.Close();
        }

        public static void OnBuy(string Pr)
        {
            GetData();
            int index = 0;
            foreach (string P in Products)
            {
                if (Pr == P)
                    break;
                else
                    index++;
            }
            PriceSum += Prices[index];

            TotalItemsSold++;
            ItemsPerMonth[MonthNum() - 1]++;
        }

        public static void CancelBuy(string Pr)
        {
            GetData();
            int index = 0;
            foreach (string P in Products)
            {
                if (Pr == P)
                    break;
                else
                    index++;
            }
            PriceSum -= Prices[index];
        }

        public static int MonthNum()
        {
            int Month = DateTime.Today.Month;
            return Month;
        }

        public void VendorStats() { }
    }
}
