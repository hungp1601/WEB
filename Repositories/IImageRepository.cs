
using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IImageRepository
    {
        Image GetById(int id);
        void Add(Image image);
        void Update(Image image);
        void Delete(int id);
    }
}