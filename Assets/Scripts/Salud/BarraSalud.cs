using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraSalud : MonoBehaviour
{

    public Salud saludJugador;
    public Image saludTotalBar;
    public Image saludActualBar;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update(){
      saludActualBar.fillAmount = saludJugador.saludActual / 10;  
    }
}
