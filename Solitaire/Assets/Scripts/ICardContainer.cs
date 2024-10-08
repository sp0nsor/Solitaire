public interface ICardContainer
{
    void AddDeckCard(Card card);
    void AddTableCard(Card card);
    Card GetDeckCard();
}