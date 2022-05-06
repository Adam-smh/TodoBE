using System.ComponentModel.DataAnnotations;

namespace TodosTask.Models.Entities
{
    public class TodoList
    {
        [Key]
        public int ListId { get; set; }
        public string Title { get; set; }

        public List<TodoWork> TodoW { get; set; }
    }
    public class TodoWork
    {
        [Key]
        public int TodoId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public int ListId { get; set; }

    }

}
