using Cs_Plantlover.Models;
namespace Repository.IRepository
{
    public interface IChucNangSPRepository
    {
        ChucNangSP Add(ChucNangSP chucnangSP);
        ChucNangSP Update(ChucNangSP chucnangSP);
        ChucNangSP Delete(ChucNangSP machucnangSP);

        ChucNangSP GetChucNangSP(int machucnangSP);
        IEnumerable<ChucNangSP> GetAllChucNangSP();
    }
}
