using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Energy : MonoBehaviour
{
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text energyText2;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private ParticleSystem noEnergyVFX;
    private int maxEnergy = 10;
    private int currentEnergy;
    private int restoreDuration = 120;
    private DateTime nextEnergyTime;
    private DateTime lastEnergyTime;
    private bool isRestoring = false;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("currentEnergy"))
        {
            PlayerPrefs.SetInt("currentEnergy", maxEnergy);
        }

        Load();
        StartCoroutine(RestoreEnergy());

    }

    public bool UseEnergy()
    {
        if(currentEnergy >= 1)
        {
            currentEnergy--;
            UpdateEnergy();

            if (!isRestoring)
            {
                if(currentEnergy + 1 == maxEnergy)
                    nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);

                StartCoroutine(RestoreEnergy());
            }

            return true;
        }
        else
        {
            Debug.Log("NO ENERGY");
            noEnergyVFX.Play();
            return false;
        }

    }

    public void AddEnergy(int energy)
    {
        if (currentEnergy < maxEnergy)
        {
            currentEnergy += energy;
            if(currentEnergy > maxEnergy) currentEnergy = maxEnergy;
            UpdateEnergy();

            if (!isRestoring)
            {
                if (currentEnergy + 1 == maxEnergy)
                    nextEnergyTime = AddDuration(DateTime.Now, restoreDuration);

                StartCoroutine(RestoreEnergy());
            }
        }
        else
        {
            Debug.Log("ENERGY FULL");
        }
    }

    public void ResetEnergy()
    {
        PlayerPrefs.DeleteAll();
    }

    private IEnumerator RestoreEnergy()
    {
        UpdateEnergyTimer();
        isRestoring = true;

        while(currentEnergy < maxEnergy)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime nextDateTime = nextEnergyTime;
            bool isEnergyAdding = false;

            while(currentDateTime > nextDateTime)
            {
                if (currentEnergy < maxEnergy)
                {
                    isEnergyAdding = true;
                    currentEnergy++;
                    UpdateEnergy();
                    DateTime timeToAdd = lastEnergyTime > nextDateTime ? lastEnergyTime : nextDateTime;
                    nextDateTime = AddDuration(timeToAdd, restoreDuration);
                }
                else
                    break;
            }

            if (isEnergyAdding)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextDateTime;
            }

            UpdateEnergyTimer();
            UpdateEnergy();
            Save();
            yield return null;
        }

        isRestoring = false;
    }

    private DateTime AddDuration(DateTime dateTime, int duration)
    {
        return dateTime.AddSeconds(duration);
    }

    private void UpdateEnergyTimer()
    {
        if(currentEnergy >= maxEnergy)
        {
            //timerText.text = "Full";
            timerText.gameObject.SetActive(false);
            return;
        }

        timerText.gameObject.SetActive(true);
        TimeSpan time = nextEnergyTime - DateTime.Now;
        string timeValue = String.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
        timerText.text = timeValue;
    }

    private void UpdateEnergy()
    {
        energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
        energyText2.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();

    }

    private DateTime StringToDate(string dateTime)
    {
        if (String.IsNullOrEmpty(dateTime))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(dateTime);
        }
    }

    private void Load()
    {
        currentEnergy = PlayerPrefs.GetInt("currentEnergy");
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
        nextEnergyTime = StringToDate(PlayerPrefs.GetString("lastEnergyTime"));
    }

    private void Save()
    {
        PlayerPrefs.SetInt("currentEnergy", currentEnergy);
        PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
        PlayerPrefs.SetString("lastEnergyTime", lastEnergyTime.ToString());
    }
}
