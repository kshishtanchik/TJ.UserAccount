namespace TJ.UserAccount.Services.Dto
{
    /// <summary>
    /// Заявка
    /// </summary>
    public class Bid
    {
        public string UserId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}
