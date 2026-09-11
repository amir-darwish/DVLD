namespace DVLD_BusinessLayer
{
    public enum enReplaceLicenseResult
    {
        Success,
        InvalidLicenseID,
        InvalidUser,
        InvalidReplacementType,
        LicenseNotFound,
        LicenseInactive,
        LicenseDetained,
        LicenseExpired,
        ApplicationTypeNotFound,
        ApplicationCreationFailed,
        LicenseCreationFailed,
        OldLicenseDeactivationFailed,
        ApplicationCompletionFailed
    }
}
