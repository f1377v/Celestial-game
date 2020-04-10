using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public string title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        title = "score: ";
        scoreDisplay.text = title + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Obstacle") && Planet.isAlive)
        {

            score++;
            Star.Currency += 3;
            Debug.Log(score);
        }
    }
}
