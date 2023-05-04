using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroom : GameItems, Item {
    public static RedMushroom redMushroom {get; private set;}
    private float startX;
    private void Awake() {
        if (redMushroom != null && redMushroom != this) {
            Destroy(this);
        } else {
            redMushroom = this;
        }
    }
    void Start() {
        random = new System.Random();
        trait = traits.Strength;
        startX = random.Next(-5, 5);
        value = random.Next(0, 5);
        BC = this.GetComponent<BoxCollider2D>();
    }
 
    public void getValues() {
        Player.player.damage = Player.player.damage + value;
        transform.position = new Vector2(1000f, 100f);
    }
}
