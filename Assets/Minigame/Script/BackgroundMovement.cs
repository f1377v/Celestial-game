using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed;
    public float repeating;
    public float starting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= repeating)
        {
            Vector2 position = new Vector2(starting, transform.position.y);
            transform.position = position;
        }
    }
}
