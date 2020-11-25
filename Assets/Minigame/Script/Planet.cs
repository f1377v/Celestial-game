using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float maxHeight;
    public float minHeight;
    public int health = 3;
    public GameObject planeteffect;
    public Text healthDisplay;
    string title;
    public GameObject gameOver;
    public static bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        title = "Health: ";
        healthDisplay.text = title + health.ToString();
        if (health == 0 )
        {
            Planet.isAlive = false;
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {

            Instantiate(planeteffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        } else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight) {
            Instantiate(planeteffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
 
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
