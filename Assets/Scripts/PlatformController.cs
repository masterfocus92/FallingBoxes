using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;

    Vector2 currentPosition;
    Vector2 targetPosition;

    public float speed;
    private float t;
    private float moveDirection;

    public Transform leftPosition;
    public Transform rightPosition;
    public Transform centerPosition;

    public Sprite[] blockSprites;
    

    bool moving = false;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = blockSprites[Random.Range(0, blockSprites.Length - 1)];

        leftPosition = GameObject.Find("LeftPlace").transform;
        centerPosition = GameObject.Find("CenterPlace").transform;
        rightPosition = GameObject.Find("RightPlace").transform;
        t = 1 / speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;

        PlayerInput();

        Shift(moving);

    }

    void Shift(bool move)
    {
        if (move)
        {

            rb.position = Vector2.Lerp(currentPosition, targetPosition, t);

        }

    }

    //private bool CanInput
    //{
    //    get
    //    {
    //        if (Vector2.Distance(transform.position, leftPosition.position) < 0.05 ||
    //            Vector2.Distance(transform.position, centerPosition.position) < 0.05 ||
    //            Vector2.Distance(transform.position, rightPosition.position) < 0.05)
    //        {
    //            return true;
    //        }
    //        else return false;
    //    }
    //}

    int CurrentPosition()
    {
        if (Vector2.Distance(currentPosition, leftPosition.transform.position) < 1)
        {
            return -1;
        }
        else if (Vector2.Distance(currentPosition, centerPosition.transform.position) < 1)
        {
            return 0;
        }
        else return 1;
    }

    void SetTarget()
    {
        if( moveDirection < 0)
        {
            switch (CurrentPosition())
            {
                case -1:
                    moving = false;
                    return;
                case 0:
                    targetPosition = leftPosition.transform.position;
                    break;
                case 1:
                    targetPosition = centerPosition.transform.position;
                    break;
            }
        }
        else if (moveDirection > 0)
        {
            switch (CurrentPosition())
            {
                case -1:
                    targetPosition = centerPosition.transform.position;
                    break;
                case 0:
                    targetPosition = rightPosition.transform.position;
                    break;
                case 1:
                    moving = false;
                    return;
            }
        }

    }

    void PlayerInput()
    {
        if (Input.GetButtonDown("left"))
        {
            moving = true;
            moveDirection = -1.0f;
            SetTarget();
        }
        if (Input.GetButtonDown("right"))
        {
            moving = true;
            moveDirection = 1.0f;
            SetTarget();
        }
    }
}
