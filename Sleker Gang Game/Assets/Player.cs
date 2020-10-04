using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
 
    Rigidbody2D myRigidbody2D;
    Animator myAnimator;
    Vector2 movement;
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
     
        myRigidbody2D.MovePosition(myRigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {

            case "Finish":
                int level = collision.gameObject.GetComponent<LevelLoader>().imageNumber;
                LoadNextLevel(level);
                break;
            default:
                break;
        }

    }
    void LoadNextLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}

   


