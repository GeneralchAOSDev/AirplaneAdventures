using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform rocPos;
    [SerializeField] Transform carry;
    static public int fired;
    Vector3 tarPos;
    static public bool cleanUp;
    Vector3 curPos;
    bool launched = false;
    static public float multiplier = 1f;
    public Score scoreComponent;
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!launched)
        {
            curPos = rocPos.position;
            curPos.x = carry.position.x;
            curPos.y = (carry.position.y - 0.10f);
            if(curPos.x < 7.5f)
            {
                Fire();
            }
            //Debug.Log("Working");
        }
        else if(launched){
            curPos = rocPos.position;
            curPos.x -= (multiplier * speed) * Time.deltaTime;
            if (curPos.y < tarPos.y)
            {
                curPos.y += (multiplier * speed) * Time.deltaTime;
            }
            else if (curPos.y > tarPos.y)
            {
                curPos.y -= (multiplier * speed) * Time.deltaTime;
            }
        }
        if (curPos.x < -13.3f)
        {
            launched = false;
            scoreComponent.IncreaseScore();
        }
        if(cleanUp)
        {
            curPos.x = carry.position.x;
            curPos.y = (carry.position.y - 0.10f);
            cleanUp = false;
        }
        rocPos.position = curPos;
        
    }

    void Fire()
    {
        tarPos = target.position;
        launched = true;
        fired++;
        Debug.Log(fired);
    }

}
