using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    public static bool pausa = false;
    public GameObject menuPause;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            if(pausa){
                resume();
            }else{
                pausar();
            }
        }
    }

    public void resume(){
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }

    void pausar(){
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }

    public void cargarMenu(){
        SceneManager.LoadScene(0);
    }

    public void salir(){
        Application.Quit();
    }
}
