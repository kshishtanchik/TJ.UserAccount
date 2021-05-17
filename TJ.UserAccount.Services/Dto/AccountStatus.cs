namespace TJ.UserAccount.Services.Dto
{
    /// <summary>
    /// Состояние счета
    /// </summary>
    public class AccountStatus
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Код валюты
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Количество дене
        /// </summary>
        public double Amount { get; set; }
    }
}
