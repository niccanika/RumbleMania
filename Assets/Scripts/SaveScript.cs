using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static float Player1Health = 1.0f;
    public static float Player2Health = 1.0f;
    public static float Player1Timer = 2.0f;
    public static float Player2Timer = 2.0f;
    public static bool TimeOut = false;
    public static int Player1Wins = 0;
    public static int Player2Wins = 0;
    public static int Round = 0;
    public static string P1Select;
    public static string P2Select;
    public static GameObject Player1Load;
    public static GameObject Player2Load;
    public static bool P1Reacting = false;
    public static bool P2Reacting = false;

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
        P1Select = "VajataliP1";
        P2Select = "ColossusP2";
        Player1Health = 1.0f;
        Player2Health = 1.0f;
        P1Reacting = false;
        P2Reacting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
