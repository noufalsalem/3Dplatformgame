using System.Collections; 
using System.Collections.Generic; //for arrays and lists
using UnityEngine; //gets unity library 
public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpForce = 2;
    [SerializeField] float jumpVelocity = 2;
    [SerializeField] bool onGround = true;
    //[SerializeField] private LayerMask platformLayerMask;
    public Animator anim;

    public float fallMultiplier = 2.5f;

    public static PlayerControl playerInstance; //The OG Player instance
    
    void Start()
    {
        if (playerInstance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        playerInstance = this;


        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
            rb.velocity = Vector3.up * jumpVelocity;
            rb.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
            onGround = false;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }


    //FixedUpdate called before any Physics fn
    void FixedUpdate()
    {
        //move player's character in the direction of the player's input;
        // 1. Rigidbody
        // 2. transform.position
        // 3. transform.Translate 
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float x = Input.GetAxis("Horizontal"); //From Unity's Input Manager
            float y = Input.GetAxis("Vertical");
            /*translation *= Time.deltaTime;
            rotation *= Time.deltaTime;**/
            y = Mathf.Clamp01(y);
            transform.Translate(x * speed * Time.deltaTime, 0, y * speed * Time.deltaTime); //x, y, z axis
                                                                                                                  //transform.Rotate(0, rotation, 0);
                                                                                                                  //run animation

            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

      
 
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
