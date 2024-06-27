using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawn : MonoBehaviour
{

    private GameObject Player1;
    private GameObject Player2;
    private GameObject Player1Character;
    private GameObject Player2Character;
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public Transform Player1Spawn;
    public Transform Player2Spawn;
    public Transform StageSpawn;
    public GameObject SelectedStage;

    private AudioSource MyPlayer;

    public AudioClip Music1;
    public AudioClip Music2;
    public AudioClip Music3;

    public int Scene = 0;
    
    // void Awake()
    // {
    //     Player1 = GameObject.Find(SaveScript.P1Select);
    //     Player1.gameObject.GetComponent<SwitchOnP1>().enabled = true;
    //     StartCoroutine(SpawnPlayers());
    // }

    // Start is called before the first frame update
    void Start()
    {
        MyPlayer = GetComponent<AudioSource>();
        if(SaveScript.LevelNumber ==1){
            SelectedStage = Stage1;
            MyPlayer.clip = Music1;
            Instantiate(SelectedStage, new Vector3(128.27f, -3.8f, 6.0f), Quaternion.Euler(0f, -230.1f, 0f));
        }
        if(SaveScript.LevelNumber ==2){
            SelectedStage = Stage2;
            MyPlayer.clip = Music2;
            Instantiate(SelectedStage, StageSpawn.position, StageSpawn.rotation);
        }
        if(SaveScript.LevelNumber ==3){
            SelectedStage = Stage3;
            MyPlayer.clip = Music3;
            Instantiate(SelectedStage, new Vector3(29f, -3.5f, 51.06f), StageSpawn.rotation);
        }
        // Instantiate(SelectedStage, StageSpawn.position, StageSpawn.rotation);
        Debug.Log(SaveScript.P1Select);
        Debug.Log(SaveScript.P2Select);
        Player1 = GameObject.Find(SaveScript.P1Select);
        Player1.gameObject.GetComponent<SwitchOnP1>().enabled = true;
        Player2 = GameObject.Find(SaveScript.P2Select);
        Player2.gameObject.GetComponent<SwitchOnP2>().enabled = true;
        StartCoroutine(SpawnPlayers());
    }

    

    IEnumerator SpawnPlayers() {
        yield return new WaitForSeconds(0.1f);
        // Debug.Log(SaveScript.Player1Load);
        // Debug.Log(SaveScript.Player2Load);
        Player1Character = SaveScript.Player1Load;
        Player2Character = SaveScript.Player2Load;
        Instantiate(Player1Character, Player1Spawn.position, Player1Spawn.rotation);
        Instantiate(Player2Character, Player2Spawn.position, Player2Spawn.rotation);
    }

    public void BackToSelection(){
        SceneManager.LoadScene(Scene);
    }
}
