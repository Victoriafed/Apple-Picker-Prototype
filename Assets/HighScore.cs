using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int   score = 1000;

    void Awake() {
        if (PlayerPrefs.HasKey(nameof(HighScore))) {
            score = PlayerPrefs.GetInt(nameof(HighScore));
        }
        PlayerPrefs.SetInt(nameof(HighScore), score);
    }
    
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High  score: " + score;

        if (score > PlayerPrefs.GetInt(nameof(HighScore))) {
            PlayerPrefs.SetInt(nameof(HighScore), score);
        }
    }
}
