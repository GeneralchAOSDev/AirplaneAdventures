using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float startPosX = 7.27f;
    [SerializeField] Transform enTransform;
    static public float multiplier = 1f;
    [SerializeField] float speedy = 1f;
    [SerializeField] float multiplierx = multiplier;
    [SerializeField] float multipliery = multiplier;
    [SerializeField] float speedx = 1f;
    bool armed = true;
    static public int fired;
    static public bool cleanUp;
    [SerializeField] Transform target;
    int fireZeMissiles;
    // Start is called before the first frame update
    void Start()
    {
        fireZeMissiles = Random.Range(1, 4);

    }
    public void countMis()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = enTransform.position;

        if (armed)
        {
            if (pos.x > startPosX)
            {
                pos.x -= (multiplierx * speedx) * Time.deltaTime;
                if (pos.y > 4)
                {
                    pos.y -= (multipliery * speedy) * Time.deltaTime;
                }
            }
            else if (pos.x < (startPosX + 1f))
            {
                //FireZeMissile();
                if(Rocket.fired > fireZeMissiles)
                {
                    pos.x -= (multiplierx * speedx) * Time.deltaTime;
                    pos.y += (multipliery * speedy) * Time.deltaTime;
                    speedx = 8f;
                }
            } 
        }
       if (pos.x < -13.3f)
        {
            pos.x += Refresh();
            enTransform.position = pos;
        }
        if (cleanUp)
        {
            pos.x += Refresh();
        }

        enTransform.position = pos;
        //Debug.Log("Plane Sees " + Rocket.fired);
    }

    int Refresh()
    {
        Rocket.fired = 0;
        fireZeMissiles = Random.Range(1, 4);
        speedx = 1f;
        return Random.Range(20, 40);
    }
}
