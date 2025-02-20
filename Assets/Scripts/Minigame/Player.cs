using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;
    GameManager gameManager = null;
    AudioSource audioSource = null; 

    public float flapForce = 6f; // 짬푸능력
    public float forwardSpeed = 3f; // 앞으로 간다잇
    public AudioClip jumpSound; // 짬푸 소리를 넣어줍니다
    public bool isDead = false;
    float deathCooldown = 0f;
    bool isFlap = false;
    public bool godMode = false;


    void Start()
    {
        gameManager = GameManager.Instance;
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();
        audioSource = gameObject.AddComponent<AudioSource>();

        if (animator == null) //널 체크
        {
            Debug.LogError("Not Founded Animator");
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }

       
    }

    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
                // 점프 소리 재생
                if (jumpSound != null)
                {
                    audioSource.Stop(); // 소리 멈춰
                    audioSource.PlayOneShot(jumpSound); // 누를떄마다 소리재생
                }

            }
        }
       
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) // 체크용 무적모드
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        gameManager.GameOver();
    }
}