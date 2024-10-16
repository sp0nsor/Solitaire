public interface ICardContainer
{
    void AddDeckCard(Card card, int rank);
    void AddTableCard(Card card, int rank);
    Card GetDeckCard();
    Card GetFirstTableCard(int croup);
}