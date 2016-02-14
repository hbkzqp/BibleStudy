using BibleStudy.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BibleStudy.DataLayer.SqlAdapter
{
    public class BibleAdminAdapter
    {
        public static void AddBible(string date, string image,string content)
        {
            DateTime bibleDate = Convert.ToDateTime(date);
            int day = (int)bibleDate.DayOfWeek;
            if(day==0)
            {
                day = 6;
            }
            List<SqlCommand> cmdList = new List<SqlCommand>();
            //string deleteSql = "delete from CURRENT_BIBLE WHERE WEEK_DAY = @Day";
            string insertSql  = "insert into BIBLE_CONTENT (B_CONTENT, WEEK_DAY,IMAGE_PATH,B_DATE) values(@Content,@Day,@Path,@Date)";
            //string insertCurrentSql = "insert into CURRENT_BIBLE SELECT BID, WEEK_DAY FROM BIBLE_CONTENT WHERE B_DATE=@Date";
            //上条语句中直接在sql语句中写添加的参数名,不论参数类型都是如此.
            SqlParameter Content  = new SqlParameter("@Content", content);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            SqlParameter Day = new SqlParameter("@Day", day);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            //SqlParameter Day1 = new SqlParameter("@Day", day);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            SqlParameter Path = new SqlParameter("@Path", image);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            SqlParameter Date = new SqlParameter("@Date", date);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            //SqlParameter Date1 = new SqlParameter("@Date", date);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            //SqlCommand cleanCmd = new SqlCommand();
            //cleanCmd.CommandText = deleteSql;
            //cleanCmd.Parameters.Add(Day);
            //cmdList.Add(cleanCmd);
            
            SqlCommand insertCmd = new SqlCommand();
            insertCmd.CommandText = insertSql;
            SqlParameter[] insertParas = { Content, Day, Path, Date };
            SqlHelper.ExecteNonQueryText(insertSql, insertParas);
            //insertCmd.Parameters.AddRange(insertParas);
            //cmdList.Add(insertCmd);
            //SqlCommand insertCurrentCmd = new SqlCommand();
            //insertCurrentCmd.CommandText = insertCurrentSql;
            //insertCurrentCmd.Parameters.Add(Date1);
            //cmdList.Add(insertCurrentCmd);
            //SqlHelper.executeByTrancaction(cmdList);
        }
        public static BibleContent getDayBible(string date)
        {
            string sql = "SELECT  B_CONTENT AS content, B.WEEK_DAY, IMAGE_PATH as path  FROM BIBLE_CONTENT B WHERE B.B_DATE=@Date";
            SqlParameter para = new SqlParameter("@Date", date);
            SqlParameter[] paras = { para };
            DataTableCollection tables = SqlHelper.GetTableText(sql, paras);
            DataTable table = tables[0];
            BibleContent content = new BibleContent();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                content.content = row[CommonInfo.CONTENT] as string;
                content.dateWeek = Convert.ToInt32(row[CommonInfo.DAY]);
                content.imagePath = Convert.ToString(row[CommonInfo.D_IMAGE_PATH]);
            }
            return content;
        }
        public static void updateBible(string date, string image, string content)
        {
            List<SqlCommand> cmdList = new List<SqlCommand>();
            string updateSql = "";
            if (image.Equals(""))
            {
                 updateSql = "UPDATE BIBLE_CONTENT SET B_CONTENT = @Content WHERE B_DATE = @Date";
            }
            else
            {
                updateSql = "UPDATE BIBLE_CONTENT SET B_CONTENT = @Content,IMAGE_PATH = @Path WHERE B_DATE = @Date";
            }
            
            SqlParameter Content = new SqlParameter("@Content", content);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            //SqlParameter Day1 = new SqlParameter("@Day", day);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            SqlParameter Path = new SqlParameter("@Path", image);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            SqlParameter Date = new SqlParameter("@Date", date);//生成一个名字为@Id的参数,必须以@开头表示是添加的参数，并设置其类型长度，类型长度与数据库中对应字段相同
            SqlParameter[] insertParas = { Content, Path, Date };
            SqlHelper.ExecteNonQueryText(updateSql, insertParas);
        }
    }
}