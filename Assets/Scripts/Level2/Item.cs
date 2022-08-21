using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item
{
    public enum ItemType { None, PaperBall , Cans };
    public ItemType itemType;

    public Sprite getSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.None: return null;
            case ItemType.PaperBall: return ItemAssets.Instance.PaperBallSprite;
            case ItemType.Cans: return ItemAssets.Instance.CansSprite;
        }
    }
}
