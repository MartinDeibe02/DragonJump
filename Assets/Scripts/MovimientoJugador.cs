using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{ 
    public float speed=10;
    public float jumpPower;
    private Rigidbody2D body;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Animator anim;
    private float movJugador;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;


    //dash
    public float dashSpeed;
    public float duracionDash;
    private float dashCooldown;
    public float DashColReset;

 
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



        //dash
        dashCooldown -= Time.deltaTime;
        if(dashCooldown<1){
            dashCooldown = -1;
        }else{
            dashCooldown -= Time.deltaTime;
        }

        if(Input.GetMouseButton(0)){ 
            if(dashCooldown<=0){
                StartCoroutine(Dash());
            }
        }


//saltar pared
        if(wallJumpCooldown > 0.2f){


            body.velocity = new Vector2(movJugador * speed, body.velocity.y);

            if(onWall() && !isGrounded()){ 
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }else
                 body.gravityScale =7;
                    
                    
            if (Input.GetKey(KeyCode.UpArrow))
            Jump();

                    
                

      
        }else
            wallJumpCooldown += Time.deltaTime;
        
    }
 
 private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (movJugador == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }
 

    private bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

        private bool onWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool puedeAtacar(){
        return movJugador == 0 && isGrounded() && !onWall();
    }

    IEnumerator Dash(){
        float startTime = Time.time;
        float escalax = transform.localScale.x;

        while(Time.time < startTime + duracionDash){
            float movimiento = dashSpeed * Time.deltaTime;

            if(Mathf.Sign(escalax)==1){
                transform.Translate(movimiento,0,0);
            }else{
                transform.Translate(-movimiento,0,0);
            }

            dashCooldown = DashColReset;
            yield return null;
        }
    }
}
