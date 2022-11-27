using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject[] panels;

    public void ChangeLevel (string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivePanel(int index)
    {
        panels[index].SetActive(true);
    }

    public void InactivePanel(int index)
    {
        panels[index].SetActive(false);
    }
}
