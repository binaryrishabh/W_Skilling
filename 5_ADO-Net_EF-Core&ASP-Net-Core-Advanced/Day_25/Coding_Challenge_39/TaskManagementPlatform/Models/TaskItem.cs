using System.ComponentModel.DataAnnotations;

namespace TaskManagementPlatform.Models {
    public class TaskItem {
        public int Id { get; set; }
        [Required] public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AssignedUserId { get; set; }
        public string? CreatedByUserId { get; set; }
    }
}