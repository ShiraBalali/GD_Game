using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;


    Quaternion playerRotation;
    MovementController movementController;


    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    void Start()
    {
        checkpointPos = transform.position;
        playerRb = GetComponent<Rigidbody2D>();
        playerRotation = transform.rotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -20)
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
        playerRotation = transform.rotation;
    }

    void Die()
    {
        playerRb.gravityScale = 1;
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.velocity = new Vector2(0, 0);
        playerRb.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        //transform.rotation = playerRotation;
        transform.rotation = new UnityEngine.Quaternion(0, 0, 0, 0);
        transform.localScale = new Vector3(0.415382f, 0.44693f, 1);
        playerRb.simulated = true;
        movementController.UpdateRelativeTransform();

    }
}

