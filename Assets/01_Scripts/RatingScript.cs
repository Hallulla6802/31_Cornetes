using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RatingScript : MonoBehaviour
{
    public int currentRating;
    public int ratingNeeded;
    public bool hasRating;
    public TMP_Text ratingText;
    void Awake()
    {
        ratingText.text = "Rating: " + currentRating + " / " + ratingNeeded;
    }
    public void GiveRating(int ratingAmount)
    {
        currentRating += ratingAmount;
        ratingText.text = "Rating: " + currentRating + " / " + ratingNeeded;
    }
    public void CheckRatingEndFight()
    {
        if(ratingNeeded == currentRating)
        {
            hasRating = true;
        }
        /* else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } */
    }
}
