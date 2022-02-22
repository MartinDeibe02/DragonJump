using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSaw : MonoBehaviour
{

public float danho;
public float distanciaMovimiento;
public float velocidad;
private bool moverIzq;
private float ejeIzq;
private float ejeDer;


    void Start(){
        ejeIzq = transform.position.x - distanciaMovimiento;
        ejeDer = transform.position.x + distanciaMovimiento;
    }

    // Update is called once per frame
    void Update()
    {
        if(moverIzq){
            if(transform.position.x > ejeIzq){
                transform.position = new Vector3(transform.position.x - velocidad * Time.deltaTime, transform.position.y, transform.position.z);

            }else{
                moverIzq = false;
            }
        }else{
            if(transform.position.x < ejeDer){
                transform.position = new Vector3(transform.position.x + velocidad * Time.deltaTime, transform.position.y, transform.position.z);


            }else{
                moverIzq = true;
            }
        }
        
    }

private void OnTriggerEnter2D(Collider2D collider){
    if(collider.tag == "Player"){
        collider.GetComponent<Salud>().RecibirDano(danho);
    }
}



}
