using System;
namespace MR.TaskTracker.Application.Models.File
{
	public class FileModel
	{
        public string FileName { get; set; }
        public long Length { get; set; }
        public byte[] Content { get; set; }
    }
}

