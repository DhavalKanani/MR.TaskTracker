using System;
using Microsoft.AspNetCore.Http;
using MR.TaskTracker.Application.Models.File;
using MR.TaskTracker.Domain;

namespace MR.TaskTracker.Application.Extensions
{
    public static class FormFileExtention
    {
        public static Task<FileModel> ToFileModel(this IFormFile fileData)
        {
            var file = new FileModel()
            {
                FileName = fileData.FileName,
                Length = fileData.Length
            };

            using (var stream = new MemoryStream())
            {
                fileData.CopyTo(stream);
                file.Content = stream.ToArray();
            }
            return Task.FromResult(file);
        }
    }
}

