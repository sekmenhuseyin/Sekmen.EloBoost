namespace EloBoost.Shared.Enums
{
    public enum PaymentStatus : byte
    {
        Requested = 1,
        Canceled = 2,
        Returned = 3,
        Paid = 4,
        PaymentApproval = 5,
        CancelationApproval = 6,
        ReturnApproval = 7,
        Disapproved = 8
    }
}
