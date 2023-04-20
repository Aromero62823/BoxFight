using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Fighters : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected int jump = 15;
    protected int speed;
    protected int jumpCounter = 1;
    protected int comboLength = 3;

    protected float startX;

    protected float startY = 3;
    protected float damage = 0.05f;
    protected bool fightingState = false;
}
