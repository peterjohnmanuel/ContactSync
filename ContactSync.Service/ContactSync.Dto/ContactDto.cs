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

        [StringLength(30, MinimumLength = 3, ErrorMessageResourceName = "ContactFirstNameNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string LastName { get; set; }

        [RegularExpression(@"[1-9]{9}$", ErrorMessageResourceName = "MobileNumberNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string MobileNumber { get; set; }

        [RegularExpression(@"[1-9]{9}$", ErrorMessageResourceName = "HomeNumberNotValid", ErrorMessageResourceType = typeof(ValidationMessages))]
        public string HomeNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
