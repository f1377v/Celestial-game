using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] asteroidPatterns;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float speedup;
    public float minTime = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenSpawn <= 0)
        {
            int rand = Random.Range(0, asteroidPatterns.Length);
            Instantiate(asteroidPatterns[rand], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > minTime)
            {
                startTimeBetweenSpawn -= speedup;
            }
        }else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
