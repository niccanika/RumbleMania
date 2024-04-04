using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        //movement left and right
        if(Input.GetAxis("Horizontal") > 0)
        {
            Anim.SetBool("Forward", true);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Anim.SetBool("Backward", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("Forward", false);
            Anim.SetBool("Backward", false);
        }
        //Jumping and crouching
        if(Input.GetAxis("Vertical") > 0)
        {
            Anim.SetTrigger("Jump");
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            Anim.SetBool("Crouch", false);
        }
    }

}
