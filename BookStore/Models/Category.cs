using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required ]
        [MaxLength(10 , ErrorMessage = "Please maxium length is 10")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Required]
        [Range(1,100 ,ErrorMessage= "DisPlay order must be from 1 to 100")]
        public int DisplayOrder { get; set; }
    }
}
