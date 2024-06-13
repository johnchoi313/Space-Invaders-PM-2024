using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject target;
    public GameObject explosion;

    public string bulletTag = "PlayerBullet";

    public float hitThreshold = 1.0f;

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
                GameObject explosionCopy = Instantiate(explosion, target.transform.position, target.transform.rotation);
                Destroy(explosionCopy, 3);
                Destroy(bullet);

                //If Enemy was hit
                if(bulletTag == "PlayerBullet")
                {
                    gameManager.IncreaseScore(1);
                    Destroy(target);
                }
                //If Player was hit
                if(bulletTag == "EnemyBullet")
                {
                    gameManager.DecreaseHealth(1);
                    if(gameManager.health <= 0)
                    {
                        Destroy(target);
                    }
                }
            }
        }
    }
}
