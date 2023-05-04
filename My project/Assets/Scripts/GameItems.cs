using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameItems : MonoBehaviour {
    public Item _item;
    protected float value = 0f;
    public BoxCollider2D BC;
    public Rigidbody2D RB;
    protected System.Random random;
    protected traits trait;


    protected enum traits {
        Speed,
        Strength
    }

}
