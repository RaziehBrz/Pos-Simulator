interface ICard
{
    public string CardNumber { get; set; }
    public string Cvv2 { get; set; }
    public string ExpireDate { get; set; }

    void AddCard();
    void EditCard();
    void RemoveCard();
    void ShowCardsList();
    void ShowCardNumbersList();
    void GetCardInfo();
    bool ValidateCardInfo(string cardNumber, string cvv2, string exDate);
    void PrintEditCardMenu(string[] lines, int i);
}