using BibleStudy.DataLayer.SqlAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleStudy.Models.ViewModels
{
    public class HomeModel
    {
        public HomeModel()
        {
            bible = BibleAdapter.getBible();
            prists = BibleAdapter.getPriest();
            photo = "Resource/Images/Background.jpg";
        }
        public string photo { get; set; }
        public List<BibleContent>  bible { get; set; }
        public List<PriestInfo>  prists { get; set; }
    }
}