using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoRango : MonoBehaviour
{
	[Header ("Atacar")]
	public float atacarCooldown;
	public float rango;
	public int daño;

	[Header ("Ataque rango")]
	public Transform firePoint;
	public GameObject[] bolasFuego;

	[Header ("Collider")]
	public float collideDist;
	public BoxCollider2D boxCollider;

	public LayerMask playerLayer;
	private float cooldownTimer = Mathf.Infinity;

	private Animator anim;
	private EnemigoCaminar enemigoCaminar;



	private void Start(){
			anim = GetComponent<Animator>();
			enemigoCaminar = GetComponentInParent<EnemigoCaminar>();
	}

	private void Update(){
		cooldownTimer += Time.deltaTime;

		//atacar
		
		if(playerVista()){
			if(cooldownTimer > atacarCooldown){

				cooldownTimer =0;
				anim.SetTrigger("ataquerango");
			}
		}

		if(enemigoCaminar != null){
			enemigoCaminar.enabled = !playerVista();
		}
	}

	private void AtaqueRango(){
		cooldownTimer = 0;

		bolasFuego[Encontar()].transform.position = firePoint.position;
		bolasFuego[Encontar()].GetComponent<ProyectilEnemigo>().ActivarProyectil();


	}

	private int Encontar(){
        for (int i = 0; i < bolasFuego.Length; i++){
            if (!bolasFuego[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

	private bool playerVista(){
		RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * rango * transform.localScale.x * collideDist,
		new Vector3(boxCollider.bounds.size.x * rango, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
		0, Vector2.left, 0, playerLayer);


		return hit.collider != null;
	}

	private void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * rango * transform.localScale.x * collideDist,
		new Vector3(boxCollider.bounds.size.x * rango, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
	}
}


