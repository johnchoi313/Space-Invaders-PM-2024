using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator bossAnimator;

    public float waitTimerMin = 1f;
    public float waitTimerMax = 3f;
    public float waitTimer = 0f;

    public float attackTime = 3f;
    public float attackTimer = 0f;
    public bool attacking = false;

    public float attackSpeed = 6f;

    public float moveSpeed = 3f;
    public bool movingLeft = true;
    public float xMin = -20f;
    public float xMax = 20f;

    // Start is called before the first frame update
    void Start()
    {
        waitTimer = Random.Range(waitTimerMin, waitTimerMax);
    }
    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (attacking == false)
        {
            if (waitTimer <= 0)
            {
                Debug.Log("Boss switched to attacking!");
                attackTimer = attackTime;
                attacking = true;
                bossAnimator.SetBool("Attacking", true);
            }
            else
            {
                waitTimer = waitTimer - dt;

                if(movingLeft == true) { transform.Translate(-moveSpeed * dt, 0, 0); }
                else { transform.Translate(moveSpeed * dt, 0, 0); }
                if(transform.position.x < xMin) { movingLeft = false; }
                if(transform.position.x > xMax) { movingLeft = true; }
            }
        }
        else
        {
            if (attackTimer <= 0)
            {
                Debug.Log("Boss switched to waiting!");
                waitTimer = Random.Range(waitTimerMin, waitTimerMax);
                attacking = false;
                bossAnimator.SetBool("Attacking", false);
            }
            else
            {
                attackTimer = attackTimer - Time.deltaTime;
                
                if (attackTimer > attackTime / 2f)
                {
                    transform.Translate(0, -attackSpeed * dt, 0);
                }
                if(attackTimer <= attackTime / 2f)
                {
                    transform.Translate(0, attackSpeed * dt, 0);
                }
            
            }
        }
    }
}
