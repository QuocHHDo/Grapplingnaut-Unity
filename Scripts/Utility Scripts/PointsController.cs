using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PointsController : MonoBehaviour
{

    int score;
    public static GameManager inst;
    [SerializeField] Text scoreText2;

    private void Start()
    {
        scoreText2.text = "Score: 0";
    }
    public void IncrementScore()
    {
        score++;
        Debug.Log("Score increment");
        scoreText2.text = "Score: " + score;
    }
   /*
    private void Awake()
    {
        inst = this;
    }
   */
}
