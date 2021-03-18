using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlyMe.DAL.Helpers
{
   public class Utilities : IUtilities
    {
        static IWebHostEnvironment _webHostEnvironment;
        static IHttpContextAccessor _httpContextAccessor;
        public Utilities(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public void UploadImage(string folderName, IFormFile file, Action<string> processingSQL)
        {
            if (file != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using FileStream fileStream = File.Create(filePath);
                file.CopyTo(fileStream);
                fileStream.Flush();
                processingSQL(_httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host + "/" + folderName + "/" + uniqueFileName);
            }

        }

        public void DeleteImage(string imagePath)
        {
            string fullyPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);
            File.Delete(fullyPath);
        }

        public string UploadFile(string folderName, string base64Image)
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderName);
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            byte[] bytes = Convert.FromBase64String(base64Image);
            string uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
            string filePath = Path.Combine(uploadFolder, uniqueFileName);

            FileStream fs = File.Create(filePath);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            return _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host + "/" + folderName + "/" + uniqueFileName;
        }
    }
}
