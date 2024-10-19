public interface ICardContainer
{
    void AddDeckCard(Card card, int rank);
    void AddTableCard(Card card, int rank, int heap);
    Card GetDeckCard();
    Card GetFirstTableCard(int croup);
    void RemoveDeckCard(Card card);
    int GetCardCount();
    void RemoveTableCard(int heap, Card card);
    public void MakeReverseDeck();
}