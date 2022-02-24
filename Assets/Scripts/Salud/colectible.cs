using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colectible : MonoBehaviour
{

    public float valorVida;


    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            collider.GetComponent<Salud>().AñadirVida(valorVida);
            gameObject.SetActive(false);
        }
    }

}
