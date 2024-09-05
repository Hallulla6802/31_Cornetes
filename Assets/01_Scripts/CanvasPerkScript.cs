using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasPerkScript : MonoBehaviour
{
    public GameObject canvasPerk;

    public GameObject panelPerk1;
    public GameObject panelPerk2;
    public GameObject panelPerk3;
    public GameObject panelPerk4;

    public GameObject cartaNoSelecionable;

    public  GameObject carta4;

    private AudioSourceManager _audioSourceMan;

    private void Start()
    {
        DataManager.perkElegido = 0;

        panelPerk1.SetActive(false);
        panelPerk2.SetActive(false);
        panelPerk3.SetActive(false);
        panelPerk4.SetActive(false);
        cartaNoSelecionable.SetActive(false);

        _audioSourceMan = FindObjectOfType<AudioSourceManager>();
    }

    private void Update()
    {
        if (DataManager.perk4Elegido)
        {
           carta4.SetActive(false);
        }
    }

    public void AbrirPerk1() //Perk Curativo
    {
        _audioSourceMan.healingPowerUp.Play();
        panelPerk1.SetActive(true);
    }
    public void AbrirPerk2() //Perk Fuerza
    {
        _audioSourceMan.strenghtPowerUp.Play();
        panelPerk2.SetActive(true);
    }
    public void AbrirPerk3() // Perk Velocidad
    {
        _audioSourceMan.speedPowerUp.Play();
        panelPerk3.SetActive(true);
    }
    public void AbrirPerk4() // Perk Revivir
    {
        _audioSourceMan.resurrectPowerUp.Play();
        panelPerk4.SetActive(true);
    }

    public void CerrarTodosLosPaneles()
    {
        panelPerk1.SetActive(false);
        panelPerk2.SetActive(false);
        panelPerk3.SetActive(false);
        panelPerk4.SetActive(false);
    }

    public void ConfirmarPerk1()
    {
        DataManager.perkElegido = 1;
        CerrarCanvas();
       
    }

    public void ConfirmarPerk2()
    {
        DataManager.perkElegido = 2;
        CerrarCanvas();

    }

    public void ConfirmarPerk3()
    {
        DataManager.perkElegido = 3;
        CerrarCanvas();

    }

    public void ConfirmarPerk4()
    {
        DataManager.perkElegido = 4;
        DataManager.perk4Elegido = true;
        cartaNoSelecionable.SetActive(true);
        CerrarCanvas();

    }

    public void CerrarCanvas()
    {
        canvasPerk.SetActive(false);
        Debug.Log("Perk elegido:" + DataManager.perkElegido);
        
    }
}
