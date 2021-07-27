using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float score;
    public float timeBetweenKills = 10;
    public TMP_Text scoreTracker;
    public TMP_Text killTimer;

    float timer;

    public bool playing = false;

    private void Start()
    {
        timer = timeBetweenKills;
    }
    private void Update()
    {
        if (playing)
        {
            timer -= Time.deltaTime;
            killTimer.text = timer.ToString() + " s";
            if(timer <= 0)
            {
                //LOSE
                playing = false;
            }
        }
    }

    public void UpdateScore(float change)
    {
        score += change;
        scoreTracker.text = score.ToString() + "\n targets elimated";
    }
    public void AddTime(float change)
    {
        timer += change;
    }
}
