
using UnityEngine;

public class Movement : MonoBehaviour
{
    float MoveSpeed = 6f;
    int Health = 200;
    float JumpSpeed = 20f;
    float ClimbingSpeed = 5f;
    Vector2 DeathKick = new Vector2(30f, 30f);
    bool IsAlive = true;
    Rigidbody2D myrigidbody2D;
    Animator myanimator;
    Collider2D mycollider2D;
    [SerializeField] Healthbar healthbar;
    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        mycollider2D = GetComponent<Collider2D>();
        healthbar.SetMaxHealth(Health);
    }
    // Update is called once per frame
    void Update()
    {
        if (IsAlive)
        {
            Run();
            Jump();
            Climb();
        }
    }
    private void Run()
    {
        float Input_Speed = Input.GetAxis("Horizontal");
        FlipSprite(Input_Speed);
        Vector2 PlayerVelocity = new Vector2(Input_Speed * MoveSpeed, myrigidbody2D.velocity.y);
        myrigidbody2D.velocity = PlayerVelocity;
    }
    private void FlipSprite(float Input_Speed)
    {
        Vector3 CharacterScale = transform.localScale;
        if (Input_Speed < 0)
        {
            myanimator.SetBool("IsRunning", true);
            CharacterScale.x = -1;
        }
        else if (Input_Speed > 0)
        {
            myanimator.SetBool("IsRunning", true);
            CharacterScale.x = 1;
        }
        else
        {
            myanimator.SetBool("IsRunning", false);
        }
        transform.localScale = CharacterScale;
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && mycollider2D.IsTouchingLayers(LayerMask.GetMask("Layer 1")))
        {
            Vector2 JumpVelocity = new Vector2(0f, JumpSpeed);
            myrigidbody2D.velocity += JumpVelocity;
        }
    }
    private void Climb()
    {
        float Control = Input.GetAxis("Vertical");
        if (mycollider2D.IsTouchingLayers(LayerMask.GetMask("latter")) && Control != 0)
        {
            myrigidbody2D.gravityScale = 0f;
            myanimator.SetBool("IsClimbing", true);
            Vector2 ClimbVelocity = new Vector2(myrigidbody2D.velocity.x, ClimbingSpeed * Control);
            myrigidbody2D.velocity = ClimbVelocity;
        }
        else if (!mycollider2D.IsTouchingLayers(LayerMask.GetMask("latter")) || mycollider2D.IsTouchingLayers(LayerMask.GetMask("latter")) && Control == 0)
        {
            myrigidbody2D.gravityScale = 1f;
            myanimator.SetBool("IsClimbing", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(mycollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Health -= 50;
            myrigidbody2D.velocity = new Vector2(15f , 15f);
        }
        else if (mycollider2D.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            Health -= 100;
            myrigidbody2D.velocity = new Vector2(10f, 20f);
        }
            if (Health <= 0 && IsAlive)
        {
            IsAlive = false;
            Die();
        }
        healthbar.SetHealth(Health);
    }

    private void Die()
    {
        myanimator.SetTrigger("Die");
        myrigidbody2D.velocity = DeathKick;
        FindObjectOfType<LoadNextScene>().GameOver();
    }
    public void DealDamage(int Damage)
    {
        Health -= 20;
        healthbar.SetHealth(Health);
        if (Health <= 0 && IsAlive)
        {
            IsAlive = false;
            Die();
        }
    }
}
