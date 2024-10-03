using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool won = false;
    [HideInInspector]
    public bool lost = false;
    private bool playerTurn = true;
    public PlayerDealer playerHand;
    public PlayerDealer dealerHand;
    public Dealer dealer;
    public TextMeshProUGUI text;
    void FixedUpdate()
    {
        if(playerHand.ScoreHand() > 21 && playerTurn)
        {
            lost = true;
        }
        if(playerHand.ScoreHand() <= dealerHand.ScoreHand() && !playerTurn && dealer.DealerTurnOver() && dealerHand.ScoreHand() <= 21)
        {
            lost = true;
        }
        if(playerHand.ScoreHand() > dealerHand.ScoreHand() && dealer.DealerTurnOver() && playerHand.ScoreHand() <= 21)
        {
            won = true;
        }
        if(dealerHand.ScoreHand() > 21 && dealer.DealerTurnOver())
        {
            won = true;
        }
        if(won)
        {
            text.text = "You Won!!!";
            text.GetComponent<Animator>().SetBool("Won",true);
        }
        if(lost)
        {
            text.text = "You Lost...";
            text.GetComponent<Animator>().SetBool("Lost",true);
        }
    }

    public void SwapTurn()
    {
        if(playerHand.hand.Count == 0) return;
        playerTurn = false;
        dealer.StartDealersTurn();
    }
}
