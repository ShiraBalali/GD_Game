using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D ball;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        ball = GetComponent<Rigidbody2D>();
        ball.velocity = new Vector2(-12, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.position.y < -20)
        {
            ball.position = new Vector2(5.42f, -1.48f);
            ball.velocity = new Vector2(-15, 0);
        }
    }
}
