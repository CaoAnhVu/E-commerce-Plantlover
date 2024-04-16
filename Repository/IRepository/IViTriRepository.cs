using Cs_Plantlover.Models;
namespace Repository.IRepository
{
    public interface IViTriRepository
    {
        ViTri Add(ViTri viTri);
        ViTri Update(ViTri viTri);
        ViTri Delete(ViTri maviTri);

        ViTri GetViTri(int maviTri);
        IEnumerable<ViTri> GetAllViTri();
    }
}
