using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button[] levelButton;
    public bool inMainMenu;
    public Toggle jumpScareToggle;
    public int usingJump;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.GetInt("version") != 1)
        {
            PlayerPrefs.SetInt("version", 1);

            jumpScareToggle.isOn = true;
            PlayerPrefs.SetInt("jumpscare", 1);
        }
    }

    private void Start()
    {
        //PlayerPrefs.SetInt("level", 0);

        if (inMainMenu)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("level"); i++)
            {
                levelButton[i].interactable = true;
            }

            if (PlayerPrefs.GetInt("jumpscare") == 1)
            {
                if (!jumpScareToggle.isOn)
                {
                    jumpScareToggle.isOn = true;
                    PlayerPrefs.SetInt("jumpscare", 1);
                }
            }
            else
            {
                if (jumpScareToggle.isOn)
                {
                    jumpScareToggle.isOn = false;
                    PlayerPrefs.SetInt("jumpscare", 0);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            LoadNextLevel();
        }

        usingJump = PlayerPrefs.GetInt("jumpscare");
    }

    public void ChangeJumpscareValue()
    {
        if (PlayerPrefs.GetInt("jumpscare") == 0)
        {
            PlayerPrefs.SetInt("jumpscare", 1);
        }
        else 
        {
            PlayerPrefs.SetInt("jumpscare", 0);
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
