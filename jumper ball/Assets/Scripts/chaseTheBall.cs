using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaseTheBall : MonoBehaviour {

    private float currentTime;
    private float speed= 0.4f;
    private Rigidbody2D endGame;


    // Use this for initialization
    void Start() {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        endGame = gameObject.GetComponent<Rigidbody2D>();
        while (currentTime < 60)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime += 01f;
        }

        endGame.gravityScale = endGame.gravityScale - speed * Time.deltaTime; ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Fin");
        }
    }
}
