using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Trigger : MonoBehaviour
{
    public Collider Col;
    public float DamageAmt = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Player1Action.Hits == false){
            Col.enabled = true;
        } else {
            Col.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player2")){
            Player1Action.Hits = true;
            SaveScript.Player2Health -= DamageAmt;
            if (SaveScript.Player2Timer < 2.0f){
                SaveScript.Player2Timer += 2.0f;
            }
        }
    }
}
