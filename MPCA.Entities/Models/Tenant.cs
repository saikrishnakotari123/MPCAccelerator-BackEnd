#region Namespace
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
#endregion

namespace MPCA.Entities.Models
{
    /// <summary>
    /// Database Table Name is "Tenant"
    /// </summary>
    [Table("Tenant")]
    public class Tenant
    {
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        [Column("TenantId")]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code of tenant.
        /// </value>
        [Required(ErrorMessage = "Code is required")]
        [StringLength(50, ErrorMessage = "Code can't be longer than 50 characters")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name tenant.
        /// </value>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(500, ErrorMessage = "Name can't be longer than 500 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        [Required(ErrorMessage = "Created by is required")]
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date of tenant.
        /// </value>
        [Required(ErrorMessage = "Created date is required")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the sites.
        /// </summary>
        /// <value>
        /// The sites which are owned by tenant
        /// </value>
        public ICollection<Site> Sites { get; set; }
    }
}
