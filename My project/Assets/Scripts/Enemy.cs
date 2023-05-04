using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Enemy -> Subject to an Observer Design Pattern and a Singleton.
public class Enemy : Fighters {
    public static Enemy enemy {get; private set;}

    public Sprite normalState;
    public Sprite attackState;

    private void Awake() {
        if(enemy != null  && enemy != this) {
            Destroy(this);
        } else {
            enemy = this;
        }
    }
    // Methods executed during game
    void Start() {
        initializeVariables();
        speed = 7;
    }

    void Update() {
        enemyState(getSeconds(Time.time));
        findPlayer();
    }

    private int getSeconds(float time) {
        return (int)Mathf.Round(time);
    }

    private void enemyState(int time) {
        if(time % 3 == 0) {
            SR.sprite = attackState;
            OnTriggerStay2D(Player.player.BC);
        } else {
            SR.sprite = normalState;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (BC.IsTouching(collision)) {
            Player.player.incrementStats();
        }
    }

    private void findPlayer() {
        if (Player.player.RB.position.x < RB.position.x) {
            RB.velocity = new Vector2(-speed, RB.velocity.y);
        } else {
            RB.velocity = new Vector2(speed, RB.velocity.y);
        }
        
        enemyJump((int)Mathf.Round(Time.time));
        spriteFace(RB.velocity.x);
    }

    private void enemyJump(int time) {
        if(time % 3 == 0) {
            if(RB.velocity.y == 0) {
                RB.velocity = Vector2.up * jump/2f;
            }
        }
    }
}
