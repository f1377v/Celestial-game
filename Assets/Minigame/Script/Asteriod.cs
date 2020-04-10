using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public GameObject particleEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Instantiate(particleEffect, transform.position, Quaternion.identity);
            collision.GetComponent<Planet>().health -= damage;
            Debug.Log(collision.GetComponent<Planet>().health);
            Destroy(gameObject);
        }
    }
}
 