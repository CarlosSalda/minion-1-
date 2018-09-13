using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class personajeScript : MonoBehaviour {

    //float privado, para manejo de la velocidad hacia el lado izquierdo
    private float speedRight = 4f;

    //float privado, para manejo de la velocidad de salto
    private float jumpDistance = 220f;

    private bool estaEnPiso = false;
    private Rigidbody2D personaje;
    private SpriteRenderer spritePersonaje;
    private float currentTime;
    private SpriteRenderer TriggerAccion;
    private SpriteRenderer CollisionAccion;
    private bool fueraDeFocoHaciaDerecha;
    private bool fueraDeFocoHaciaIzquierda;
    private bool estaEnPowerUp;


    void Awake()
    {
        spritePersonaje = gameObject.GetComponent<SpriteRenderer>();
        personaje = gameObject.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start() {
        
    }
    
    IEnumerator TirarLazyGround(SpriteRenderer ground)
    {
        while (currentTime < 2.5f)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime += 0.1f;
        }
        Destroy(ground.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerAccion = collision.gameObject.GetComponent<SpriteRenderer>();

        if (TriggerAccion.name == "baloon")
        {
            estaEnPowerUp = true;
            Destroy(collision.gameObject);
            personaje.gravityScale = personaje.gravityScale - 27f * Time.deltaTime;
            StartCoroutine(FinBaloonPowerUp());
        }

    }

    IEnumerator FinBaloonPowerUp()
    {
        while (currentTime < 8)
        {
            yield return new WaitForSeconds(0.1f);
            currentTime += 0.1f;
        }
        estaEnPowerUp = false;
        personaje.gravityScale = personaje.gravityScale + 55f * Time.deltaTime;
    }


    void MoverDerechaOIzquierda()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //mover derecha
            RotarPersonajeDer();
            this.transform.Translate(speedRight * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //mover izquierda
            rotarPersonajeIzq();
            this.transform.Translate(-speedRight * Time.deltaTime, 0, 0);
        }
    }
    void RotarPersonajeDer() {
        if (GetComponent<SpriteRenderer>().flipX)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void rotarPersonajeIzq()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionAccion = collision.gameObject.GetComponent<SpriteRenderer>();

        if (CollisionAccion.tag == "Ground") {
            estaEnPiso = true;
        }

    }

   void Salto() {
        //La pelota va a saltar con space o flecha arriba
        if (Input.GetKeyDown(KeyCode.Space) && estaEnPiso && !estaEnPowerUp) {
            estaEnPiso = false;
            personaje.AddForce(transform.up * jumpDistance);
        }
    }



    private void OnBecameInvisible()
    {
        SceneManager.LoadScene("Fin");
    }


    void Update () {
        MoverDerechaOIzquierda();
        Salto();
    }
}
