namespace EloBoost.Shared.Enums
{
    public enum OrderStatus : byte
    {
        Created = 0,
        WaitingPaymentApproval = 1,
        RequestActive = 2,
        BoostStarted = 3,
        BoostFinished = 4,
        BoostDisapproved = 5,
        WaitingOrderCancel = 6,
        OrderCanceled = 7,
        WaitingPaymentReturn = 8,
        PaymentReturned = 9,
        Deleted = 10
    }
}
