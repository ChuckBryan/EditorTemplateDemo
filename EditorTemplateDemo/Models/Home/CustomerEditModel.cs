﻿namespace EditorTemplateDemo.Models.Home
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CustomerEditModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [StringLength(25), Required, Display(Name="First Name")]
        public string FirstName { get; set; }

        [StringLength(25), Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(1)]
        public string Initial { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }
    }
}