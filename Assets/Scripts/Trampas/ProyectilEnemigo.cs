using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : DañarJugador
{
public float velocidad;
public float resetearTimer;
private float tiempoVida;
private Animator anim;
private BoxCollider2D collider;

private bool hit;


    // Start is called before the first frame update
    void Start(){
       anim = GetComponent<Animator>();
       collider = GetComponent<BoxCollider2D>();
    }

   public void ActivarProyectil()
    {
        hit = false;
        tiempoVida = 0;
        gameObject.SetActive(true);
        collider.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movVelocidad = velocidad * Time.deltaTime;
        transform.Translate(movVelocidad, 0, 0);

        tiempoVida += Time.deltaTime;
        if (tiempoVida > resetearTimer)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision); 
        collider.enabled = false;

        if (anim != null)
            anim.SetTrigger("explotar");
            gameObject.SetActive(false);
    }
    private void Desactivar()
    {
        gameObject.SetActive(false);
    }

}
