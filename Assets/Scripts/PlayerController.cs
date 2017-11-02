using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float speed = 1f;
    private bool canMoveUp = true;
    private bool canMoveDown = true;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
	    	
	}

	void Update ()
    {
        MovePlayer(Input.GetAxis("Vertical"));
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
        if ( (movementSpeed > 0 && !canMoveUp) 
            || (movementSpeed < 0 && !canMoveDown) )
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
