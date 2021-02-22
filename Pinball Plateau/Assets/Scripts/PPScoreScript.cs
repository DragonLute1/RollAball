using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPScoreScript : MonoBehaviour
{
    public Text ScoreText;
    public float score = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;
    }
}
