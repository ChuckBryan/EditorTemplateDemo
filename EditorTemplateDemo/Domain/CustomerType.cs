namespace EditorTemplateDemo.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerType
    {
        public int Id { get; set; }

        [MaxLength(25)]
        public string Description { get; set; } 
    }
}