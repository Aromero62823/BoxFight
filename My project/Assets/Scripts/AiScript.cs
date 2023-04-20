using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiScript : Fighters
{
    public Rigidbody2D aiRb;
    private Rigidbody2D player;
    public Image health;

    // Start is called before the first frame update
    void Start()
    {
        aiRb = GetComponent<Rigidbody2D>();
        aiRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        aiRb.position = new Vector2(aiRb.position.x, startY);
        speed = 5;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.position.x < aiRb.position.x) {
            aiRb.velocity = new Vector2(-speed, aiRb.velocity.y);
        } else if(player.position.x > aiRb.position.x) {
            aiRb.velocity = new Vector2(speed, aiRb.velocity.y);
        } else {
            aiRb.velocity = new Vector2(aiRb.velocity.x, aiRb.velocity.y);

            checkHealth();
        }
    }

    private void checkHealth() {
        if(health.fillAmount == 0) {
            Debug.Log("Enemy has died...");
        }
    }
    
}
