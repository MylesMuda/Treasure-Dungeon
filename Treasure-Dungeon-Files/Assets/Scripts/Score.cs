using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Text Scoreboard;

    public static int score = 0;

    void Start(){
        Scoreboard = GetComponent<Text>();
    }

    void Update(){
        Scoreboard.text = "SCORE:"+score.ToString("0000");
    }
}
