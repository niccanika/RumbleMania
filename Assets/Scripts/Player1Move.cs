using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player1Move : MonoBehaviour
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
    public static bool FacingLeft = false;
    public static bool FacingRight = true;
    public static bool WalkRightP1 = true;
    public static bool WalkLeftP1 = true;
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

            if(Input.GetAxis("Horizontal") > 0)
            {
                if(canWalkRight == true){
                    if (WalkRightP1 == true)
                    {
                        Anim.SetBool("Forward", true);
                        transform.Translate(WalkSpeed, 0, 0);
                    }
                }
            }

            if(Input.GetAxis("Horizontal") < 0)
            {
                if(canWalkLeft == true){
                    if (WalkLeftP1 == true)
                    {
                        Anim.SetBool("Backward", true);
                        transform.Translate(-WalkSpeed, 0, 0);
                    }

                }
            }
        }

        //back to idle
        if(Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("Backward", false);
            Anim.SetBool("Forward", false);
        }

        //jump and crouch
        if(Input.GetAxis("Vertical") > 0)
        {
            if (isJumping == false) {
                isJumping = true;
                Anim.SetTrigger("Jump");
                StartCoroutine(JumpPause());
            }
        }

        if(Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("Crouch", true);
        }

        if(Input.GetAxis("Vertical") == 0)
        {
            Anim.SetBool("Crouch", false);
        }

        //Reset to restrict
        if (Restrict.gameObject.activeInHierarchy == false){
            WalkLeftP1 = true;
            WalkRightP1 =  true;
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
        if(FacingLeft == true)
        {
            FacingLeft = false;
            FacingRight = true;
            yield return new WaitForSeconds(0.15f);
            Player1.transform.Rotate(0, 180, 0);
            Anim.SetLayerWeight(1, 0);
        }
    }

    IEnumerator FaceRight() {
        if(FacingRight == true)
        {
            FacingRight = false;
            FacingLeft = true;
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
}
