using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player2Move : MonoBehaviour
{

    private Animator Anim;
    public float WalkSpeed = 0.001f;
    private bool isJumping = false;
    private bool canWalkLeft = true;
    private bool canWalkRight = true;
    public GameObject Player1;
    public GameObject Opponent;
    private Vector3 OppPosition;
    private AnimatorStateInfo Player1Layer0;
    public static bool FacingLeftP2 = false;
    public static bool FacingRightP2 = true;
    public static bool WalkLeft = true;
    public static bool WalkRight = true;
    public AudioClip LightPunch;
    public AudioClip HeavyPunch;
    public AudioClip LightKick;
    public AudioClip HeavyKick;
    private AudioSource MyPlayer;
    public GameObject Restrict;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        StartCoroutine(FaceRight());
        MyPlayer = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if player 2 is knocked out
        if (SaveScript.Player2Health <= 0) {
            Anim.SetTrigger("KnockOut");
            Player1.GetComponent<Player2Action>().enabled = false;
            StartCoroutine(KnockedOut());
            // this.GetComponent<Player2Move>().enabled = false;
        }

        //listen to animator
        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);
        
        //screen bounds so character doesnt exit screen
        Vector3 ScreenBounds = Camera.main.WorldToScreenPoint(this.transform.position);

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

        //get opponent position
        OppPosition = Opponent.transform.position;

        //facing left or right of the opponent
        if (OppPosition.x > Player1.transform.position.x)
        {
            StartCoroutine(FaceLeft());
        }

        if (OppPosition.x < Player1.transform.position.x)
        {
            StartCoroutine(FaceRight());
        }

        //flip around to face opponent
        // if (OppPosition.x > Player1.transform.position.x)
        // {
        //     StartCoroutine(LeftIsTrue());
        // }

        // if (OppPosition.x < Player1.transform.position.x)
        // {
        //     StartCoroutine(RightIsTrue());
        // }

        //walking left and right
        if(Player1Layer0.IsTag("Motion")){

            if(Input.GetAxis("HorizontalP2") > 0)
            {
                if(canWalkRight == true){
                    if (WalkRight == true)
                    {
                        Anim.SetBool("Forward", true);
                        transform.Translate(WalkSpeed, 0, 0);
                    }
                }
            }

            if(Input.GetAxis("HorizontalP2") < 0)
            {
                if(canWalkLeft == true){
                    if (WalkLeft == true)
                    {
                        Anim.SetBool("Backward", true);
                        transform.Translate(-WalkSpeed, 0, 0);
                    }
                }
            }
        }

        //back to idle
        if(Input.GetAxis("HorizontalP2") == 0)
        {
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", false);
        }

        //jump and crouch
        if(Input.GetAxis("VerticalP2") > 0)
        {
            if (isJumping == false) {
                isJumping = true;
                Anim.SetTrigger("Jump");
                StartCoroutine(JumpPause());
            }
        }

        if(Input.GetAxis("VerticalP2") < 0)
        {
            Anim.SetBool("Crouch", true);
        }

        if(Input.GetAxis("VerticalP2") == 0)
        {
            Anim.SetBool("Crouch", false);
        }

        //Reset to restrict
        if (Restrict.gameObject.activeInHierarchy == false){
            WalkLeft = true;
            WalkRight =  true;
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("FistLight")){
            Anim.SetTrigger("HeadReact");
            MyPlayer.clip = LightPunch;
            MyPlayer.Play();
        }
        if(other.gameObject.CompareTag("FistHeavy")){
            Anim.SetTrigger("BigReact");
            MyPlayer.clip = HeavyPunch;
            MyPlayer.Play();
        }
        if(other.gameObject.CompareTag("KickHeavy")){
            Anim.SetTrigger("BigReact");
            MyPlayer.clip = HeavyKick;
            MyPlayer.Play();
        }
        if(other.gameObject.CompareTag("KickLight")){
            Anim.SetTrigger("HeadReact");
            MyPlayer.clip = LightKick;
            MyPlayer.Play();
        }
        
    }

    IEnumerator JumpPause() {
        yield return new WaitForSeconds(1.0f);
        isJumping = false;
    }

    IEnumerator FaceLeft() {
        if(FacingLeftP2 == true)
        {
            FacingLeftP2 = false;
            FacingRightP2 = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, 180, 0);
            Anim.SetLayerWeight(1, 0);
        }
    }

    IEnumerator FaceRight() {
        if(FacingRightP2 == true)
        {
            FacingRightP2 = false;
            FacingLeftP2 = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, -180, 0);
            Anim.SetLayerWeight(1, 1);
        }
    }

    IEnumerator LeftIsTrue() {
        yield return new WaitForSeconds(0.15f);
        Player1.transform.Rotate(0, -180, 0);
    }

    IEnumerator RightIsTrue() {
        yield return new WaitForSeconds(0.15f);
        Player1.transform.Rotate(0, 180, 0);
    }

    IEnumerator KnockedOut() {
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Player2Move>().enabled = false;
    }
}
