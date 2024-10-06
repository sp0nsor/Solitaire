using System.Collections.Generic;

public interface IDeck
{
    List<List<int>> GenerateCombinations();
    List<CardModel>[] GetCardGroups();
}
