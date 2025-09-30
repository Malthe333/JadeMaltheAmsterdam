using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public TextMeshProUGUI timerText;
    float startTime = 0f;

    public bool hasCompletedLevel = false;

    void Start()
    {
        
        startTime = Time.time;
    }

    // Update is called once per frame

    


    public void StopTimer()
    {
        hasCompletedLevel = true;
    }
    void Update()
    {
        if (hasCompletedLevel == false)
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            timerText.text = minutes + ":" + seconds;
        }



    }
        
    }

