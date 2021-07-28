using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get { return instance; } }
    static GameController instance;
    public float score;
    public float timeBetweenKills = 10;
    public TMP_Text scoreTracker;
    public TMP_Text killTimer;
    public List<GameObject> enemies = new List<GameObject>();

    float timer;

    public bool playing = false;

    private void Start()
    {
        instance = this;
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
                ClearAllEnemies();
                playing = false;
            }
        }
    }

    public void UpdateScore(float change = 1.0f)
    {
        scoreTracker.text = (++score).ToString() + "\n targets elimated";
    }
    public void AddTime(float change)
    {
        timer += change;
    }
    void ClearAllEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Destroy(enemies[i]);
        }
        enemies.Clear();
    }
}
