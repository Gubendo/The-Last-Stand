using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{

    Animator mainCharacterAnimator;
    AudioSource mainCharacterAudioSource;
    CapsuleCollider mainCharacterCapsule;

    float axisH, axisV;

    [SerializeField]
    float walkSpeed = 2f, runSpeed = 8f, rotSpeed = 100f, jumpForce = 350;

    Rigidbody rb;

    const float timeout = 60.0f;
    [SerializeField] float countdown = timeout;


    [SerializeField] AudioClip sndJump, sndImpact, sndLeftFoot, sndRightFoot;
    bool switchFoot = false;

    [SerializeField] bool isJumping = false;

    private void Awake()
    {
        mainCharacterAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        mainCharacterAudioSource = GetComponent<AudioSource>();
        mainCharacterCapsule = GetComponent<CapsuleCollider>();
    }

    void Update()
    {

        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");

        if (axisV > 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                transform.Translate(Vector3.forward * runSpeed * axisV * Time.deltaTime);
                mainCharacterAnimator.SetFloat("run", axisV);
            }
            else
            {
                transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
                mainCharacterAnimator.SetBool("walk", true);
                mainCharacterAnimator.SetFloat("run", 0);
            }
        }
        else
        {
            mainCharacterAnimator.SetBool("walk", false);
        }

        if (axisH != 0 && axisV == 0)
        {
            mainCharacterAnimator.SetFloat("h", axisH);
        }
        else
        {
            mainCharacterAnimator.SetFloat("h", 0);
        }


        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * axisH);

        if (axisV < 0)
        {
            mainCharacterAnimator.SetBool("walkBack", true);
            mainCharacterAnimator.SetFloat("run", 0);
            transform.Translate(Vector3.forward * walkSpeed * axisV * Time.deltaTime);
        }
        else
        {
            mainCharacterAnimator.SetBool("walkBack", false);

        }

        //Idle Defeated
        if (axisH == 0 && axisV == 0)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                mainCharacterAnimator.SetBool("death", true);
            }
        }
        else
        {
            countdown = timeout;
            mainCharacterAnimator.SetBool("death", false);
        }

        //Debug Dead 
        if (Input.GetKeyDown(KeyCode.AltGr))
        {
            CharacterDead();
        }

        //Debug punch
        if (Input.GetKeyDown(KeyCode.W))
        {
            CharacterPunch();
        }

        //Debug Rifle punch
        if (Input.GetKeyDown(KeyCode.C))
        {
            CharacterRiflePunch();
        }

        //curve de saut
        if (isJumping)
            mainCharacterCapsule.height = mainCharacterAnimator.GetFloat("colheight");

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce);
            mainCharacterAudioSource.pitch = 1f;
            mainCharacterAnimator.SetTrigger("jump");
            mainCharacterAudioSource.PlayOneShot(sndJump);
        }
    }

    public void CharacterDead()
    {
        mainCharacterAnimator.SetTrigger("dead");
        GetComponent<MainCharacterController>().enabled = false;

    }

    public void CharacterPunch()
    {
        mainCharacterAnimator.SetTrigger("punch");
        GetComponent<MainCharacterController>().enabled = false;

    }

    public void CharacterRiflePunch()
    {
        mainCharacterAnimator.SetTrigger("riflePunch");
        GetComponent<MainCharacterController>().enabled = false;

    }

    public void PlaySoundImpact()
    {
        mainCharacterAudioSource.pitch = 1f;
        mainCharacterAudioSource.PlayOneShot(sndImpact);
    }

    public void PlayFootStep()
    {
        if (!mainCharacterAudioSource.isPlaying)
        {
            switchFoot = !switchFoot;

            if (switchFoot)
            {
                mainCharacterAudioSource.pitch = 2f;
                mainCharacterAudioSource.PlayOneShot(sndLeftFoot);
            }
            else
            {
                mainCharacterAudioSource.pitch = 2f;
                mainCharacterAudioSource.PlayOneShot(sndRightFoot);
            }
        }
    }

    public void SwitchIsJumping()
    {
        isJumping = false;
    }
}
