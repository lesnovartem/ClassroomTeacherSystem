//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectCollege.odbConnectHelper
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> IdRole { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
