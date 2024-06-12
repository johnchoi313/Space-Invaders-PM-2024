using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject enemy;

    public float shootTimerMin = 1f;
    public float shootTimerMax = 3f;

    public float shootTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        shootTimer = Random.Range(shootTimerMin, shootTimerMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer <= 0)
        {
            Instantiate(bullet, enemy.transform.position, enemy.transform.rotation);
            shootTimer = Random.Range(shootTimerMin, shootTimerMax);
        }
        else
        {
            shootTimer = shootTimer - Time.deltaTime;
        }
    }
}
