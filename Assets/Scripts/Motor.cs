using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Motor : MonoBehaviour
{
    public float runSpeed;
    public float walkSpeed;
    public float speedAnimation;
    public float Gravity;
    public Text textCoins;
    public GameObject life;
    public GameObject final;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public AudioClip jumpSound;
    public AudioClip walkSound;
    public AudioClip runSound;
    public AudioClip attackSound;
    [HideInInspector]
    public int coins = 0;

    const int countOfDamageAnimations = 3;
    int lastDamageAnimation = -1;

    private CharacterController controller;
    private Transform cameraTransform;
    private Animator anim;
    private Vector3 moveVector;
    private Vector3 _velocity;
    private int _life = 9;
    private AudioSource source;
    private bool _isSound = false;
    private bool _isWalk = false;
    private bool _isRun = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _velocity.y += Gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);

        // Si no esta muerto
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            moveVector = Vector3.zero;

            float speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);

            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.z = Input.GetAxis("Vertical");

            controller.Move(moveVector * speed * Time.deltaTime);

            if (controller.velocity != Vector3.zero)
            {
                controller.Move(moveVector * speed * speedAnimation * Time.deltaTime);
                transform.forward = controller.velocity;
                if (speed == walkSpeed)
                {
                    Walk();
                }
                else
                {
                    Run();
                }
            }
            else
            {
                Stay();
            }
        }

        if (_life < 0)
        {
            Death();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Damage();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Sitting();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
        }

        UpdateCoinsCanvas();
        CheckInMap();
    }

    public void Stay()
    {
        anim.SetBool("Aiming", false);
        anim.SetFloat("Speed", 0f);
    }

    public void Walk()
    {
        anim.SetBool("Aiming", false);
        anim.SetFloat("Speed", 0.5f);
        if (!_isWalk)
        {
            source.PlayOneShot(walkSound, 1f);
            StartCoroutine(WaitWalk());
        }
    }

    public void Run()
    {
        anim.SetBool("Aiming", false);
        anim.SetFloat("Speed", 1f);
        if (!_isRun)
        {
            source.PlayOneShot(runSound, 1f);
            StartCoroutine(WaitRun());
        }
    }

    public void Attack()
    {
        Aiming();
        anim.SetTrigger("Attack");
        source.PlayOneShot(attackSound, 1f);
    }

    public void Death()
    {
        anim.SetTrigger("Death");
        if(!_isSound)
        {
            source.PlayOneShot(deathSound, 1f);
            _isSound = !_isSound;
        }
    }

    public void Damage()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death")) return;
        int id = Random.Range(0, countOfDamageAnimations);
        if (countOfDamageAnimations > 1)
            while (id == lastDamageAnimation)
                id = Random.Range(0, countOfDamageAnimations);
        lastDamageAnimation = id;
        anim.SetInteger("DamageID", id);
        anim.SetTrigger("Damage");
        LifeManager[] lifeManager = life.GetComponentsInChildren<LifeManager>();
        if (_life >= 0)
        {
            lifeManager[_life].UpdateLife();
            _life -= 1;
            if(_life < 0)
            {
                final.GetComponent<Image>().enabled = true;
                final.GetComponent<Final>().LostImage();
            }
        }
        source.PlayOneShot(hitSound, 1f);
    }

    public void Jump()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            anim.SetBool("Squat", false);
            anim.SetFloat("Speed", 0f);
            anim.SetBool("Aiming", false);
            anim.SetTrigger("Jump");
            source.PlayOneShot(jumpSound, 1f);
        }
    }

    public void Aiming()
    {
        anim.SetBool("Squat", false);
        anim.SetFloat("Speed", 0f);
        anim.SetBool("Aiming", true);
    }

    public void Sitting()
    {
        anim.SetBool("Squat", !anim.GetBool("Squat"));
        anim.SetBool("Aiming", false);
    }

    private void UpdateCoinsCanvas()
    {
        textCoins.text = coins.ToString();
    }

    public void YouWin()
    {
        final.GetComponent<Image>().enabled = true;
        final.GetComponent<Final>().WinImage();
        this.enabled = false;
    }

    public void CheckInMap()
    {
        if (transform.position.y < -5)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        Damage();
        transform.position = new Vector3(-3.9f, 1.1f, -11.6f);
    }

    IEnumerator WaitWalk()
    {
        _isWalk = true;
        yield return new WaitForSeconds(0.7f);
        _isWalk = false;
    }

    IEnumerator WaitRun()
    {
        _isRun = true;
        yield return new WaitForSeconds(0.750f);
        _isRun = false;
    }
}

