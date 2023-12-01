
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace NHNT.Services
{
    public interface IImageService
    {
        void saveMultiple(ICollection<IFormFile> images, int departmentId);
    }
}