using System;
using NHNT.Models;

namespace NHNT.Dtos
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ImageDto(Image image)
        {
            if (image == null)
            {
                return;
            }

            this.Id = image.Id;
            this.Path = image.Path;
            this.CreatedAt = image.CreatedAt;
        }
    }
}