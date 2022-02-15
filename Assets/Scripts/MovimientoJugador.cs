using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{ 
    public float speed=7;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
 
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
 
    private void Update()
    {
        float movJugador = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(movJugador * speed, body.velocity.y);
 
        //Girar jugador
        if (movJugador > 0.01f)
            transform.localScale = Vector3.one;
        else if (movJugador < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
 
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
            Jump();
 
        //setear animacion
        anim.SetBool("run", movJugador != 0);
        anim.SetBool("grounded", grounded);
    }
 
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
