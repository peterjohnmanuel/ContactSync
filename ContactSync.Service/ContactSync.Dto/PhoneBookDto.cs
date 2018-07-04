using ContactSync.Common.ValidationMessages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactSync.Dto
{
    public class PhoneBookDto
    {
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "EntryNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "EntryNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Name { get; set; }
        public ICollection<PhoneBookEntryDto> PhoneBookEntries { get; set; }
    }
}
