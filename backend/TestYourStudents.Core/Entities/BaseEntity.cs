using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestYourStudents.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public DateTime Created { get; set; }
        
        public DateTime Updated { get; set; }
        
        [Required]
        [ForeignKey("CreatedByUser")]
        public string CreatedByUserId { get; set; }
        
        [ForeignKey("UpdatedByUser")]
        public string UpdatedByUserId { get; set; }
        
        public User CreatedByUser { get; set; }
        public User UpdatedByUser { get; set; }
        
    }
    
}