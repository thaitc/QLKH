using Microsoft.AspNetCore.Http;
using System.IO;

namespace DoAn_Theme_2.Commom
{
    public class FileHelper
    {
        public static async void UploadFile(IFormFile file, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
