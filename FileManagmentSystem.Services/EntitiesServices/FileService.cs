using System;
using System.Web;
using System.Web.Hosting;
using System.Web.Configuration;
using FileManagmentSystem.Models;
using FileManagmentSystem.DataAccess;

namespace FileManagmentSystem.Services.EntitiesServices
{
    public class FileService : BaseService<File>
    {
        public FileService()
            : base()
        {
            this.Repo = new FileRepository();
        }

        public override void Save(File item)
        {
            this.UploadFile(item);

            if (item.FileName != null)
            {
                base.Save(item);
            }
        }

        public override void Delete(File entity)
        {
            this.DeleteFile(entity);
            base.Delete(entity);
        }

        public void DownloadFile(File file)
        {
            string pathDirectory = System.IO.Path.GetDirectoryName(file.Path);
            string userDirName = pathDirectory.Substring(pathDirectory.LastIndexOf(System.IO.Path.DirectorySeparatorChar) + 1);

            HttpResponse response = HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.AddHeader("Content-Disposition", "attachment; filename=" + file.FileName + ";");
            response.TransmitFile(HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["FilePath"]+file.FileName));
            response.Flush();
            response.End();
        }

        public void UploadFile(File fileToUpload)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files["file"];
            if (file!=null && file.FileName != "")
            {
                int lastDot = file.FileName.LastIndexOf('.') + 1;

                fileToUpload.FileName = Guid.NewGuid().ToString() + "." + file.FileName.Substring(lastDot);
                file.SaveAs(System.IO.Path.Combine(HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["FilePath"]), fileToUpload.FileName));
            }
        }

        private void DeleteFile(File fileToDelete)
        {
            if (System.IO.File.Exists(System.IO.Path.Combine(HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["FilePath"]) + fileToDelete.FileName)))
            {
                System.IO.File.Delete(System.IO.Path.Combine(HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["FilePath"]) + fileToDelete.FileName));
            }
        }
    }
}
