namespace DVLD_BusinessLayer
{
    public enum enRenewLicenseResult
    {
        Success,
        InvalidLicenseID,
        InvalidUser,
        NotesTooLong,
        LicenseNotFound,
        LicenseInactive,
        LicenseDetained,
        LicenseNotExpired,
        ApplicationTypeNotFound,
        ApplicationCreationFailed,
        LicenseCreationFailed,
        OldLicenseDeactivationFailed,
        ApplicationCompletionFailed
    }
}
