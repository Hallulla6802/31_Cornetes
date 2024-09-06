using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMenuPausaScript : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject panelPausa;
    public GameObject panelMenuPausa;
    public GameObject panelAjustes;

    private void Start()
    {
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
    }

    public void AbrirMenuDePausa()
    {
        botonPausa.SetActive(false);
        panelPausa.SetActive(true);
        Time.timeScale = 0f;

    }

    public void CerrarMenuDePausa()
    {
        botonPausa.SetActive(true);
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void AbrirMenuDeAjustes()
    {
        panelMenuPausa.SetActive(false);
        panelAjustes.SetActive(true);
    }   
    public void CerrarMenuDeAjustes()
    {       
        panelMenuPausa.SetActive(true);
        panelAjustes.SetActive(false);
    }  
    public void SalirDelJuego()
    {
        Time.timeScale = 1f;
    }
}
