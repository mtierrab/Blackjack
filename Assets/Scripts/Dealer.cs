using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public PlayerDealer hand;
    public PlayerDealer playerHand;
    private bool playing = false;

    void FixedUpdate()
    {
        if(playing)
        {
            MakePlay();
        }
    }

    public void MakePlay()
    {
        if(hand.ScoreHand() < 17 && hand.ScoreHand() < playerHand.ScoreHand())
        {
            hand.GetCard();
        }else{
            playing = false;
        }
    }

    public void StartDealersTurn()
    {
        playing = true;
    }

    public bool DealerTurnOver(){return playing;}
}
