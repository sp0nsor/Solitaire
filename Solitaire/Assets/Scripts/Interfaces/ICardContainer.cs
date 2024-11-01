public interface ICardContainer
{
    int GetCardCount();
    Card GetDeckCard();
    public void MakeReverseDeck();
    void RemoveDeckCard(Card card);
    Card GetFirstTableCard(int croup);
    void AddDeckCard(Card card, int rank);
    void RemoveTableCard(int heap, Card card);
    void AddTableCard(Card card, int rank, int heap);
}
