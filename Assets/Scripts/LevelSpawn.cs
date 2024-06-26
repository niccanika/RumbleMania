using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{

    private GameObject Player1;
    private GameObject Player2;
    private GameObject Player1Character;
    private GameObject Player2Character;
    public Transform Player1Spawn;
    public Transform Player2Spawn;
    
    // void Awake()
    // {
    //     Player1 = GameObject.Find(SaveScript.P1Select);
    //     Player1.gameObject.GetComponent<SwitchOnP1>().enabled = true;
    //     StartCoroutine(SpawnPlayers());
    // }

    // Start is called before the first frame update
    void Start()
    {
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
}
