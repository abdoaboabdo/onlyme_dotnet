using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlyMe.DAL.Helpers
{
    public interface IUtilities
    {
        void UploadImage(string folderName, IFormFile file, Action<string> processingSQL);
        void DeleteImage(string imagePath);
        string UploadFile(string path, string base64Image);
    }
}
