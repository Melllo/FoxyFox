using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class HeroController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject key;
    private bool facingRight = true;
    public bool isGrounded = true;
    private float jumpForce = 10f;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Platforms;
    [SerializeField] private float speed = 5f;
    Vector3 dir;
    LineRendererScript lr = new LineRendererScript();

    public struct userAttributes { }
    public struct appAttributes { }

    void Awake()
    {
        ConfigManager.FetchCompleted += SetJumpForce;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void SetJumpForce(ConfigResponse response)
    {
        Debug.Log("Force = " + jumpForce);
        jumpForce = ConfigManager.appConfig.GetFloat("jumpForce");
    }

   
    private void Update() 
    {
        if (Input.GetButton("Horizontal"))
        {
            if (facingRight == true && Input.GetKey(KeyCode.LeftArrow))
            {
                //player.transform.localRotation = Quaternion.Euler(0, 180, 0);
                facingRight = false;

                //transform.localScale = new Vector2(-1, 1);
                //Flip();
            }
            else if (facingRight == false && Input.GetKey(KeyCode.RightArrow))
            {
                //player.transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingRight = true;

                //transform.localScale = new Vector2(1, 1);
                //Flip();
            }
            Run();
        }
        else
        {
            anim.SetBool("running", false);
        }


        if(Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Platforms);
    }
    private void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        player.transform.localScale = Scaler;
    }

    private void Run() 
    {
        dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime * 5);
        anim.SetBool("running", true);
    }

    void OnDestroy()
    {
        ConfigManager.FetchCompleted -= SetJumpForce;
    }

}
