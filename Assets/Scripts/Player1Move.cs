using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{

    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            Anim.SetBool("Forward", true);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            Anim.SetBool("Backward", true);
        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", false);
        }
    }
}
