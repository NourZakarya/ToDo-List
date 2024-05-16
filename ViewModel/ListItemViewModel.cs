using System.ComponentModel.DataAnnotations;

namespace ToDoList.ViewModel
{
    public class ListItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [RegularExpression(@"NoDes|Des")]
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
