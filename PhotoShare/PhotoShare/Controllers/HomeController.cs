using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PhotoShare.Models;

namespace PhotoShare.Controllers;

public class HomeController : Controller
{
    //constructor
    public HomeController()
    {

    } 

    //Home page - ../ or ../Home/Index
    public IActionResult Index()
    {
        //entity framework: fetch all photos
        
        //perform work here
        List<Photo> photos = new List<Photo>();
        //create 3 photos objects
        Photo photo1 = new Photo()
        {
            PhotoId = 1,
            Description = "This is my cat",
            ImageFilename = "cat.jpg",
            CreatedAt = DateTime.Now,
            IsVisible = true
        };

        Photo photo2 = new Photo()
        {
            PhotoId = 2,
            Description = "This is my dog",
            ImageFilename = "dog.jpg",
            CreatedAt = DateTime.Now,
            IsVisible = true,
        };
        Photo photo3 = new Photo()
        {
            PhotoId = 3,
            Description = "This is my turtle",
            ImageFilename = "turtle.jpg",
            CreatedAt = DateTime.Now,
            IsVisible = true,
        };
        //add them to the list
        photos.Add(photo1);
        photos.Add(photo2);
        photos.Add(photo3);
        
        //pass list to the view
        return View(photos);
    }
    //display a photo by id - ../Home/DisplayPhoto/id
    public IActionResult PhotoDetails(int id)
    {
        //entity framework: fetch the photo by id
        
        Photo photo = new Photo()
        {
            PhotoId = id,
            Description = "This is my bird",
            ImageFilename = "bird.jpg",
            CreatedAt = DateTime.Now,
            IsVisible = true
        };
        
        return View(photo);
    }
    //Privacy page - ../Home/Privacy
    public IActionResult Privacy()
    {
        return View();
    }

   
}
