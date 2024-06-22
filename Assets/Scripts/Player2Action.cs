using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Action : MonoBehaviour
{

    public float JumpSpeed = 1.0f;
    public float PunchSlideAmt = 15f;
    public float SuperAttackSlideAmt = 50f;
    public GameObject Player1;
    private Animator Anim;
    private AnimatorStateInfo Player1Layer0;
    private bool HeavyMoving = false;
    private bool SuperAttackMoving = false;
    private AudioSource MyPlayer;
    public AudioClip PunchWoosh;
    public AudioClip KickWoosh;



    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        MyPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //listen to animator
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        //heavy punch slide
        if(HeavyMoving == true)
        {
            if(Player2Move.FacingRightP2 == true) 
            {
                Player1.transform.Translate(PunchSlideAmt * Time.deltaTime, 0, 0);
            }

            if(Player2Move.FacingLeftP2 == true) 
            {
                Player1.transform.Translate(-PunchSlideAmt * Time.deltaTime, 0, 0);
            }
            
        }

        //super attack move
        if(SuperAttackMoving == true)
        {
            if(Player2Move.FacingRightP2 == true) 
            {
                Player1.transform.Translate(SuperAttackSlideAmt * Time.deltaTime, 0, 0);
            }

            if(Player2Move.FacingLeftP2 == true) 
            {
                Player1.transform.Translate(-SuperAttackSlideAmt * Time.deltaTime, 0, 0);
            }
            
        }

        //standing attacks
        if(Player1Layer0.IsTag("Motion"))
        {
            if (Input.GetButtonDown("Fire1P2"))
            {
                Anim.SetTrigger("LightPunch");
            }

            if (Input.GetButtonDown("Fire2P2"))
            {
                Anim.SetTrigger("HeavyPunch");
            }

            if (Input.GetButtonDown("Fire3P2"))
            {
                Anim.SetTrigger("LightKick");
            }

            if (Input.GetButtonDown("JumpP2"))
            {
                Anim.SetTrigger("HeavyKick");
            }
            if (Input.GetButtonDown("BlockP2"))
            {
                Anim.SetTrigger("BlockOn");
            }
            if (Input.GetButtonDown("SuperAttackP2"))
            {
                Anim.SetTrigger("SuperAttack");
            }
        }

        if(Player1Layer0.IsTag("Block"))
        {
            if (Input.GetButtonDown("BlockP2"))
            {
                Anim.SetTrigger("BlockOff");
            }
        }

        //Crouching attack
        if (Player1Layer0.IsTag("Crouching"))
        {
            if (Input.GetButtonDown("Fire3P2"))
            {
                Anim.SetTrigger("LightKick");
            }
        }

        //aerial attack
        if (Player1Layer0.IsTag("Jumping"))
        {
            if (Input.GetButtonDown("JumpP2"))
            {
                Anim.SetTrigger("HeavyKick");
            }
        }

    }

    public void JumpUp(){
        Player1.transform.Translate(0, JumpSpeed, 0);
    }

    public void HeavyMove(){
        StartCoroutine(PunchSlide());
    }

    public void SuperAttackMove(){
        StartCoroutine(SuperSlide());
    }

    public void FlipUp(){
        Player1.transform.Translate(0, JumpSpeed, 0);
        Player1.transform.Translate(1f, 0, 0);
    }

    public void FlipBack(){
        Player1.transform.Translate(0, JumpSpeed, 0);
        Player1.transform.Translate(-1f, 0, 0);
    }

    public void PunchWooshSound(){
        MyPlayer.clip = PunchWoosh;
        MyPlayer.Play();
    }

    public void KickWooshSound(){
        MyPlayer.clip = KickWoosh;
        MyPlayer.Play();
    }

    IEnumerator PunchSlide(){
        HeavyMoving = true;
        yield return new WaitForSeconds(0.05f);
        HeavyMoving = false;
    }

    IEnumerator SuperSlide() {
        SuperAttackMoving = true;
        yield return new WaitForSeconds(0.01f);
        SuperAttackMoving = false;
    }
}
