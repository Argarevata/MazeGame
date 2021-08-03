using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            LoadNextLevel();
        }
    }

    public void RetryGame()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void GoMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void GoLoadLevel(string x)
    {
        Application.LoadLevel(x);
    }

    public void LoadNextLevel()
    {
        string thisLevelName = Application.loadedLevelName;
        int levelIdx = int.Parse(thisLevelName);
        print("curr level = " + levelIdx);
        int nextLevel = levelIdx + 1;
        string nextLevelName = nextLevel.ToString();
        print("next level = " + nextLevelName);
        Application.LoadLevel(nextLevelName);
    }
}
