using System;
using System.Collections.Generic;
using System.Text;

namespace MPCA.Entities.DataTransferObjects
{
    public class RoleDto
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid ID { get; set; }

        /// <summary>Gets or sets the name of the role.</summary>
        /// <value>The name of the role.</value>       
        public string RoleName { get; set; }
        /// <summary>Gets or sets the role code.</summary>
        /// <value>The role code.</value>
        public string RoleCode { get; set; }
        /// <summary>Gets or sets the descriptions.</summary>
        /// <value>The descriptions.</value>
        public string Descriptions { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
        /// <value>///<c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>Gets or sets the created by.</summary>
        /// <value>The created by.</value>
       
        public Guid CreatedBy { get; set; }

        /// <summary>Gets or sets the created date.</summary>
        /// <value>The created date.</value>
        
        public DateTime CreatedDate { get; set; }
    }
}
