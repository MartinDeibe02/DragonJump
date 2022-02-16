using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{ 
    public float speed=7;
    private Rigidbody2D body;
    public LayerMask groundLayer;
        public LayerMask wallLayer;

    private Animator anim;
    private float movJugador;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;

 
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
 
    private void Update()
    {
        movJugador = Input.GetAxis("Horizontal");
 
        //Girar jugador
        if (movJugador > 0.01f)
            transform.localScale = Vector3.one;
        else if (movJugador < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
 
 
 
        //setear animacion
        anim.SetBool("run", movJugador != 0);
        anim.SetBool("grounded", isGrounded());


//saltar pared
        if(wallJumpCooldown < 0.2f){
            if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
                    Jump();

            body.velocity = new Vector2(movJugador * speed, body.velocity.y);

            if(onWall() && !isGrounded()){ 
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }else{

                body.gravityScale =2;
            }

      
        }else{
            wallJumpCooldown += Time.deltaTime;
        }
    }
 
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

        private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
