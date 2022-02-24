using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour
{

    public float saludInicial;
    //get desde otro script, set solo en este script
    public float saludActual { get; private set;}
    // Start is called before the first frame update
    private Animator anim;
    private bool muerto;


    [Header("iframes")]
    public float invulnerableDur;
    public int numeroFlash;
    private SpriteRenderer spriteRend;

    void Start()
    {
     saludActual = saludInicial;
     anim = GetComponent<Animator>();
     spriteRend = GetComponent<SpriteRenderer>();

    }

    public void RecibirDano(float _daño){
        saludActual = Mathf.Clamp(saludActual - _daño, 0, saludInicial);


        if(saludActual>0){
            anim.SetTrigger("danho");
            StartCoroutine(invulnerabilidad());
        }else{
            if(!muerto){
            anim.SetTrigger("muerto");
            GetComponent<MovimientoJugador>().enabled = false;
            muerto = true;
            }

        }
    }

    public void AñadirVida(float valor){
        saludActual = Mathf.Clamp(saludActual + valor, 0, saludInicial);

    }

    private IEnumerator invulnerabilidad(){
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //duracion de invulnerabilidad
        for(int i=0; i<numeroFlash;i++){
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(invulnerableDur / (numeroFlash * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerableDur / (numeroFlash * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }

}
