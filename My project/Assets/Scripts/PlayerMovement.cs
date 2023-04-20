using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : Fighters {

    public BoxCollider2D bc2; // Ground
    
    public bool isFacingRight = true;
    private float fightIncrement = 0.5F;
    public GameObject enemy;
    private Image enemyHealth;

    // Start is called before the first frame update
    void Start() {
        // Setting the frameRate
        Application.targetFrameRate = 75;

        // Setting player values
        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        this.GetComponent<Rigidbody2D>().position = new Vector2(this.GetComponent<Rigidbody2D>().position.x, startY);
        this.GetComponent<SpriteRenderer>().flipX = isFacingRight;

        speed = 15;

        enemyHealth = GameObject.Find("OpponentHealth(Parent)").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {   
        var moveX = Input.GetAxis("Horizontal");
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * speed, this.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter != 0) {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.up * jump;
            jumpCounter--;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            isFacingRight = false;
        } else if (Input.GetKeyDown(KeyCode.D)) {
            isFacingRight = true;
        }
        fightingInput();
    }

    // Private Methods
    private void FixedUpdate() {
        OnTriggerStay2D(this.GetComponent<BoxCollider2D>());
    }

    private void fightingInput() {
        if (Input.GetKeyDown(KeyCode.O)) {
            if (comboLength > 0) {
                if (isFacingRight) {
                    this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().transform.position.x + fightIncrement, 
                        this.GetComponent<Rigidbody2D>().transform.position.y);
                } else {
                    this.GetComponent<Rigidbody2D>().transform.position = new Vector2(this.GetComponent<Rigidbody2D>().transform.position.x - fightIncrement, 
                        this.GetComponent<Rigidbody2D>().transform.position.y);
                }
                comboLength--;
            } else {
                comboLength = 3;
            } if(this.gameObject.GetComponent<BoxCollider2D>().IsTouching(enemy.GetComponent<BoxCollider2D>())) {
                enemyHealth.fillAmount = enemyHealth.fillAmount - damage;
                switch(isFacingRight) {
                    case true:
                        //enemy.GetComponent<Rigidbody2D>().velocity = Vector2.up * jump;
                        enemy.GetComponent<Rigidbody2D>().velocity = Vector2.right * jump;
                        break;

                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.IsTouching(bc2)) {
            jumpCounter = 1;
        }
    }
}
