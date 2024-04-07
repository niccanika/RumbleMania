using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{

    private Animator Anim;
    public float WalkSpeed = 0.001f;
    private bool canWalkLeft = true;
    private bool canWalkRight = true;
    public GameObject Player1;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ScreenBounds = Camera.main.WorldToScreenPoint(this.transform.position);

        // screen bounds
        if(ScreenBounds.x > Screen.width - 200)
        {
            canWalkRight = false;
        }

        if(ScreenBounds.x < 200)
        {
            canWalkLeft = false;
        } else if (ScreenBounds.x > 200 && ScreenBounds.x < Screen.width - 200) {
            canWalkRight = true;
            canWalkLeft = true;
        }

        //walking left and right
        if(Input.GetAxis("Horizontal") > 0)
        {
            if(canWalkRight == true){
                Anim.SetBool("Forward", true);
                transform.Translate(WalkSpeed, 0, 0);
            }
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            if(canWalkLeft == true){
                Anim.SetBool("Backward", true);
                transform.Translate(-WalkSpeed, 0, 0);
            }
        }

        if(Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", false);
        }
    }
}
