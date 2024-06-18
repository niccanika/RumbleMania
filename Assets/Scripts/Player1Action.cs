using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float JumpSpeed = 1.0f;
    public GameObject Player1;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Anim.SetTrigger("Punch");
        }
    }

    public void JumpUp(){
        Player1.transform.Translate(0, JumpSpeed, 0);
    }

}
