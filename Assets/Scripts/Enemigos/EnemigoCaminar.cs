using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCaminar : MonoBehaviour
{

[Header ("Puntos")]
public Transform ejeIzq;
public Transform ejeDer;

[Header ("Enemigo")]
public Transform enemigo;

[Header ("Movimiento")]
public float velocidad;
private Vector3 escala;

private bool moverIzq;

public float patrullaDuracion;
private float patrullaTimer;


[Header ("Animacion")]
public  Animator anim;

    private void Start(){
        escala = enemigo.localScale;
    }

    private void OnDisable(){
        anim.SetBool("mover", false);
    }

    private void Update(){
        if(moverIzq){
            if(enemigo.position.x >= ejeIzq.position.x){
                MoverDireccion(-1);
            }else{
                CambiarDireccion();
            }
        }else{
            if(enemigo.position.x <= ejeDer.position.x){
                MoverDireccion(1);
            }else{
                CambiarDireccion();
            }
        }
    }
    private void CambiarDireccion(){
        anim.SetBool("mover", false);

        patrullaTimer += Time.deltaTime;
        if(patrullaTimer > patrullaDuracion)
            moverIzq = !moverIzq;
    }

    private void MoverDireccion(int _direccion){
        patrullaTimer = 0;
        anim.SetBool("mover", true);

        enemigo.localScale = new Vector3(Mathf.Abs(escala.x) * _direccion, escala.y, escala.z);

        enemigo.position = new Vector3(enemigo.position.x + Time.deltaTime * _direccion * velocidad, enemigo.position.y, enemigo.position.z);
    }

}
