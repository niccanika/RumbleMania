using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Trigger : MonoBehaviour
{
    public Collider Col;
    public float DamageAmt = 0.1f;
    public bool EmitFX = false;
    public ParticleSystem Particles1;
    public ParticleSystem Particles2;
    public float PauseSpeed = 0.6f;

    // Update is called once per frame
    void Update()
    {
        if (Player2Action.HitsP2 == false){
            Col.enabled = true;
        } else {
            Col.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player1")){
            if (EmitFX == true){
                Particles1.Play();
                Particles2.Play();
                Time.timeScale = PauseSpeed;
            }
            Player2Action.HitsP2 = true;
            SaveScript.Player1Health -= DamageAmt;
            if (SaveScript.Player1Timer < 2.0f){
                SaveScript.Player1Timer += 2.0f;
            }
        }
    }
}
