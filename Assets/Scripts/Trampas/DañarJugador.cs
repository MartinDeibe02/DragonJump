using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañarJugador : MonoBehaviour
{

public float daño;

	protected void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == "Player"){
			collider.GetComponent<Salud>().RecibirDano(daño);
		}
	}
}
