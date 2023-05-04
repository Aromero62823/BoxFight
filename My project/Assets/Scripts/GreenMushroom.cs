using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMushroom : GameItems {
    public static GreenMushroom greenMushroom {get; private set;}
    private float startX;
    private void Awake() {
        if (greenMushroom != null && greenMushroom != this) {
            Destroy(this);
        } else {
            greenMushroom = this;
        }
    }
    void Start() {
        random = new System.Random();
        trait = traits.Speed;
        startX = random.Next(-5, 5);
        value = random.Next(0, 3);
        BC = this.GetComponent<BoxCollider2D>();
    }
    

    public void getValues() {
        Player.player.speed = Player.player.speed + (int) value;
        print(Player.player.speed);
        transform.position = new Vector2(1000f, 1000f);
    }
}
