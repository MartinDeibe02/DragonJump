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
    void Start()
    {
     saludActual = saludInicial;
     anim = GetComponent<Animator>();

    }

    public void RecibirDano(float _daño){
        saludActual = Mathf.Clamp(saludActual - _daño, 0, saludInicial);


        if(saludActual>0){
            anim.SetTrigger("danho");
        }else{
            if(!muerto){
            anim.SetTrigger("muerto");
            GetComponent<MovimientoJugador>().enabled = false;
            muerto = true;
            }

        }
    }

}
