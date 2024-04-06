﻿using Cs_Plantlover.Models;
namespace Cs_Plantlover.Repository
{
    public interface IChucNangSPRepository
    {
        ChucNangSP Add(ChucNangSP chucnangSP);
        ChucNangSP Update(ChucNangSP chucnangSP);
        ChucNangSP Delete(ChucNangSP machucnangSP);

        ChucNangSP GetChucNangSP(String machucnangSP);
        IEnumerable<ChucNangSP> GetAllChucNangSP();       
    }
}