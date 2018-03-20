using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer sr;
    public Sprite[] blockSprites;
    float destroyPointY; // in this point block will be destroy



    // Use this for initialization
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        sr.sprite = blockSprites[Random.Range(0, blockSprites.Length - 1)];

        destroyPointY = GameObject.FindGameObjectWithTag("Player").transform.position.y - 1;

    }
    private void Update()
    {
       

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y <= destroyPointY)
        {
            GameManager.count += 5;
            GameObject.Destroy(this.gameObject);        // destroing block if it fall lower than playerplatform
        }


        rb.gravityScale = GameManager.GravityScale;     // set gravityscale for setting game difficult


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponentInChildren<SpriteRenderer>().sprite == sr.sprite)
        {
            GameManager.count += 10;

        }
        Destroy(this.gameObject);
    }

}
