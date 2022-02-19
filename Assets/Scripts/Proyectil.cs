using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed;
    private float direccion;
    private bool hit;
    private float tiempoVida;
    private Animator anim;
    private BoxCollider2D boxCollider;


    private void Start(){
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update(){
        if (hit) return;
        float velocidad = speed * Time.deltaTime * direccion;
        transform.Translate(velocidad, 0, 0);

        tiempoVida += Time.deltaTime;
        if (tiempoVida > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explotar");
    }


    public void SetDireccion(float _direccion){
        tiempoVida = 0;

        direccion = _direccion;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
        float escalaX = transform.localScale.x;
        if (Mathf.Sign(escalaX) != _direccion)
            escalaX = -escalaX;

        transform.localScale = new Vector3(escalaX, transform.localScale.y, transform.localScale.z);
    }
    
    private void Desactivar(){
        gameObject.SetActive(false);
    }
}