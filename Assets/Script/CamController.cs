using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform player;
    public float buffX, buffY;

    void Update()
    {
        transform.position = new Vector3(0 + buffX, player.position.y + buffY, -10);
    }
}
