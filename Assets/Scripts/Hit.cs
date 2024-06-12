using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject target;

    public string bulletTag = "PlayerBullet";

    public float hitThreshold = 1.0f;

    // Update is called once per frame
    void Update()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag(bulletTag);

        foreach (GameObject bullet in bullets)
        {
            float distance = Vector3.Distance(target.transform.position, bullet.transform.position);

            if (distance < hitThreshold)
            {
                Destroy(bullet);
                Destroy(target);
            }
        }
    }
}
