using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int scoreVal = 0;
    [SerializeField] Transform target;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Missiles Dodged: " + scoreVal;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IncreaseScore()
    {

        scoreVal++;
        scoreText.text = "Missiles Dodged: " + scoreVal;
    }


}
