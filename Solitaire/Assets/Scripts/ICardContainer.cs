public interface ICardContainer
{
    void AddDeckCard(Card card, int rank);
    void AddTableCard(Card card, int rank, int heap);
    Card GetDeckCard();
    Card GetFirstTableCard(int croup);
    void RemoveCard(Card card);
    public void MakeReverseDeck();
}