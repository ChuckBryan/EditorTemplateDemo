namespace EditorTemplateDemo.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(25), Required]
        public string FirstName { get; set; }

        [MaxLength(1)]
        public string Initial { get; set; }

        [MaxLength(25), Required]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public int CustomerTypeId { get; set; }

        public virtual CustomerType CustomerType { get; set; }
    }
}