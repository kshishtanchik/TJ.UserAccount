namespace TJ.UserAccount.Services.Dto
{
    /// <summary>
    /// Заявка на конвертацию валюты
    /// </summary>
    public class TransferBid : Bid
    {
        public string TargetCurrencyCode { get; set; }
    }
}
