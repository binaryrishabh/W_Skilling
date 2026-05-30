using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureNote_API.Data;
using SecureNote_API.Models;
using System.Security.Claims;

namespace SecureNote_API.Controllers {
    [Route("api/notes")]
    [ApiController]
    [Authorize]
    public class NotesController : ControllerBase {
        private readonly AppDbContext _context;

        public NotesController(AppDbContext context) => _context = context;

        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteRequest req) {
            var note = new Note { Title = req.Title, Content = req.Content, UserId = GetUserId() };
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Note added successfully.", noteId = note.Id });
        }
    }
}