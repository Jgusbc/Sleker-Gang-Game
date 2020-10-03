using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Game config inside Unity UI
    [SerializeField] float moveSpeed = 10f;

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;

    //State
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        transform.position = new Vector2(newXPos, newYPos);
        SetAnimation(deltaX, deltaY);

    }

    private void SetAnimation(float deltaX, float deltaY)
    {
        if (deltaX != 0 && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && deltaX > 0)
        {
            myAnimator.SetBool("RightWalk", true);
        }
        else if (deltaX != 0 && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && deltaX < 0)
        {
            myAnimator.SetBool("LeftWalk", true);
        }
        else if (deltaY != 0 && myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            myAnimator.SetBool("FrontWalk", true);
        }
        else
        {
            myAnimator.SetBool("RightWalk", false);
            myAnimator.SetBool("LeftWalk", false);
            myAnimator.SetBool("FrontWalk", false);
        }
    }
}

