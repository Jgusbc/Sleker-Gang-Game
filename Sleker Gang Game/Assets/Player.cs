using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Game config inside Unity UI
    [SerializeField] float moveSpeed = 10f;

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;

    Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Move();
        myRigidbody2D.MovePosition(myRigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        transform.position = new Vector2(newXPos, newYPos).normalized;
        SetAnimation(deltaX, deltaY);

    }

    private void SetAnimation(float deltaX, float deltaY)
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && deltaX > 0)
        {
            myAnimator.SetBool("RightWalk", true);
        }
        else if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && deltaX < 0)
        {
            myAnimator.SetBool("LeftWalk", true);
        }
        else if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && deltaY < 0)
        {
            myAnimator.SetBool("FrontWalk", true);
        }
        else if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && deltaY > 0)
        {
            myAnimator.SetBool("BackWalk", true);
        }
        else
        {
            myAnimator.SetBool("RightWalk", false);
            myAnimator.SetBool("LeftWalk", false);
            myAnimator.SetBool("FrontWalk", false);
            myAnimator.SetBool("BackWalk", false);
        }
    }
}

