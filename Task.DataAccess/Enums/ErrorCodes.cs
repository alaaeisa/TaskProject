namespace TaskProject.DataAccess.Enums
{
    public enum ErrorCodes
    {
        General = 0,
        WrongPassword = 1,
        WrongVerification = 2,
        UserNotFound = 3,
        UserBlocked = 4,
        NameUsed = 5,
        NameEnUsed = 6,
        MobileUsed = 7,
        IdEqamaNumberUsed = 8,
        EmailUsed = 9,
        EntityUsed = 10,
        CodeUsed = 11,
        BadRequest = 12,
        UserNotVerified = 13,
        UserPending = 14,
        WrongOldPassword = 15,
        IdEqamaNumberValidation=16,
        OrderChangeStatus=17,
        WalletBalance=18,
        ExtendRequest=19,
        OrderChange=20,
        UnAuth=21
    }
}
