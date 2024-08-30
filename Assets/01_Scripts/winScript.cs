using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
public RatingScript ratingScript;
public Rival1Variables rival1Variables;
public DeathScreenScript deathScreenScript;
public GameObject rival;
    void Update()
    {
        if (rival1Variables.rival1CurrentLife < 0)
        {
            rival1Variables.rival1CurrentLife = 0;
        }
        if(rival1Variables.rival1CurrentLife == 0)
        {
            rival.SetActive(false);
            ratingScript.CheckRatingEndFight();                           
            if(ratingScript.hasRating)
            {
                deathScreenScript.TriggerWinScreen();
            }
            else
            {
                deathScreenScript.TriggerRatingScreen();
            }
        }
    }
    
}
