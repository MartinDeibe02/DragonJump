using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{

    public Transform sala1;
    public Transform sala2;

    public MovimientoCamara camara;


    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            if(collider.transform.position.x < transform.position.x){ 
                camara.moverSala(sala2);
            }else{
                camara.moverSala(sala1);
            }
        }
    }
}
