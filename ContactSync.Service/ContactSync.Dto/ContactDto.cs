using ContactSync.Common.ValidationMessages;
using System.ComponentModel.DataAnnotations;

namespace ContactSync.Dto
{
    public class ContactDto
    {
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "EntryNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "EntryNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "PhoneNumberNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        [RegularExpression(@"[1-9]{9}$", ErrorMessageResourceName = "PhoneNumberNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string PhoneNumber { get; set; }
    }
}
