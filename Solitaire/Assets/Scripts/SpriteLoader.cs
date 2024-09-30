using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.U2D;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _cardsAtlas;

    private List<Sprite>[] _spritesGroup;
    private Sprite[] _allSprites;

    private Regex _numberRegex;

    private void Awake()
    {
        _allSprites = new Sprite[_cardsAtlas.spriteCount];
        _spritesGroup = new List<Sprite>[13];
        _cardsAtlas.GetSprites(_allSprites);

        _numberRegex = new Regex(@"^\d+");
    }

    public List<Sprite>[] GetSpritesGroup()
    {
        foreach (Sprite sprite in _allSprites)
        {
            int rank = ExtractNumber(sprite.name);

            if (_spritesGroup[rank] == null)
                _spritesGroup[rank] = new List<Sprite>(4);

            _spritesGroup[rank].Add(sprite);
        }

        return _spritesGroup;
    }

    private int ExtractNumber(string spriteName)
    {
        var match = _numberRegex.Match(spriteName);
        if (match.Success)
            return int.Parse(match.Value);

        throw new System.Exception("Number not found in sprite name");
    }
}
