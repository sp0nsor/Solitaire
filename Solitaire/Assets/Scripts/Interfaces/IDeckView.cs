using System;

public interface IDeckView
{
    event Action OnNextButtonClick;

    void MoveCardToEndStack(Card card);
    void ShowCard(Card card);
    void ShowLoseMessage();
    void ShowWinMessage();
}
