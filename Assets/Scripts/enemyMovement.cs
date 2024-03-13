using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float speed = 0.8f;
    public float range = 3;

    float startingY;
    int dir = 1;
    private void Start()
    {
        startingY = transform.position.y;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime*dir);
        if(transform.position.y < startingY || transform.position.y > startingY+range)
            dir *= -1;
    }
}
