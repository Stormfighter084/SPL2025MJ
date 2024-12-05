using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public DateTime dateTime;
    public GameObject MorningPNG;
    public GameObject DayPNG;
    public GameObject EveningPNG;
    public GameObject NightPNG;

    public Button start;

    void Start()
    {
        MorningPNG.SetActive(false);
        DayPNG.SetActive(false);
        EveningPNG.SetActive(false);
        NightPNG.SetActive(false);
        
    }
    void Update()
    {
        CheckTime();
    }
    private void CheckTime()
    {
        dateTime = DateTime.Now;

        if (dateTime.Hour >= 21 || dateTime.Hour < 5)
        {
            NightPNG.SetActive(true);

            MorningPNG.SetActive(false);
            DayPNG.SetActive(false);
            EveningPNG.SetActive(false);
        }
        else if (dateTime.Hour >= 5 && dateTime.Hour <= 11)
        {
            MorningPNG.SetActive(true);

            DayPNG.SetActive(false);
            EveningPNG.SetActive(false);
            NightPNG.SetActive(false);
        }
        else if (dateTime.Hour >= 12 && dateTime.Hour < 18)
        {
            DayPNG.SetActive(true);

            MorningPNG.SetActive(false);
            EveningPNG.SetActive(false);
            NightPNG.SetActive(false);
        }
        else if (dateTime.Hour >= 18 && dateTime.Hour < 21)
        {
            EveningPNG.SetActive(true);

            MorningPNG.SetActive(false);
            DayPNG.SetActive(false);
            NightPNG.SetActive(false);
        }
    }

    public void ClickStartButton() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
