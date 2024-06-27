using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SaveScript : MonoBehaviour
{
    public static float Player1Health = 1.0f;
    public static float Player2Health = 1.0f;
    public static float Player1Timer = 2.0f;
    public static float Player2Timer = 2.0f;
    public static bool TimeOut = false;
    public static bool Player1Mode = false;
    public static int Player1Wins = 0;
    public static int Player2Wins = 0;
    public static int Round = 0;
    public static string P1Select;
    public static string P2Select;
    public static GameObject Player1Load;
    public static GameObject Player2Load;
    public static bool P1Reacting = false;
    public static bool P2Reacting = false;
    public static int LevelNumber = 1;
    public AudioMixer MusicMixer;
    public AudioMixer SFXMixer;
    public static float MusicVolume = 0;
    public static float SFXVolume = 2;

    // void Awake()
    // {
    //     P1Select = "VajataliP1";
    //     P2Select = "VajataliP2";
    //     Player1Health = 1.0f;
    //     Player2Health = 1.0f;
    // }

    // Start is called before the first frame update
    void Start()
    {
        // P1Select = "VajataliP1";
        // P2Select = "ColossusP2";
        Player1Health = 1.0f;
        Player2Health = 1.0f;
        P1Reacting = false;
        P2Reacting = false;

        MusicMixer.SetFloat("MusicLevel", MusicVolume);
        SFXMixer.SetFloat("SFXicLevel", SFXVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
