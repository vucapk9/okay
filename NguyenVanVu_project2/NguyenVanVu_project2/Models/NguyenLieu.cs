//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NguyenVanVu_project2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NguyenLieu
    {
        public int id { get; set; }
        public string ten { get; set; }
        public int so_luong { get; set; }
        public string don_vi { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}