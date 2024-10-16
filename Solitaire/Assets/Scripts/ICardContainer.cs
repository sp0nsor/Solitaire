public interface ICardContainer
{
    void AddDeckCard(Card card, int rank);
    void AddDeckCard(Card card);
    void AddTableCard(Card card, int rank);
    Card GetDeckCard();
    Card GetFirstTableCard(int croup);
    void RemoveCard(Card card);
}