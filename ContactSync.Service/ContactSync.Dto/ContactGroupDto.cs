using ContactSync.Common.ValidationMessages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactSync.Dto
{
    public class ContactGroupDto
    {
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "ContactGroupNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "ContactGroupNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Name { get; set; }
        public ICollection<ContactDto> ContactGroupEntries { get; set; }
    }
}
