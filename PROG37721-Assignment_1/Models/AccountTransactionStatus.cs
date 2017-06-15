namespace PROG37721_Assignment_1.Models
{
    public enum DepositStatus
    {
        Success,
        ClosedAccountError
    }

    public enum WithdrawStatus
    {
        Success,
        ClosedAccountError,
        InsufficientFunds,
        Overdraft
    }

    public enum TransferStatus
    {
        Success,
        ClosedAccountError,
        Failure,
        InsufficientFunds
    }
}