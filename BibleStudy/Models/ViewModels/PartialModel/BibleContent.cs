using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace BibleStudy.Models.ViewModels
{
    public class BibleContent
    {
        public BibleContent()
        {

        }
        public BibleContent(string con,int day,string path)
        {
            this.content = con;
            this.dateWeek = day;
            this.imagePath = path;
        }
        public string content { get; set; }
        public int dateWeek { get; set; }
        public string imagePath { get; set; }
    }
}