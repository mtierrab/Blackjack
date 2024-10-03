using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Sprite[] cardSprites;
    int currentIndex = 0;
    Card[] cards = new Card[52];
    void Start()
    {
        InitCards();
        Shuffle();
    }
    void InitCards()
    {
        for(int i = 0; i < cardSprites.Length; i++)
        {
            int num = (i+1) % 13;

            if(num > 10 || num == 0)
            {
                num = 10;
            }
            cards[i] = new Card(cardSprites[i],num);
        }
    }

    public void Shuffle()
    {
        for(int i = cardSprites.Length -1; i > 0; --i)
        {
            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * (cardSprites.Length-1));
            Card card = cards[i];
            cards[i] = cards[j];
            cards[j] = card;
        }
    }
    public Card DealCard()
    {
        Card card = cards[currentIndex];
        currentIndex++;

        return card;
    }
}

public class Card 
{
    public Sprite face;
    public int val;
    public Card()
    {
        face = null;
        val = 0;
    }
    public Card(Sprite f, int v)
    {
        face = f;
        val = v;
    }
}
