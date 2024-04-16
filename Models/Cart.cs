using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Cs_Plantlover.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public OrderHeader OrderHeader { get; set; }

        public void AddItem(CartItem item)
        {
            // Check if Items collection is null
            if (Items == null)
            {
                Items = new List<CartItem>();
            }

            var existingItem = Items.FirstOrDefault(i => i?.DanhMucSP?.MaSP == item?.DanhMucSP?.MaSP);
            if (existingItem != null)
            {
                if (existingItem.SoLuong > 0)
                {
                    existingItem.SoLuong += item.SoLuong;
                }
                else
                {
                    Items.RemoveAll(i => i?.DanhMucSP?.MaSP == item?.DanhMucSP?.MaSP);
                }
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(int productId)
        {
                Items.RemoveAll(i => i?.DanhMucSP?.MaSP == productId);
            
        }

        public void ClearAll()
        {
            Items.Clear();
        }

        public void IncreaseOrDecreased(bool isIncrease, int productId)
        {
            var existingItem = Items.FirstOrDefault(i => i.DanhMucSP.MaSP == productId);
            if (existingItem != null)
            {
                if (isIncrease)
                {
                    existingItem.DanhMucSP.MaSP++;
                    return;
                }
                if (existingItem.DanhMucSP.MaSP > 0)
                {
                    existingItem.DanhMucSP.MaSP--;
                    return;
                }
                else
                {
                    existingItem.DanhMucSP.MaSP = 0;
                }
            }
        }
    }
}
