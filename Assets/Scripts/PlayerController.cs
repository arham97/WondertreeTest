using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator Anim;
    public float speed;
    public float jumpforce;
    public Rigidbody2D RB;


    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    public float distToGround;
    public LayerMask Groundlayer;
    public GameObject DeathFX;
    public bool grounded;
    public bool allow_input;
    public Transform checkpoint;

    void Start()
    {
        allow_input = true;
        Anim = this.gameObject.GetComponent<Animator>();
        distToGround = this.GetComponent<Collider2D>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("IsGrounded", grounded);
        if (allow_input)
        {
            Controls();
        }
    }

    private void FixedUpdate()
    {
        
    }

    void Controls()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Anim.SetBool("Running",true);
            transform.position = this.transform.position + new Vector3 (speed,0,0)*Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);

        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Anim.SetBool("Running", true);
            transform.position = this.transform.position + new Vector3(-speed, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            Anim.SetBool("Running", false);

        }


        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            print("Space pressed");
            RB.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);

            if (RB.velocity.y >= 0)
            {
                RB.gravityScale = gravityScale;
            }
            else if (RB.velocity.y < 0)
            {
                RB.gravityScale = fallingGravityScale;

            }
        }


    }

    //bool CheckGround()
    //{
       
    //   //return Physics.Raycast(transform.position, -Vector3.up, distToGround+0.1f);

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = false;
        }
        else
        {
            grounded = false;
        }

    }

    public void respawn()
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        RB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        this.GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, 0); 
        Instantiate(DeathFX, this.transform);
        allow_input = false;
        yield return new WaitForSeconds(1.5f);
        transform.position = checkpoint.position;
        allow_input = true;
        this.GetComponent<SpriteRenderer>().color = new Vector4(1,1,1,1);
        RB.isKinematic = false;
        RB.constraints = RigidbodyConstraints2D.FreezeRotation;


    }
}
