using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;

    public string gameMain;
    public string gameLevel;
    // Start is called before the first frame update
    void Start()
    {
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(gameLevel);
    }

    public void OnClickCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void OnReturnMain()
    {
        SceneManager.LoadScene(gameMain);
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
