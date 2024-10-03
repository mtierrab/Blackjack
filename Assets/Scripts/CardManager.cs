using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Sprite blackCard;
    public Sprite pinkCard;
    private SpriteRenderer sp;

    private bool isBlackCard = true;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = blackCard;
    }

    public void Switch()
    {
        isBlackCard = !isBlackCard;
        sp.sprite = isBlackCard ? blackCard : pinkCard;
    }

    public Sprite GetCurrentCard()
    {
        return isBlackCard ? blackCard : pinkCard;
    }

}
