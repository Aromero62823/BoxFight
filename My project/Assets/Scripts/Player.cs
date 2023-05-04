using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Player -> Subject to Observer Class and Singleton.
public class Player : Fighters {
    public static Player player {get;private set;} // Player is a Singleton, only 1 instance
  
    private int comboLength = 3;
    private int jumpCounter = 1;

    private void Awake() {
        if(player != null && player != this) {
            Destroy(this);
        } else { 
            player = this;
        }
    }

    void Start() {
        initializeVariables();
        speed = 15;
    }

    private void FixedUpdate() {
        playerInput();
        itemCollect();
        resetJump();
    }

    // The player's input
    private void playerInput() {
        var moveX = Input.GetAxis("Horizontal");
        RB.velocity = new Vector2(moveX * speed, RB.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter != 0) {
            // Execute jump animation per KeyCode.Space pressed //
            RB.velocity = Vector2.up * jump;
            jumpCounter--;
        }
        spriteFace(RB.velocity.x);
        fightingInput();
    }

    // player's fighting Input
    private void fightingInput() {
        if (Input.GetKeyDown(KeyCode.O)) {
            if (comboLength > 0) {
                if (!SR.flipX) {
                    RB.transform.position = new Vector2(RB.transform.position.x + fightDistance, RB.transform.position.y);
                    isAttacking();
                } else {
                    RB.transform.position = new Vector2(RB.transform.position.x - fightDistance, RB.transform.position.y);
                    isAttacking();
                }
                comboLength--;
            } else {
                // reset the comboLength that will only be reset after a 1-second delay
                Invoke("resetComboLength", 0.5f);
            }
        }
    }

    private void isAttacking() {
        if (BC.IsTouching(Enemy.enemy.BC)) {
            Enemy.enemy.incrementStats();
        }
    }

    private void resetComboLength() {
        comboLength = 3;
    }

    private void resetJump() {
        if(RB.velocity.y == 0f) {
            jumpCounter = 1;
        }
    }

    private void itemCollect() {
        if(BC.IsTouching(RedMushroom.redMushroom.BC)) {
            RedMushroom.redMushroom.getValues();
        } else if(BC.IsTouching(GreenMushroom.greenMushroom.BC)) {
            GreenMushroom.greenMushroom.getValues();
        }
    }
}
