using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace shop_cake.Extensions
{
    public class FileUploadHelper
    {
        private static FileUploadHelper _instance;

        private FileUploadHelper()
        {

        }

        public static FileUploadHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FileUploadHelper();
                return _instance;
            }
            private set => _instance = value;
        }

        public async Task<bool> Upload(IFormFile file, IWebHostEnvironment env)
        {
            string filePath = Path.Combine(env.WebRootPath, "image", "product", file.FileName);
            try
            {
                using (Stream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string filename, IWebHostEnvironment env)
        {
            var getFile = new FileInfo(Path.Combine(env.WebRootPath, "image", "product", filename));
            try
            {
                getFile.Delete();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
