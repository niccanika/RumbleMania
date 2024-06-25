using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWin : MonoBehaviour
{
    public GameObject WinText;
    public GameObject LoseText;
    public AudioSource MyPlayer;
    public AudioClip LoseAudio;
    public float PauseTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        SaveScript.TimeOut = false;
        WinText.gameObject.SetActive(false);
        LoseText.gameObject.SetActive(false);
        StartCoroutine(WinSet());
    }

    IEnumerator WinSet(){
        yield return new WaitForSeconds(0.4f);
        if (SaveScript.Player1Health > SaveScript.Player2Health)
        {
            WinText.gameObject.SetActive(true);
            MyPlayer.Play();
            SaveScript.Player1Wins++;
        }
        else if (SaveScript.Player2Health > SaveScript.Player1Health)
        {
            LoseText.gameObject.SetActive(true);
            MyPlayer.clip = LoseAudio;
            MyPlayer.Play();
            SaveScript.Player2Wins++;
        }
        yield return new WaitForSeconds(PauseTime);
        SceneManager.LoadScene(0);
    }
}
