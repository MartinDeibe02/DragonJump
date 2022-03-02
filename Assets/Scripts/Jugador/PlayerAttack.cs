using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

    public float atacarCooldown;
    public Transform firePoint;
    public GameObject[] bolasFuego;
    private Animator anim;
    private MovimientoJugador movJugador;
    private float cooldown = Mathf.Infinity;

    public AudioClip sonidoFuego;


    private void Start(){
        anim = GetComponent<Animator>();
        movJugador = GetComponent<MovimientoJugador>();
    }

    private void Update(){
        if(Input.GetKey(KeyCode.Space) && cooldown > atacarCooldown && movJugador.puedeAtacar())
            Atacar();
        

        cooldown += Time.deltaTime;
    }

    private void Atacar(){
        ControladorSonido.instance.Play(sonidoFuego);
        anim.SetTrigger("attack");
        cooldown=0;

        bolasFuego[Encontar()].transform.position = firePoint.position;
        bolasFuego[Encontar()].GetComponent<Proyectil>().SetDireccion(Mathf.Sign(transform.localScale.x));

    }

        private int Encontar()
    {
        for (int i = 0; i < bolasFuego.Length; i++){
            if (!bolasFuego[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
