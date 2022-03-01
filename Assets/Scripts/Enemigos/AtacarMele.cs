using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacarMele : MonoBehaviour
{
	[Header ("Atacar")]
	public float atacarCooldown;
	public float rango;
	public int daño;

	[Header ("Collider")]
	public float collideDist;
	public BoxCollider2D boxCollider;

	public LayerMask playerLayer;

	private float cooldownTimer = Mathf.Infinity;

	private Animator anim;
	private Salud saludJug;
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
				anim.SetTrigger("ataquemele");
			}
		}

		if(enemigoCaminar != null){
			enemigoCaminar.enabled = !playerVista();
		}
	}

	private bool playerVista(){
		RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * rango * transform.localScale.x * collideDist,
		new Vector3(boxCollider.bounds.size.x * rango, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
		0, Vector2.left, 0, playerLayer);

		if(hit.collider != null){
			saludJug =hit.transform.GetComponent<Salud>();
		}

		return hit.collider != null;
	}

	private void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * rango * transform.localScale.x * collideDist,
		new Vector3(boxCollider.bounds.size.x * rango, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
	}

	private void DañarJugador(){
		if(playerVista()){
			saludJug.RecibirDano(daño);
		}
	}
}
