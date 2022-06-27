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
    public GameObject DeathFX;
    public bool grounded;
    public bool allow_input;
    public Transform checkpoint;


    //gamemanager vars
    // checkpoint
    // score

    // lives
    // time

    void Start()
    {
        allow_input = true;
        Anim = this.gameObject.GetComponent<Animator>();

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
            AudioManager.instance.jumpS();
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

    //bool GroundCheck()
    //{
    //    Debug.DrawRay(transform.position, Vector2.down * 0.1f);
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, Vector2.down, out hit, distToGround + 0.1f))
    //    {
    //        _slopeAngle = (Vector3.Angle(hit.normal, transform.forward) - 90);
    //        return true;
    //    }
    //    else
    //    {
    //        grounded = false;
    //        return false;
    //    }


    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            grounded = true;
            
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
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
        stopplayer();
        Instantiate(DeathFX, this.transform);
        yield return new WaitForSeconds(1.5f);
        transform.position = checkpoint.position;
        this.GetComponent<BoxCollider2D>().enabled = true;
        allow_input = true;
        this.GetComponent<SpriteRenderer>().color = new Vector4(1,1,1,1);
        RB.isKinematic = false;
        RB.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void stopplayer()
    {
        RB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().color = new Vector4(0, 0, 0, 0);
        allow_input = false;
    }
}
