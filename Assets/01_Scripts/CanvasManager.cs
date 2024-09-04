using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
   
    public GameObject canvas;  // El Canvas que se va a desactivar
    public GameObject[] gameObjectsToActivate;  // Los objetos que quieres activar

    void Awake()
    {
        

        foreach (GameObject obj in gameObjectsToActivate)
            {
                obj.SetActive(false);  // Activa cada uno de los objetos
            }
    }
    public void ActivateGameObjects()
    {
        /* if (!canvas.activeSelf) // Si el Canvas esta desactivado
        {
            foreach (GameObject obj in gameObjectsToActivate)
            {
                obj.SetActive(true);  // Activa cada uno de los objetos
            }
        } */
        
            foreach (GameObject obj in gameObjectsToActivate)
            {
                obj.SetActive(true);  // Activa cada uno de los objetos
            }
        
    }

    
}

