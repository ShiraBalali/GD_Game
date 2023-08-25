using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;

    Quaternion playerRotation;
    MovementController movementController;

    bool dying = false;

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
        if (!dying)
        {
            dying = true;
            ScoreKeeper.Penalty();
            StartCoroutine(Respawn(0.5f));
        }
    }

    IEnumerator Respawn(float duration)
    {
        playerRb.simulated = false;
        playerRb.gravityScale = 1;
        playerRb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        dying = false;
        
        //transform.rotation = playerRotation;
        transform.rotation = new UnityEngine.Quaternion(0, 0, 0, 0);
        
        transform.localScale = new Vector3(0.415382f, 0.44693f, 1);
        playerRb.simulated = true;
        movementController.UpdateRelativeTransform();

    }
}

