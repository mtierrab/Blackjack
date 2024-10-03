using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDealer : MonoBehaviour
{    public Deck deckScript;
    public List<Card> hand = new List<Card>();
    private List<GameObject> sprites = new List<GameObject>();
    private float cardSize = 1.6f;
    void FixedUpdate()
    {
        float startPos = -(hand.Count - 1)*(cardSize/2);
        foreach (GameObject card in sprites){
            card.transform.localPosition = new Vector3(startPos,0,1);
            startPos+=cardSize;
        }
    }
    public void StartHand()
    {
        if(hand.Count > 0) return;
        GetCard();
        GetCard();
    }
    public void GetCard()
    {
        hand.Add(deckScript.DealCard());
        GameObject newSprite = new GameObject("card_"+hand.Count);
        newSprite.transform.parent = gameObject.transform;
        SpriteRenderer sr = newSprite.AddComponent<SpriteRenderer>();
        sr.sprite = hand[hand.Count-1].face;
        sr.sortingOrder = hand.Count;
        sr.transform.localScale = new Vector3(6,6,1);
        sprites.Add(newSprite);
    }

    public void Hit(){
        if(hand.Count == 0 || ScoreHand() > 21) return;
        GetCard();
    }

    public int ScoreHand()
    {
        int score = 0;
        bool hasAce = false;
        foreach (Card card in hand)
        {
            if(card.val == 1 && !hasAce) hasAce = true;
            else score+=card.val;
        }
        if(hasAce)
        {
            if(score + 11 <= 21) score+=11;
            else score += 1;
        }
        return score;
    }
}
