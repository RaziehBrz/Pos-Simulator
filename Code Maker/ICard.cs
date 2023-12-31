interface ICard
{
    public string CardNumber { get; set; }
    public string Cvv2 { get; set; }
    public string ExpirationDate { get; set; }
    void AddCard();
    void EditCard();
    void RemoveCard();
    void ShowCardsList();
    void showCardNumbersList();
    void GetCardInfo();
    bool CardInfoValidation(string cardNumber, string cvv2, string exDate);
}