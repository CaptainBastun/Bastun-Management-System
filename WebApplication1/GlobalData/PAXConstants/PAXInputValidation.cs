namespace BMS.GlobalData.PAXConstants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PAXInputValidation
    {
        public const string PaxFirstNameValidation = @"^[A-Z]{1,20}$";

        public const string PaxLastNameValidation = @"^[A-Z]{1,20}$";

        public const string PassportNumberValidation = @"^(?!^0+$)[a-zA-Z0-9]{3,20}$";

        public const string PAXGenderValidation = @"[MFCi]{1}";

        public const int PAXMinAge = 1;

        public const int PAXMaxAge = 110;

    }
}
