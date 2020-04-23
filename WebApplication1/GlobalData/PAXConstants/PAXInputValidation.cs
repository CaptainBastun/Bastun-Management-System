namespace BMS.GlobalData.PAXConstants
{
    public class PAXInputValidation
    {
        public const string PaxFirstNameValidation = @"^[A-Z]{1,20}$";

        public const string PaxLastNameValidation = @"^[A-Z]{1,20}$";

        public const string PassportNumberValidation = @"^(?!^0+$)[a-zA-Z0-9]{3,20}$";

        public const string PAXGenderValidation = @"[MFCi]{1}";

        public const string PAXSeatNumberValidation = @"[1-9]{1,2}[A-Z]{1}";

        public const string PaxFullNameValidation = @"[A-Za-z]{3,20}\s?[A-Za-z]{3,20}";

        public const int PAXMinAge = 1;

        public const int PAXMaxAge = 110;

    }
}
