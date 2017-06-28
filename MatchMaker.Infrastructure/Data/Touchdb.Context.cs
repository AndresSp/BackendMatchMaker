﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatchMaker.Infrastructure.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using MatchMaker.Core.Model;

    public partial class touchdbEntities : DbContext
    {
        public touchdbEntities()
            : base("name=touchdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Entertainment> Entertainments { get; set; }
        public virtual DbSet<ExpArt> ExpArts { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Music> Musics { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User_Books> User_Books { get; set; }
        public virtual DbSet<User_Entertainment> User_Entertainment { get; set; }
        public virtual DbSet<User_ExpArts> User_ExpArts { get; set; }
        public virtual DbSet<User_Music> User_Music { get; set; }
        public virtual DbSet<User_Sport> User_Sport { get; set; }
        public virtual DbSet<UserMatch> UserMatches { get; set; }
    
        public virtual ObjectResult<sp_BooksSelect_Result> sp_BooksSelect(Nullable<int> genreId)
        {
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("GenreId", genreId) :
                new ObjectParameter("GenreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_BooksSelect_Result>("sp_BooksSelect", genreIdParameter);
        }
    
        public virtual ObjectResult<sp_EntertainmentSelect_Result> sp_EntertainmentSelect(Nullable<int> genreId)
        {
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("GenreId", genreId) :
                new ObjectParameter("GenreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_EntertainmentSelect_Result>("sp_EntertainmentSelect", genreIdParameter);
        }
    
        public virtual ObjectResult<sp_ExpArtsSelect_Result> sp_ExpArtsSelect(Nullable<int> genreId)
        {
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("GenreId", genreId) :
                new ObjectParameter("GenreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ExpArtsSelect_Result>("sp_ExpArtsSelect", genreIdParameter);
        }
    
        public virtual ObjectResult<sp_FacultySelect_Result> sp_FacultySelect(Nullable<int> facultyId)
        {
            var facultyIdParameter = facultyId.HasValue ?
                new ObjectParameter("FacultyId", facultyId) :
                new ObjectParameter("FacultyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_FacultySelect_Result>("sp_FacultySelect", facultyIdParameter);
        }
    
        public virtual ObjectResult<sp_MusicSelect_Result> sp_MusicSelect(Nullable<int> genreId)
        {
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("GenreId", genreId) :
                new ObjectParameter("GenreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MusicSelect_Result>("sp_MusicSelect", genreIdParameter);
        }
    
        public virtual ObjectResult<sp_SportsSelect_Result> sp_SportsSelect(Nullable<int> genreId)
        {
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("GenreId", genreId) :
                new ObjectParameter("GenreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SportsSelect_Result>("sp_SportsSelect", genreIdParameter);
        }
    
        public virtual int sp_UserDelete(Nullable<System.Guid> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UserDelete", userIdParameter);
        }
    
        public virtual ObjectResult<sp_UserRegister_Result> sp_UserRegister(string email, string password, string firstName, string lastName)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_UserRegister_Result>("sp_UserRegister", emailParameter, passwordParameter, firstNameParameter, lastNameParameter);
        }
    
        public virtual ObjectResult<sp_UserSelect_Result> sp_UserSelect()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_UserSelect_Result>("sp_UserSelect");
        }
    
        public virtual ObjectResult<sp_GetUserMatchs_Result> sp_GetUserMatchs(Nullable<System.Guid> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUserMatchs_Result>("sp_GetUserMatchs", userIdParameter);
        }
    
        public virtual ObjectResult<sp_UserSelectById_Result> sp_UserSelectById(Nullable<System.Guid> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_UserSelectById_Result>("sp_UserSelectById", userIdParameter);
        }
    
        public virtual ObjectResult<sp_User_BooksRegister_Result> sp_User_BooksRegister(Nullable<System.Guid> userId, Nullable<int> genreId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(System.Guid));
    
            var genreIdParameter = genreId.HasValue ?
                new ObjectParameter("GenreId", genreId) :
                new ObjectParameter("GenreId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_User_BooksRegister_Result>("sp_User_BooksRegister", userIdParameter, genreIdParameter);
        }
    }
}
