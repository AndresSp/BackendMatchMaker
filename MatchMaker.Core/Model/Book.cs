//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatchMaker.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.User_Books = new HashSet<User_Books>();
        }
    
        public int GenreId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<User_Books> User_Books { get; set; }
    }
}
