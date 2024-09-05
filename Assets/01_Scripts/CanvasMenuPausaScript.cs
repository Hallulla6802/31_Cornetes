using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuPausaScript : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject panel;

    private void Start()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void AbrirMenuDePausa()
    {
        botonPausa.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void CerrarMenuDePausa()
    {
        botonPausa.SetActive(true);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
