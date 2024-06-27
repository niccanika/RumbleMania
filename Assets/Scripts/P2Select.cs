using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class P2Select : MonoBehaviour
{
    public int MaxIcons = 3;
    public int IconsPerRow = 3;
    public int MaxRows = 1;

    public GameObject VajP2;
    public GameObject RobP2;
    public GameObject SinP2;

    public GameObject VajP2Text;
    public GameObject RobP2Text;
    public GameObject SinP2Text;

    public TextMeshProUGUI Player2Name;

    public string CharacterSelectionP2;

    private int IconNumber = 1;
    private int RowNumber = 1;
    private float PauseTime = 1.0f;
    private bool TimeCountDown = false;
    private bool ChangeCharacter = false;
    private AudioSource MyPlayer;

    public int Scene = 2;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SaveScript.P2Select);
        if (ChangeCharacter == true)
        {
            if (IconNumber == 1)
            {
                SwitchOff();
                RobP2.gameObject.SetActive(true);
                RobP2Text.gameObject.SetActive(true);
                Player2Name.text = "Colossus";
                CharacterSelectionP2 = "ColossusP2";
                ChangeCharacter = false;
            }
            if (IconNumber == 2)
            {
                SwitchOff();
                SinP2.gameObject.SetActive(true);
                SinP2Text.gameObject.SetActive(true);
                Player2Name.text = "Sinsoo";
                CharacterSelectionP2 = "SinsooP2";
                ChangeCharacter = false;
            }
            if (IconNumber == 3)
            {
                SwitchOff();
                VajP2.gameObject.SetActive(true);
                VajP2Text.gameObject.SetActive(true);
                Player2Name.text = "Vajatali";
                CharacterSelectionP2 = "VajataliP2";
                ChangeCharacter = false;
            }
        }
        if (Input.GetButtonDown("Fire1P2"))
        {
            SaveScript.P2Select = CharacterSelectionP2;
            MyPlayer.Play();
            SceneManager.LoadScene(Scene);
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
        if (Input.GetAxis("HorizontalP2") > 0)
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
        if (Input.GetAxis("HorizontalP2") < 0)
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
        if (Input.GetAxis("VerticalP2") < 0)
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
        if (Input.GetAxis("VerticalP2") > 0)
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
        RobP2.gameObject.SetActive(false);
        VajP2.gameObject.SetActive(false);
        SinP2.gameObject.SetActive(false);

        RobP2Text.gameObject.SetActive(false);
        VajP2Text.gameObject.SetActive(false);
        SinP2Text.gameObject.SetActive(false);

    }
}
