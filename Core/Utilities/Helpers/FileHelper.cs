using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Results;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length>0)
            {
                using(var fileStream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var result = NewPath(file);
            File.Move(sourcepath, result);
            return result;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                return new ErrorResult("Dosya silinemedi: " + ex.ToString());
            }

            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);
            if(sourcePath.Length > 0)
            {
                using (var fileStream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }


        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + " " + DateTime.Now.Day + " " + DateTime.Now.Year + fileExtension;
            string result = $@"wwwroot\Images\{newPath}";
            return result;
        }
    }
}
