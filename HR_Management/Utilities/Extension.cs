using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HR_Management.Utilities
{
    public static class Extension
    {
        public static bool CheckSize(this IFormFile file , int kb)
        {
            return file.Length / 1024 <= kb;
        }

        public static bool CheckType(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }

        public static async Task<string> SaveFileAsync(this IFormFile file , string root , params string[] folders)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string resultPath = Path.Combine(GetPath(root, folders), fileName);
            using(FileStream fs = new FileStream(resultPath , FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            return fileName;
        }

        public static string GetPath(string root , params string[] folders)
        {
            string resultPath = root;
            foreach (string folder in folders)
            {
                resultPath = Path.Combine(resultPath, folder);
            }
            return resultPath;
        }
    }
}
