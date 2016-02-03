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
        private static readonly string DAY = "WEEKDAY";
        private static readonly string NAME = "name";
        private static readonly string PHOTO = "photo";
        private static readonly string THINKING = "thinking";
        private static readonly string IMAGE_PATH = "path";
        public static List<BibleContent> getBible()
        {
            string sqlStr = "SELECT  B_CONTENT AS content, WEEK_DAY, IMAGE_PATH as path  FROM BIBLECONTENT B, CURRENT_BIBLE C WHERE (B.BID=C.CID)";
            DataTableCollection tables =  SqlHelper.GetTableText(sqlStr, null);
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
            string sqlStr = "SELECT  U.NICK_NAME AS name, U.PHOTO AS photo, T.THINK_CONTENT AS thinking FROM USERS U,THINK T WHERE (U.IS_ADMIN= true AND T.UID=U.UID)";
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
            }
            return results;
        }
    }
}