using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    public Slider hysteriaSlider;
    public Canvas loseGameCanvas;
    public Canvas winGameCanvas;

    public Witch currentWitch;
    public string currentTrial;
    public string trialResult;
    public int hysteria;
    public bool trailHasBeenCalcAlready;

    private static GameEngine _instance;

    public static GameEngine Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        hysteria = currentWitch.publicHysteria;
        UpdateHysteria(0);
    }

    public string GetTrialResult()
    {
        return "The accused " + trialResult + " the " + currentTrial + " test.";
    }

    public void SubmitTrial(string trial)
    {
        currentTrial = trial;
        trailHasBeenCalcAlready = false;
    }

    public void CalcTrialResult()
    {
        int rand = Random.Range(1, 100);
        int stat = 0;
        switch (currentTrial)
        {
            case "touch":
                stat = currentWitch.touchTest;
                break;
            case "water":
                stat = currentWitch.waterTest;
                break;
            case "prick":
                stat = currentWitch.prickTest;
                break;
            case "incantation":
                stat = currentWitch.incantationTest;
                break;
            case "cake":
                stat = currentWitch.cakeTest;
                break;
            case "mark":
                stat = currentWitch.markTest;
                break;
            case "prayer":
                stat = currentWitch.prayerTest;
                break;
        }
        if(rand < stat)
        {
            trialResult = "passed";
            UpdateHysteria(-Random.Range(10, 20));
        }
        else
        {
            trialResult = "failed";
            UpdateHysteria(Random.Range(10, 20));
        }
        trailHasBeenCalcAlready = true;
    }

    public void UpdateHysteria(int h)
    {
        hysteria += h;
        hysteriaSlider.value = hysteria;
    }

    internal void ShowWitchCourtResult()
    {
        int rand = Random.Range(1, 100);
        if(rand > hysteria)
        {
            winGameCanvas.gameObject.SetActive(true);
        }
        else
        {
            loseGameCanvas.gameObject.SetActive(true);
        }
    }
}
