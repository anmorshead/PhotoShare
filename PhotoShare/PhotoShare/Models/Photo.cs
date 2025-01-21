using System.ComponentModel.DataAnnotations;

namespace PhotoShare.Models
{
    public class Photo
    {
        // Primary key
        public int PhotoId{ get; set; }
        public string Description { get;set; } = string.Empty;
        public string Location {  get; set; } = string.Empty;
        public string Camera {  get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
        
        public string ImageFilename { get; set; } = string.Empty;

        [Display(Name = "Visibility")]
        public bool IsVisible { get; set; } = false;

        [Display(Name = "Date Created")] //set labels
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Navigation Property
        public List<Tag>? Tags { get; set; } //nullable
    }
}