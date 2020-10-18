using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Change AI mode
    public bool chase;

    //State variables for animation controlling
    public bool isWalking;
    public bool finishedWalking;
    public bool isIdle;
    public bool isKicked;
    public bool isMovingLeft;

    //Set the frequencies of each thing happening
    public float walkFreq;
    public float attackFreq;

    //Set the walking speed of the enemy
    public float speed;

    //To get random positions within play space
    public PlaySpace playSpace;

    //To handle meandering behavior
    public Vector2 currentPosition;
    public Vector2 targetPosition;
    public GameObject playerCharacter;

    //To get access to the animator object
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    //Physics stuff
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        Reinitialize();
    }

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            Reinitialize();
        }
    }

    void Reinitialize()
    {
        //Start in an idle state
        isIdle = true;
        finishedWalking = true;
        isWalking = false;
        isKicked = false;
        playerCharacter = Player.PlayerInstance != null ? Player.PlayerInstance.gameObject : playerCharacter;
        playSpace = playSpace == null ? PlaySpace.Instance : playSpace;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isKicked)
        {
            return;
        }
        if (chase)
        {
            targetPosition = playerCharacter.transform.position;
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * speed);
            isWalking = true;
            isIdle = false;
            finishedWalking = false;
            checkIfMovingLeft();

        }
        else
        {
            //Roll a random number
            float roll = Random.value;
            //Debug.Log(roll);
            //If criterion are met, then set a new target location and move towards it
            if (roll < walkFreq && !isWalking && finishedWalking)
            {
                getNewPosition();
                isWalking = true;
                isIdle = false;

            }
            //Handles sprite flipping
            checkIfMovingLeft();
            //Handles movement
            meander();
        }
        //Handles animations
        handleAnimations();
    }

    public void getNewPosition()
    {
        //Get a random position within the playspace and return it
        PolygonCollider2D collider = playSpace.GetComponent<PolygonCollider2D>();
        targetPosition = new Vector2(Random.Range(collider.bounds.min.x, collider.bounds.max.x), Random.Range(collider.bounds.min.y, collider.bounds.max.y));
        currentPosition = this.transform.position;
        finishedWalking = false;
    }

    //Handles the meandering state
    public void meander()
    {
        //Move between the two points
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * speed);

        if ((Vector2)this.transform.position == targetPosition)
        {
            isWalking = false;
            finishedWalking = true;
        }
    }

    public void checkIfMovingLeft()
    {
        if (targetPosition.x - this.transform.position.x < 0)
        {
            isMovingLeft = true;
            spriteRenderer.flipX = true;
        }
        else
        {
            isMovingLeft = false;
            spriteRenderer.flipX = false;
        }
    }

    public void handleAnimations()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isIdle", isIdle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            chase = true;
            isWalking = true;
            finishedWalking = false;
            isIdle = false;
        }
    }
}
