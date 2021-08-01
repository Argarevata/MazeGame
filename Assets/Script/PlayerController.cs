using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Rigidbody2D myBody;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2(speed, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            myBody.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            myBody.velocity = new Vector2(0, -speed);
        }
        else
        {
            myBody.velocity = Vector2.zero;
        }
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Obstacle")
        {
            print("KENA MUSUH");
        }
        else if (otherCollider.tag == "Finish")
        {
            print("FINISH COYY!");
        }
    }
}
