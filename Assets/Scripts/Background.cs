using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    static public float multiplier = 1f;
    [SerializeField] float speed = 1f;
    [SerializeField] float resetWhen = -20f;
    [SerializeField] float resetTo = 20f;
    [SerializeField] Transform bgTransform;
    static public bool cleanUp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = bgTransform.position;
        pos.x -= (multiplier * speed) * Time.deltaTime;

        if (pos.x < resetWhen)
        {
            pos.x += resetTo;

        }
        if (cleanUp)
        {
            pos.x += resetTo;
        }

        bgTransform.position = pos;
    }


}
