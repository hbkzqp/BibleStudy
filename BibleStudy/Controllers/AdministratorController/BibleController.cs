using BibleStudy.DataLayer.SqlAdapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BibleStudy.Controllers.AdministratorController
{
    public class BibleController : ApiController
    {
        // GET: api/Bible
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Bible/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bible
        public async Task<HttpResponseMessage> PostBible()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Resource/Images");
            var provider = new MultipartFormDataStreamProvider(root);
            string date = "";
            string content = "";
            string image = "";
            try
            {
                StringBuilder sb = new StringBuilder(); // Holds the response body

                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the form data.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        if(key.Equals("bibleDate"))
                        {
                            date = val;
                        }
                        if(key.Equals("bibleContent"))
                        {
                            content = val;
                        }
                    }
                }

                // This illustrates how to get the file names for uploaded files.
                foreach (var file in provider.FileData)
                {
                    FileInfo fileInfo = new FileInfo(file.LocalFileName);
                    string dic = fileInfo.DirectoryName;
                    image = dic +"\\"+ date + provider.FileData[0].Headers.ContentDisposition.FileName.Replace("\"","");
                    fileInfo.MoveTo(image);
                }
                //BibleAdminAdapter.AddBible(date, image, content);
                Redirect("http://localhost:50042/BibleViews/Administrator/AddBIble.html");
                return new HttpResponseMessage()
                {
                    Content = new StringContent("<a href=\"AddBible.html\">Add</a>")
                };
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        // PUT: api/Bible/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bible/5
        public void Delete(int id)
        {
        }
    }
}
