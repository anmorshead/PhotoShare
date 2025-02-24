using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhotoShare.Data;

namespace PhotoShare.Models
{
    public class Photo
    {
        // Primary key
        public int PhotoId{ get; set; }
        public string Description { get;set; } = string.Empty;
        public string Location {  get; set; } = string.Empty;
        public string Camera {  get; set; } = string.Empty;
        public string ImageFilename { get; set; } = string.Empty;

        // Property for file upload, not mapped in EF
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; } // nullable


        [Display(Name = "Visibility")]
        public bool IsVisible { get; set; } = false;

        [Display(Name = "Date Created")] //set labels
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Navigation Property
        public List<Tag>? Tags { get; set; } //nullable

        // Foreign key (AspNetUsers table)
        public string ApplicationUserId { get; set; } = string.Empty;
        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!
    }
}