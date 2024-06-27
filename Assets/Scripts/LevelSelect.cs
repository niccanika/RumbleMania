using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject LevelBG1;
    public GameObject LevelBG2;
    public GameObject LevelBG3;
    public int MaxLevels = 3;
    private int CurrentLevel = 1;
    private float PauseTime = 1.0f;
    private bool LevelSelected = false;
    private bool TimeCountDown=false;
    // Start is called before the first frame update
    void Start()
    {
        LevelBG1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeCountDown == true)
        {
            if (PauseTime > 0.1f)
            {
                PauseTime -= Time.deltaTime;
            }
            if (PauseTime <= 0.1f)
            {
                PauseTime = 1.0f;
                TimeCountDown = false;
            }
        }

        if (Input.GetAxis("Horizontal")> 0)
        {   if (PauseTime == 1.0f)
            {
                if (CurrentLevel < MaxLevels)
                {
                    CurrentLevel++;
                    LevelSelected = true;
                    TimeCountDown = true;
                }
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (PauseTime == 1.0f)
            {
                if (CurrentLevel >= 1)
                {
                    CurrentLevel--;
                    LevelSelected = true;
                    TimeCountDown = true;
                }
            }
        }

        if (LevelSelected == true)
        {
            if (CurrentLevel == 1)
            {
                SwitchOff();
                LevelBG1.gameObject.SetActive(true);
                LevelSelected = false;
            }
            if (CurrentLevel == 2)
            {
                SwitchOff();
                LevelBG2.gameObject.SetActive(true);
                LevelSelected = false;
            }
            if (CurrentLevel == 3)
            {
                SwitchOff();
                LevelBG3.gameObject.SetActive(true);
                LevelSelected = false;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            SaveScript.LevelNumber = CurrentLevel;
            SceneManager.LoadScene(3);
        }
    }
    void SwitchOff()
    {
        LevelBG1.gameObject.SetActive(false); 
        LevelBG2.gameObject.SetActive(false);
        LevelBG3.gameObject.SetActive(false);

    }
}
