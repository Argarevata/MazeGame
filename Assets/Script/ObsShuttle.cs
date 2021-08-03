using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsShuttle : MonoBehaviour
{
    public Transform obs, pointA, pointB;
    public bool goToA;
    public float speed;

    void Update()
    {
        if (goToA)
        {
            if (obs.position != pointA.position)
            {
                obs.position = Vector2.MoveTowards(obs.position, pointA.position, speed * Time.timeScale);
            }
            else
            {
                goToA = false;
            }
        }
        else
        {
            if (obs.position != pointB.position)
            {
                obs.position = Vector2.MoveTowards(obs.position, pointB.position, speed * Time.timeScale);
            }
            else
            {
                goToA = true;
            }
        }
    }
}
