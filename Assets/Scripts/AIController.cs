using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Rigidbody2D rigid;
    private BoxCollider2D col;
    public float speed = 7f;
    private bool canMoveUp = true;
    private bool canMoveDown = true;
    public Transform ball;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    void Start()
    {

    }

    void Update()
    {
    //    Debug.Log(ball.position.y - transform.position.y);
        float targetDirection = Mathf.Sign(ball.position.y - transform.position.y);
        bool goingToCatchBall = (transform.position.y + col.offset.y + col.size.y / 2 > ball.position.y ) && (transform.position.y + col.offset.y - col.size.y / 2 < ball.position.y);
        
        //MovePlayer(targetDirection);
        if(!goingToCatchBall) {
            Debug.Log("NOT GOING TO CATCH BALL");
            Debug.Log(col.offset.y + col.size.y / 2 + " ::::: " + ball.position.y);
            Debug.Log(col.offset.y - col.size.y / 2 + " ::::: " + ball.position.y);
            rigid.MovePosition(new Vector2(transform.position.x, transform.position.y + targetDirection * speed * Time.deltaTime));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Wall":
                HandleEnterWallCollision(collision);
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.collider.tag)
        {
            case "Wall":
                HandleExitWallCollision(collision);
                break;
        }
    }

    private void MovePlayer(float movementSpeed)
    {
        if ((movementSpeed > 0 && !canMoveUp)
            || (movementSpeed < 0 && !canMoveDown))
        {
            movementSpeed = 0;
        }

        rigid.velocity = new Vector2(0, movementSpeed * speed);
    }

    private void StopPlayer()
    {
        MovePlayer(0);
    }

    private void HandleEnterWallCollision(Collision2D collision)
    {
        if (collision.transform.position.y > transform.position.y) //wall is above player
        {
            canMoveUp = false;
        }
        else if (collision.transform.position.y < transform.position.y) //wall is below player
        {
            canMoveDown = false;
        }
    }

    private void HandleExitWallCollision(Collision2D collision)
    {
        canMoveUp = true;
        canMoveDown = true;
    }
}
