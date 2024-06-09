using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSet : MonoBehaviour
{

    [SerializeField] Transform Player;
    [SerializeField] float yExtra;
    private void FixedUpdate()
    {
        Vector2 newPos= new Vector2(Player.position.x, Player.position.y+yExtra);
        transform.position = newPos;
    }
}
