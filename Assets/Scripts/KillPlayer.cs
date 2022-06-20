using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController pc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("COLLIDED");
        if (collision.collider.CompareTag("Player"))
        {
            pc.respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("COLLIDED");
        if (collision.CompareTag("ground"))
        {
            pc.respawn();
        }
    }
}
