using System;
using System.Collections.Generic;
using System.Text;

namespace Cs_Plantlover.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IChiTietSPRepository ChiTietSP { get; }
        IDanhMucSanPhamRepository DanhMucSP { get; }
        ICartRepository Cart { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IUserRepository User { get; }
        ISP_Call SP_Call { get; }
        void Save();
    }
}
