using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace drop_img_test_jqury_plugin_dropzonejs.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string file)
        {
            string name;
            upload ouplodimginfo = new upload();
            foreach (String filedata in Request.Files)
            {
                if (file != null)
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "sampleimages/"))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "LogoImage/");

                    }
                    string path = AppDomain.CurrentDomain.BaseDirectory + "LogoImage/";
                    string ext = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    ouplodimginfo.fileextension = ext;
                    var fileName = Path.GetFileName(Request.Files[0].FileName);
                    ouplodimginfo.filename = fileName;
                    var filesize = Request.Files[0].ContentLength;
                    ouplodimginfo.filesize = filesize;
                    name = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss_") + ext);
                    ouplodimginfo.fileuploadeddate = DateTime.Now;
                    Request.Files[0].SaveAs(System.IO.Path.Combine(path, name));
                }
            }

            if (Session["ilistuploadfiles"] != null)
            {
                IList<upload> os = (List<upload>)Session["ilistuploadfiles"];
                IList<upload> olistuploadfile = os;
                
                olistuploadfile.Add(ouplodimginfo);
                Session["ilistuploadfiles"] = olistuploadfile;
            }
            else
            {
                IList<upload> olistuploadfile = new List<upload>();
                olistuploadfile.Add(ouplodimginfo);
                Session["ilistuploadfiles"] = olistuploadfile;
            }
            
                return View();
        }
        public ActionResult About()
        {

          IList<upload> os= (List<upload>)Session["ilistuploadfiles"];
            ViewBag.Message = "Your application description page.";




            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}