using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    public CardManager cardManager;
    void FixedUpdate()
    {
        UpdateCardBack();
        
    }

    public void UpdateCardBack()
    {
        GetComponent<SpriteRenderer>().sprite = cardManager.GetCurrentCard();
    }
}
