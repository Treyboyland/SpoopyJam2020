using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegdayAI : MonoBehaviour
{
    //Change AI mode
    public bool chase;

    //State variables for animation controlling
    public bool isWalking;
    public bool finishedWalking;
    public bool isIdle;
    public bool isWindingUp;
    public bool isCharging;
    public bool finishedCharging;
    public bool isMovingLeft;
    public bool recentlyCharged;
    public bool isKicked;

    //Windup timer
    public int windupTimerDefault;
    public int windupTimer;
    public int maxChargeTime;
    public int maxChargeTimeDefault;
    public int chargeRefactoryPeriodDefault;
    public int chargeRefactoryPeriod;

    //Set the frequencies of each thing happening
    public float walkFreq;
    public float chargeFreq;

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
        //Start in an idle state
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
        isIdle = true;
        isKicked = false;
        finishedWalking = true;
        isWalking = false;
        isWindingUp = false;
        isCharging = false;
        finishedCharging = true;
        windupTimer = windupTimerDefault;
        chargeRefactoryPeriod = chargeRefactoryPeriodDefault;
        maxChargeTime = maxChargeTimeDefault;
        playerCharacter = Player.PlayerInstance != null ? Player.PlayerInstance.gameObject : playerCharacter;
        playSpace = PlaySpace.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Handles charging
        if (recentlyCharged)
        {
            chargeRefactoryPeriod -= 1;
            if (chargeRefactoryPeriod < 0)
            {
                chargeRefactoryPeriod = chargeRefactoryPeriodDefault;
                recentlyCharged = false;
            }
        }
        if (isKicked)
        {
            return;
        }
        float toCharge = Random.value;
        if (toCharge < chargeFreq && finishedCharging) isWindingUp = true;
        if ((isWindingUp || isCharging) && !recentlyCharged)
        {
            charge();
            checkIfMovingLeft();
        }
        else
        //Handle random walking
        {
            //Roll a random number
            float roll = Random.value;
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

    public void charge()
    {
        while (windupTimer > 0)
        {
            windupTimer -= 1;
            isWindingUp = true;
            return;
        }
        isWindingUp = false;
        isCharging = true;
        isIdle = false;
        isWalking = false;
        targetPosition = this.playerCharacter.transform.position;
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, Time.deltaTime * speed * 3);

        if ((Vector2)this.transform.position == targetPosition)
        {
            isCharging = false;
            finishedCharging = true;
            isIdle = true;
            windupTimer = windupTimerDefault;
            recentlyCharged = true;
        }

        while (maxChargeTime > 0)
        {
            maxChargeTime -= 1;
            return;
        }

        isCharging = false;
        finishedCharging = true;
        isIdle = true;
        windupTimer = windupTimerDefault;
        recentlyCharged = true;
        maxChargeTime = maxChargeTimeDefault;

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
        isWindingUp = false;
        if ((Vector2)this.transform.position == targetPosition)
        {
            isWalking = false;
            finishedWalking = true;
        }
    }

    //Handles sprite flipping
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
        animator.SetBool("isCharging", isCharging);
        animator.SetBool("isWindingUp", isWindingUp);
    }
}
