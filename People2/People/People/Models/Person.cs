using SQLite;

namespace People.Models
{
    [Table("people")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }

        [MaxLength(250), Unique]
        public string Email { get; set; }

        [MaxLength(50),Unique]
        public string Twitter { get; set; }
    }
}