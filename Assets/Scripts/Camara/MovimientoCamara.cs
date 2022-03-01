using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{

    public float speed;
    private float posicionCamara;
    private Vector3 velocidad = Vector3.zero;


    // Update is called once per frame
    void Update(){
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(posicionCamara, transform.position.y, transform.position.z), ref velocidad, speed);
    }

    public void moverSala(Transform _nuevaSala){
        posicionCamara = _nuevaSala.position.x;
    }
}
