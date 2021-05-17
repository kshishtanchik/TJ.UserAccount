namespace TJ.UserAccount.Dao.Models
{
    /// <summary>
    /// Заявка на конвертацию валюты
    /// </summary>
    public class TransferBid : Bid
    {
        public string TargetCurrencyCode { get; set; }
    }
}
