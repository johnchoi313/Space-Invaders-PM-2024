using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHit : MonoBehaviour
{
    public GameObject target;
    public GameObject explosion;

    public Animator bossAnimator;

    public string bulletTag = "PlayerBullet";
    public float hitThreshold = 3.0f;

    public int bossHealth = 10;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag(bulletTag);
        foreach (GameObject bullet in bullets)
        {
            float distance = Vector3.Distance(target.transform.position, bullet.transform.position);

            if (distance < hitThreshold)
            {
                Debug.Log("Target with name " + target.name + " was hit!");

                GameObject explosionCopy = Instantiate(explosion, bullet.transform.position, bullet.transform.rotation);
                Destroy(explosionCopy, 3);
                Destroy(bullet);

                if(bossHealth > 0)
                {
                    bossHealth = bossHealth - 1;
                    if (bossHealth <= 0)
                    {
                        gameManager.IncreaseScore(5);
                        bossAnimator.SetTrigger("Die");
                        Destroy(target, 1.5f);
                    }
                    else
                    {
                        bossAnimator.SetTrigger("GetHit");
                    }
                }
            }
        }
    }
}
