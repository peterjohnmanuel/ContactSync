using ContactSync.Common.ValidationMessages;
using System.ComponentModel.DataAnnotations;

namespace ContactSync.Dto
{
    public class ContactDto
    {
        public long Id { get; set; }

        [Required(ErrorMessageResourceName = "ContactFirstNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "ContactFirstNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "MobileNumberNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        [RegularExpression(@"[1-9]{9}$", ErrorMessageResourceName = "MobileNumberNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string MobileNumber { get; set; }
    }
}
