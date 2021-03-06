//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            this.MovieRatings = new HashSet<MovieRating>();
            this.Genres = new HashSet<Genre>();
        }
    
        public int Id { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public Nullable<int> Rating { get; set; }
        public string Description { get; set; }
        public System.DateTimeOffset ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public string IMDBUrl { get; set; }
        public System.DateTimeOffset DateCreated { get; set; }
        public int UserCreated { get; set; }
        public Nullable<System.DateTimeOffset> LastModified { get; set; }
        public Nullable<int> UserLastModified { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual UserInfo UserInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieRating> MovieRatings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
