using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public BoxCollider2D bc2;
    public int jump;
    private int speed = 15;
    private int jumpCounter = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, 0);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter != 0) {
            rb.velocity = Vector2.up * jump;
            jumpCounter--;
        }
        
        OnTriggerStay2D(this.bc);

        var moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.IsTouching(bc2))
        {
            jumpCounter = 3;
        }
    }
}
