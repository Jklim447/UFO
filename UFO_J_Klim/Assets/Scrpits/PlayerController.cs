using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System;

public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    Rigidbody2D rb2dl;
    // Start is called before the first frame update
    private int count = 0;

    public object ScoreText { get; private set; }

    void Start()
    {
        rb2dl = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2dl.AddForce(movement * 15);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DontDestroyOnLoad(Collision2D collision);
        {
            AudioManager.instance.PlayMusic("Bouce");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            count++; 
            Destroy(collision.gameObject);
            UpdateScoreText();
            AudioManager.instance.PlayMusic("Coin");
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "Wynik" + count;
        if (count == 4)
        {

            winText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            StartCoroutine(StopTime());
            AudioManager.instance.PlayMusic("Win");
            
        }
    }


    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Level02");
    }
}

   