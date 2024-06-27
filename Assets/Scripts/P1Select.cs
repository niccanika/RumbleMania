using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
public class P1Select : MonoBehaviour
{
    public int MaxIcons = 3;
    public int IconsPerRow = 3;
    public int MaxRows = 1;

    public GameObject VajP1;
    public GameObject RobP1;
    public GameObject SinP1;

    public GameObject VajP1Text;
    public GameObject RobP1Text;
    public GameObject SinP1Text;

    public TextMeshProUGUI Player1Name;

    public string CharacterSelectionP1;

    private int IconNumber = 1;
    private int RowNumber = 1;
    private float PauseTime = 1.0f;
    private bool TimeCountDown = false;
    private bool ChangeCharacter = false;
    private AudioSource MyPlayer;


    // Start is called before the first frame update
    void Start()
    {
        RobP1.gameObject.SetActive(true);
        RobP1Text.gameObject.SetActive(true);
        SaveScript.Round = 0;
        SaveScript.Player1Wins = 0;
        SaveScript.Player2Wins = 0;
        ChangeCharacter = true;
        Time.timeScale = 1f;
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SaveScript.P1Select);
        if (ChangeCharacter == true)
        {
            if (IconNumber == 1)
            {
                SwitchOff();
                RobP1.gameObject.SetActive(true);
                RobP1Text.gameObject.SetActive(true);
                Player1Name.text = "Colossus";
                CharacterSelectionP1 = "ColossusP1";
                ChangeCharacter = false;
            }
            if (IconNumber == 2)
            {
                SwitchOff();
                SinP1.gameObject.SetActive(true);
                SinP1Text.gameObject.SetActive(true);
                Player1Name.text = "Sinsoo";
                CharacterSelectionP1 = "SinsooP1";
                ChangeCharacter = false;
            }
            if (IconNumber == 3)
            {
                SwitchOff();
                VajP1.gameObject.SetActive(true);
                VajP1Text.gameObject.SetActive(true);
                Player1Name.text = "Vajatali";
                CharacterSelectionP1 = "VajataliP1";
                ChangeCharacter = false;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            SaveScript.P1Select = CharacterSelectionP1;
            Debug.Log("Selected Character=" +CharacterSelectionP1);
            MyPlayer.Play();
            NextPlayer();
        }

        Debug.Log("Icon Number=" +IconNumber);
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
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (PauseTime == 1.0f)
            {
                if (IconNumber < IconsPerRow * RowNumber)
                {
                    IconNumber++;
                    ChangeCharacter = true;
                    TimeCountDown = true;
                }
            }
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            if (PauseTime == 1.0f)
            {
                if (IconNumber > IconsPerRow * (RowNumber -1) +1)
                {
                    IconNumber--;
                    ChangeCharacter = true;
                    TimeCountDown = true;
                }
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            if (PauseTime == 1.0f)
            {
                if (RowNumber<MaxRows)
                {
                    IconNumber+= IconsPerRow;
                    RowNumber++;
                    ChangeCharacter = true;
                    TimeCountDown = true;
                }
            }
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            if (PauseTime == 1.0f)
            {
                if (RowNumber > 1)
                {
                    IconNumber -= IconsPerRow;
                    RowNumber--;
                    ChangeCharacter = true;
                    TimeCountDown = true;
                }
            }
        }
    }
    void SwitchOff()
    {
        RobP1.gameObject.SetActive(false);
        VajP1.gameObject.SetActive(false);
        SinP1.gameObject.SetActive(false);

        RobP1Text.gameObject.SetActive(false);
        VajP1Text.gameObject.SetActive(false);
        SinP1Text.gameObject.SetActive(false);

    }
    void NextPlayer()
    {
        RobP1Text.gameObject.SetActive(false);
        VajP1Text.gameObject.SetActive(false);
        SinP1Text.gameObject.SetActive(false);

        if (SaveScript.Player1Mode == false)
        {
            this.gameObject.GetComponent<P2Select>().enabled = true;
            this.gameObject.GetComponent<P1Select>().enabled = false;
        }
    }
}
