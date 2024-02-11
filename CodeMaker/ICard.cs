interface ICard
{
    void AddCard();
    void EditCard();
    void RemoveCard();
    void ShowCardsList();
    void ShowCardNumbersList();
    void GetCardInfo();
    bool ValidateCardInfo(string cardNumber, string cvv2, string exDate);
    void PrintEditCardMenu(string[] lines, int i);
}