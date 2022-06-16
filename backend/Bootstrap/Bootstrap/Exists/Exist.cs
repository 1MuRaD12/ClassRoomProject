using Microsoft.AspNetCore.Http;

namespace Bootstrap.Exists
{
    public static class Exist
    {
        public static bool IsExist(this IFormFile formFile , int mb) 
        {
            return formFile.ContentType.Contains("Image") && formFile.Length < mb * 1024 * 1024;
        }
    }
}
