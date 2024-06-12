using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject enemy;

    public float xAmplitude = 1;
    public float xPeriod = 1;
    public float xStart = 0;

    public float yAmplitude = 1;
    public float yPeriod = 1;
    public float yStart = 0;

    // Start is called before the first frame update
    void Start()
    {
        xStart = enemy.transform.position.x;
        yStart = enemy.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Get enemy new x pos with a sine function over time
        float xPos = xAmplitude * Mathf.Sin(xPeriod * Time.time) + xStart;
        
        //Get enemy new x pos with a sine function over time
        float yPos = yAmplitude * Mathf.Sin(yPeriod * Time.time) + yStart;

        //Set new enemy position :)
        enemy.transform.position = new Vector3(xPos, yPos, 0);
    }
}