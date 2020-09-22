#region Namespace
using System;
using System.ComponentModel.DataAnnotations; 
#endregion

namespace MPCA.Entities.DataTransferObjects
{
    /// <summary>
    /// Tenant Data Transfer Object for Update
    /// </summary>
    public class TenantForUpdateDto
    {
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        [Required(ErrorMessage = "TenantId is required")]
        public Guid TenantId { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [Required(ErrorMessage = "Code is required")]
        [StringLength(50, ErrorMessage = "Code can't be longer than 50 characters")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(500, ErrorMessage = "Name can't be longer than 500 characters")]
        public string Name { get; set; }
    }
}
