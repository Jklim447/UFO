using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2dl;
    // Start is called before the first frame update
    private int count = 0;
    void Start()
    {
        rb2dl = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
        private void FixedUpdate()
    {
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical=Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2dl.AddForce(movement * 15);
    }
        
        private void onTriggerEnder2D(Collider2D collision)
    {
        if(collision.CompareTag("Pickup"))
        {
            count = count + 1;
            Destroy(collision.gameObject);
        }
    }
}
