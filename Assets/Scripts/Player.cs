using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float force = 24f;
    [SerializeField] static Vector2 forceVector;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Transform plTransform;
    [SerializeField] Transform down;
    private float count;
    [SerializeField] float thrust=2f;
    static public float multiplier = 1f;
    static public bool cleanUp = false;
    public AudioSource audioSource2;
    public AudioSource audioSource3;

    // Start is called before the first frame update
    void Start()
    {
        forceVector.y = force;

    }



    public float smooth = 2f;
    //float tiltAngle = 270f;

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = plTransform.rotation;
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            //rigidBody.AddForce(forceVector);
            count += 20;
        }
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Mouse1))
        {
            //rigidBody.AddForce(forceVector);
            count -= 16;
        }
        if (count < 0)
        {
            rot.z += ((count+1)/75) * (smooth * Time.deltaTime);
            count++;
        }

        if (count > 0)
        {
            rot.z += ((count + 1) / 75) * (smooth * Time.deltaTime);
            count--;
        }
        
        if (rot.z > 0.6)
        {
            rot.z = 0.6f;
        }
        if (rot.z < -0.6)
        {
            rot.z = -0.6f;
        }

        plTransform.rotation = rot;
        Debug.Log(rot.z);
        Vector3 pos = plTransform.position;
        pos.y += (rot.z * thrust) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource2.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            audioSource3.Play();
        }


            plTransform.position = pos;
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        //Debug.Log("Collision");
        GameOver();
    }



    public void GameOver()
    {
        //cleanUp = true;
        //Debug.Log("GG");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public AudioSource audioSource;
    void OnTriggerEnter2D(Collider2D collision)
{
        //audioSource.Play();
    }
}
