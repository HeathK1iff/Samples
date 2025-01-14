using System;
using System.Data.Linq.Mapping;

namespace Samples.Linq2Sql.NetFramework
{
    [Table(Name = "USERS")]
    public class User
    {
        [Column(Name = "ID", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "FIRST_NAME", DbType = "varchar(250)")]
        public string FirstName { get; set; }

        [Column(Name = "LAST_NAME", DbType = "varchar(250)")]
        public string LastName { get; set; }

        [Column(Name = "BIRTHDATE", DbType = "DATETIME", CanBeNull = true)]
        public DateTime? BirthDate { get; set; }

    }
}