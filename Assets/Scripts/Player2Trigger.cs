using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Trigger : MonoBehaviour
{
    public Collider Col;
    public float DamageAmt = 0.1f;
    public bool EmitFX = false;
    private ParticleSystem Particles1;
    private ParticleSystem Particles2;
    public float PauseSpeed = 0.6f;
    public string ParticleType1 = "P11";
    public string ParticleType2 = "P14";

    private GameObject ChosenParticles1;
    private GameObject ChosenParticles2;

    public bool isPlayer2 = true;

    void Start()
    {
        ChosenParticles1 = GameObject.Find(ParticleType1);
        Particles1 = ChosenParticles1.gameObject.GetComponent<ParticleSystem>();

        ChosenParticles2 = GameObject.Find(ParticleType2);
        Particles2 = ChosenParticles2.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer2 == true)
        {
            if (Player2Action.HitsP2 == false){
                Col.enabled = true;
            } else {
                Col.enabled = false;
            }
        } 
        else 
        {
            if (Player1Action.Hits == false){
                Col.enabled = true;
            } else {
                Col.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        if (isPlayer2 == true)
        {
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
        else if (isPlayer2 == false) {
            if(other.gameObject.CompareTag("Player2")){
                if (EmitFX == true){
                    Particles1.Play();
                    Particles2.Play();
                    Time.timeScale = PauseSpeed;
                }
                Player1Action.Hits = true;
                SaveScript.Player2Health -= DamageAmt;
                if (SaveScript.Player2Timer < 2.0f){
                    SaveScript.Player2Timer += 2.0f;
                }
            }
        }
        
    }
}
