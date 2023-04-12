using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2dl;
    // Start is called before the first frame update
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
        void Update()
    {
        
    }
}
