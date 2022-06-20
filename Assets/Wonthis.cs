using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonthis : MonoBehaviour
{
    public GameObject wiinnigscreen;
    public GameObject Particleswd;
    public GameObject player;
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 94 && !done)
        {
            Instantiate(Particleswd, this.transform);
            wiinnigscreen.SetActive(true);
            done = true;
        };
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("ENTERED!");
        if (collision.CompareTag("Player"))
        {
            Instantiate(Particleswd, this.transform);
            wiinnigscreen.SetActive(true);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Instantiate(Particleswd, this.transform);
            wiinnigscreen.SetActive(true);
        }

    }

}
