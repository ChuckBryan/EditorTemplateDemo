namespace EditorTemplateDemo.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class CustomerAddModel
    {
        [StringLength(25), Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(1)]
        public string Initial { get; set; }

        [StringLength(25), Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Customer Type"), DataType("CustomerType")]
        public int CustomerTypeId { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}