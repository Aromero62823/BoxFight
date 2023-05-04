using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Fighters : MonoBehaviour, Subject {
    protected int jump = 18;
    public int speed;
    public float damage = 0.05f;
    protected float fightDistance = 0.5f;

    protected ArrayList observers; // Observers

    // The general components that are called within each class object
    public Rigidbody2D RB;
    public BoxCollider2D BC;
    public SpriteRenderer SR;

    public Sprite[] healthSprites; // Lives as sprites
    public GameObject healthS; // Lives GameObject
    public Image health;
    public Image winScreen;

    protected void spriteFace(float velocity) {
        if (velocity < 0) {
            SR.flipX = true;
        } else if (velocity > 0) {
            SR.flipX = false;
        }
    }
    
    protected void initializeVariables() {
        RB = this.GetComponent<Rigidbody2D>();
        BC = this.GetComponent<BoxCollider2D>();
        SR = this.GetComponent<SpriteRenderer>();

        observers = new ArrayList();

        RB.constraints = RigidbodyConstraints2D.FreezeRotation;

        Application.targetFrameRate = 75;

        addGameObject(new Lives(healthS, healthSprites));
        addGameObject(new Health());
        addGameObject(new winPanel(winScreen));
    }

    public void addGameObject(Observer o) {
        observers.Add(o);
    }

    public void incrementStats() {
        foreach (Observer o in observers) {
            o.updateVals(damage, health);
        }
    }
}
