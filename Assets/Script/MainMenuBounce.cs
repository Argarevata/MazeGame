using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBounce : MonoBehaviour
{
    public Rigidbody2D myBody;
    public float speedX, speedY;

    // Start is called before the first frame update
    void Start()
    {
        float posX = Random.Range(-1.35f, 1.35f);
        float posY = Random.Range(-1.2f, 1.2f);

        transform.position = new Vector2(posX, posY);
    }

    // Update is called once per frame
    void Update()
    {
        myBody.velocity = new Vector2(speedX, speedY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Up")
        {
            speedY = Mathf.Abs(speedY) * -1;
        }

        if (collision.gameObject.name == "Down")
        {
            speedY = Mathf.Abs(speedY);
        }

        if (collision.gameObject.name == "Right")
        {
            speedX = Mathf.Abs(speedX) * -1;
        }

        if (collision.gameObject.name == "Left")
        {
            speedX = Mathf.Abs(speedX);
        }
    }
}
