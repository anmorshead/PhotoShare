using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Controllers
{
    //only logged in users have access
    [Authorize]
    public class TagsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PhotoShareContext _context;

        public TagsController(PhotoShareContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Deleted the following actions:
        // GET: Tags
        // GET: Tags/Details/5
        // GET: Tags/Edit/5
        // POST: Tags/Edit/5
        // POST: Tags/Delete/5

        // GET: Tags/Create
        public async Task<IActionResult> Create(int? id)
        {
            // id= photo id
            if (id == null)
            {
                return NotFound();
            }

            //get the logged in user Id
            var userId = _userManager.GetUserId(User);


            var photo = await _context.Photo
                .Where(m => m.ApplicationUserId == userId) //filter by user Id
                .FirstOrDefaultAsync(m => m.PhotoId == id);

            if (photo == null)
            {
                return NotFound();
            }

            ViewData["PhotoId"] = id;

            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TagId,Name,PhotoId")] Tag tag)
        {

            //
            // TO-DO: EMBED THE USER ID IN HTE FORM AND VALIDATE
            //

            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();

                // re-direct to /Photos/Edit/5
                return RedirectToAction("Edit", "Photos", new { id = tag.PhotoId });
            }

            ViewData["PhotoId"] = tag.PhotoId;

            return View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // id is the tag id
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tag.FirstOrDefaultAsync(m => m.TagId == id);

            if (tag == null)
            {
                return NotFound();
            }

            // set the photo id to pass to return to the Photo Details page
            var photoId = tag.PhotoId;

            // Remove the tag
            _context.Tag.Remove(tag);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", "Photos", new { id = photoId });
        }
    }
}
