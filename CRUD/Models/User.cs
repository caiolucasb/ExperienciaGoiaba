using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace User.Model
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{get;set;}

        [Required]
        public string firstName{get;set;}

        public string surname{get;set;}
        [Required]
        [Range(1,120)]
        public int age{get;set;}

        public DateTime creationDate{get;set;}
    }
}