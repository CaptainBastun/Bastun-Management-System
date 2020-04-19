namespace BMS.Models
{
    using BMS.Data.Models.Enums;
    using BMS.GlobalData.ErrorMessages;
    using BMS.GlobalData.PAXConstants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PAXInputModel
    {
        [Required(ErrorMessage = InvalidPAXErrorMessages.PAXFirstNameIsRequired)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = InvalidPAXErrorMessages.PAXLastNameIsRequired)]
        public string LastName { get; set; }

        [Required(ErrorMessage = InvalidPAXErrorMessages.PAXNationalityIsRequired)]
        public string Nationality { get; set; }

        [Required(ErrorMessage = InvalidPAXErrorMessages.PAXAgeIsRequired)]
        [Range(1, 100, ErrorMessage = InvalidPAXErrorMessages.PAXAgeIsInvalid)]
        public int Age { get; set; }

        [Required(ErrorMessage = InvalidPAXErrorMessages.PAXGenderIsRequired)]
        [RegularExpression(PAXInputValidation.PAXGenderValidation,   ErrorMessage = InvalidPAXErrorMessages.PAXGenderIsInvalid)]
        public Gender Gender { get; set; }

        public PAXWeight Weight { get; set; }

        [Required(ErrorMessage = InvalidPAXErrorMessages.PAXPassportNumberIsRequired)]
        public string PassportNumber { get; set; }
    }
}
