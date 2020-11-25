using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimize : MonoBehaviour
{
    public float destroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
