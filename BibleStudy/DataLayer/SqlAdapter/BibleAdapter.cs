using BibleStudy.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BibleStudy.DataLayer.SqlAdapter
{
    public class BibleAdapter
    {
        private static readonly string CONTENT = "content";
        private static readonly string DAY = "WEEK_DAY";
        private static readonly string NAME = "name";
        private static readonly string PHOTO = "photo";
        private static readonly string THINKING = "thinking";
        private static readonly string IMAGE_PATH = "path";
        public static List<BibleContent> getBible()
        {
            string sqlStr = "SELECT  B_CONTENT AS content, B.WEEK_DAY, IMAGE_PATH as path  FROM BIBLE_CONTENT B WHERE B.B_DATE IN (@DAY1,@DAY2,@DAY3,@DAY4,@DAY5,@DAY6)";
            List<string> thisWeek = getThisWeek();
            SqlParameter day1 = new SqlParameter("@DAY1", thisWeek[0]);
            SqlParameter day2 = new SqlParameter("@DAY2", thisWeek[1]);
            SqlParameter day3 = new SqlParameter("@DAY3", thisWeek[2]);
            SqlParameter day4 = new SqlParameter("@DAY4", thisWeek[3]);
            SqlParameter day5 = new SqlParameter("@DAY5", thisWeek[4]);
            SqlParameter day6 = new SqlParameter("@DAY6", thisWeek[5]);
            SqlParameter[] paras = { day1, day2, day3, day4, day5,day6 };
            DataTableCollection tables =  SqlHelper.GetTableText(sqlStr, paras);
            DataTable table = tables[0];
            List<BibleContent> results = new List<BibleContent>();
            for(int i = 0;i<table.Rows.Count;i++)
            {
                BibleContent content = new BibleContent();
                DataRow row = table.Rows[i];
                content.content = row[CONTENT] as string;
                content.dateWeek = Convert.ToInt32(row[DAY]);
                content.imagePath = Convert.ToString(row[IMAGE_PATH]);
                results.Add(content);
            }
            return results;
        }
        public static List<PriestInfo> getPriest()
        {
            string sqlStr = "SELECT  UB.NICK_NAME AS name, UB.PHOTO AS photo, T.THINK_CONTENT AS thinking FROM BIBLE_THINKING T,USER_BASIC_INFO UB WHERE (T.UID=UB.UID)";
            DataTableCollection tables = SqlHelper.GetTableText(sqlStr, null);
            DataTable table = tables[0];
            List<PriestInfo> results = new List<PriestInfo>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                PriestInfo content = new PriestInfo();
                DataRow row = table.Rows[i];
                content.name = row[NAME] as string;
                content.photoPath = row[PHOTO] as string;
                content.thinking = row[THINKING] as string;
                results.Add(content);
            }
            return results;
        }
        private static List<string> getThisWeek()
        {
            DateTime today = DateTime.Now;
            int weekday = (int)today.DayOfWeek;
            List<DateTime> weekList = new List<DateTime>();
            List<string> result = new List<string>();
            for (int i = 0;i<weekday;i++)
            {
                DateTime dt = today.AddDays(0 - i);
                weekList.Add(dt);
            }
            for (int i = weekday+1; i < 7; i++)
            {
                DateTime dt = today.AddDays(i-weekday);
                weekList.Add(dt);
            }
            foreach(DateTime dt in weekList)
            {
                string dateStr = dt.ToString("yyyy-MM-dd");
                result.Add(dateStr);
            }
            return result;
        }
    }
}