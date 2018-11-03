using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField] private Text uiText;
    [SerializeField] private float wavetimer;

    private float timer;

    void Start()
    {
        timer = wavetimer;
    }

    void Update()
    {
        if (timer >= 0.0f)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f)
        {
            timer = 0.0f;
            uiText.text = "0.00";
            GameOver();
        }
    }

    void GameOver()
    {

        //Load a new scene
    }
}
