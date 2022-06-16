using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Bootstrap.Utilities
{
    public static class FileUstilits
    {
        public static async Task<string> FileCreate(this IFormFile formFile , string root , string file)
        {
            string filestream = Guid.NewGuid() + formFile.FileName;
            string path = Path.Combine(root, file);
            string allpath = Path.Combine(path,filestream);

            using (FileStream fileStrem = new FileStream(allpath,FileMode.Create))
            {
                await formFile.CopyToAsync(fileStrem);
            }
            return filestream;
        }
    }
}
