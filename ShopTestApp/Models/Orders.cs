//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopTestApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int id { get; set; }
        public int idUsers { get; set; }
        public int idProducts { get; set; }
        public int amounInOrder { get; set; }
        public System.DateTime orderDate { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }
    }
}
