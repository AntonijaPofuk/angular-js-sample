﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJsSample.Repositories.DatabaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AngularJsSampleDbEntities : DbContext
    {
        public AngularJsSampleDbEntities()
            : base("name=AngularJsSampleDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<MoviePerson> MoviePersons { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    
        public virtual int MoviePerson_Delete(Nullable<int> id, Nullable<int> userLastModified)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var userLastModifiedParameter = userLastModified.HasValue ?
                new ObjectParameter("UserLastModified", userLastModified) :
                new ObjectParameter("UserLastModified", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MoviePerson_Delete", idParameter, userLastModifiedParameter);
        }
    
        public virtual int MoviePerson_Insert(string firstName, string lastName, Nullable<System.DateTimeOffset> birthday, string birthPlace, string biography, Nullable<int> userCreated, string photoUrl, string iMDBUrl, Nullable<int> popularity)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("Birthday", birthday) :
                new ObjectParameter("Birthday", typeof(System.DateTimeOffset));
    
            var birthPlaceParameter = birthPlace != null ?
                new ObjectParameter("BirthPlace", birthPlace) :
                new ObjectParameter("BirthPlace", typeof(string));
    
            var biographyParameter = biography != null ?
                new ObjectParameter("Biography", biography) :
                new ObjectParameter("Biography", typeof(string));
    
            var userCreatedParameter = userCreated.HasValue ?
                new ObjectParameter("UserCreated", userCreated) :
                new ObjectParameter("UserCreated", typeof(int));
    
            var photoUrlParameter = photoUrl != null ?
                new ObjectParameter("PhotoUrl", photoUrl) :
                new ObjectParameter("PhotoUrl", typeof(string));
    
            var iMDBUrlParameter = iMDBUrl != null ?
                new ObjectParameter("IMDBUrl", iMDBUrl) :
                new ObjectParameter("IMDBUrl", typeof(string));
    
            var popularityParameter = popularity.HasValue ?
                new ObjectParameter("Popularity", popularity) :
                new ObjectParameter("Popularity", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MoviePerson_Insert", firstNameParameter, lastNameParameter, birthdayParameter, birthPlaceParameter, biographyParameter, userCreatedParameter, photoUrlParameter, iMDBUrlParameter, popularityParameter);
        }
    
        public virtual int MoviePerson_Save(Nullable<int> id, string firstName, string lastName, string birthPlace, Nullable<System.DateTimeOffset> birthday, string biography, string photoUrl, string iMDBUrl, Nullable<int> popularity, Nullable<int> userLastModified)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var birthPlaceParameter = birthPlace != null ?
                new ObjectParameter("BirthPlace", birthPlace) :
                new ObjectParameter("BirthPlace", typeof(string));
    
            var birthdayParameter = birthday.HasValue ?
                new ObjectParameter("Birthday", birthday) :
                new ObjectParameter("Birthday", typeof(System.DateTimeOffset));
    
            var biographyParameter = biography != null ?
                new ObjectParameter("Biography", biography) :
                new ObjectParameter("Biography", typeof(string));
    
            var photoUrlParameter = photoUrl != null ?
                new ObjectParameter("PhotoUrl", photoUrl) :
                new ObjectParameter("PhotoUrl", typeof(string));
    
            var iMDBUrlParameter = iMDBUrl != null ?
                new ObjectParameter("IMDBUrl", iMDBUrl) :
                new ObjectParameter("IMDBUrl", typeof(string));
    
            var popularityParameter = popularity.HasValue ?
                new ObjectParameter("Popularity", popularity) :
                new ObjectParameter("Popularity", typeof(int));
    
            var userLastModifiedParameter = userLastModified.HasValue ?
                new ObjectParameter("UserLastModified", userLastModified) :
                new ObjectParameter("UserLastModified", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("MoviePerson_Save", idParameter, firstNameParameter, lastNameParameter, birthPlaceParameter, birthdayParameter, biographyParameter, photoUrlParameter, iMDBUrlParameter, popularityParameter, userLastModifiedParameter);
        }
    
        public virtual ObjectResult<MoviePersonData_Get_Result> MoviePersonData_Get(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MoviePersonData_Get_Result>("MoviePersonData_Get", idParameter);
        }
    
        public virtual ObjectResult<MoviePerson_Get_Result> MoviePerson_Get()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MoviePerson_Get_Result>("MoviePerson_Get");
        }
    
        public virtual ObjectResult<MoviePerson_GetDateCreated_Result> MoviePerson_GetDateCreated()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MoviePerson_GetDateCreated_Result>("MoviePerson_GetDateCreated");
        }
    
        public virtual ObjectResult<GenreData_Get_Result> GenreData_Get(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GenreData_Get_Result>("GenreData_Get", idParameter);
        }
    
        public virtual ObjectResult<Genres_Get_Result> Genres_Get()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Genres_Get_Result>("Genres_Get");
        }
    }
}
