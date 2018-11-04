using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField] private Text timerText;
    [SerializeField] private float wavetimer;
    [SerializeField] private Text wavesSurvived;

    private float timer;
    private int waveno = 0;

    void Start()
    {
        timer = wavetimer;
    }

    void timerF()
    {
        if (timer >= 0.0f)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f)
        {
            timer = 0.0f;
            timerText.text = timer.ToString("");
            Wavesurvived();
        }

    }

    void Wavesurvived()
    {
        if (waveno < 1)
        {
            waveno++;
        }
        wavesSurvived.text = "Waves Survived: " + waveno;

        GameObject gameOverParent = GameObject.Find("UI");
        GameObject gameOver = gameOverParent.transform.Find("WavesSurvived").gameObject;
        gameOver.SetActive(true);
    }

    void Update()
    {
        timerF();
    }

    void GameOver()
    {
        
        //Load a new scene
    }
}
