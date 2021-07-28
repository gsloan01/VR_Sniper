using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float interval = 7.0f;
    float timer = 0;
    public GameObject enemy;
    GameObject spawned = null;
    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.playing)
        {
            if (!spawned)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    spawned = Instantiate<GameObject>(enemy, transform.position, Quaternion.identity);
                    GameController.Instance.enemies.Add(spawned);
                }
            }
        }
    }
}
