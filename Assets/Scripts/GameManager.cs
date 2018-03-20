using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform[] blocks;
    public Transform block;
    public Transform playerPlatform;
    static private float timeSinceLevelStart;
    public Transform startPosition;

    static private float gravityScale = 1.0f;

    public float secondsBetweenBlocks = 3.0f;

    static public int count;

    static public float TimeSinceLevelStart
    {
        get { return timeSinceLevelStart;}

        set { timeSinceLevelStart = value;}
    }

    static public float GravityScale
    {
        get { return gravityScale;}

        set { gravityScale = value;}
    }




    // Use this for initialization
    void Start()
    {
        Instantiate(playerPlatform, startPosition.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        secondsBetweenBlocks -= Time.deltaTime;
        if (secondsBetweenBlocks <= 0)
        {
            BlockInstantiate();
            secondsBetweenBlocks = 3.0f;
        }

        TimeSinceLevelStart += Time.deltaTime;
        if (TimeSinceLevelStart > 10)
        {
            GravityScale = Mathf.Ceil(timeSinceLevelStart / 10);
        }

        Debug.Log(count);
    }

    void BlockInstantiate()
    {
        Instantiate(block, new Vector2(Mathf.Round(Random.Range(-3, 3)), GameObject.Find("BlockInitialization").transform.position.y), Quaternion.identity);
    }
}
