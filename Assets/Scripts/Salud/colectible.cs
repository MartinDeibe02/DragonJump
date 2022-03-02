using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectible : MonoBehaviour
{

    public float valorVida;

    public AudioClip pick;


    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            ControladorSonido.instance.Play(pick);
            collider.GetComponent<Salud>().AñadirVida(valorVida);
            gameObject.SetActive(false);
        }
    }

}
