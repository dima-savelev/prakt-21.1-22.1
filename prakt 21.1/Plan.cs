//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prakt_21._1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<byte> Month { get; set; }
    
        public virtual ProductCatalog ProductCatalog { get; set; }
    }
}
