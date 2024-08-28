using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
   
    public GameObject canvas;  // El Canvas que se va a desactivar
    public GameObject[] gameObjectsToActivate;  // Los objetos que quieres activar

    void Update()
    {
        if (!canvas.activeSelf) // Si el Canvas está desactivado
        {
            foreach (GameObject obj in gameObjectsToActivate)
            {
                obj.SetActive(true);  // Activa cada uno de los objetos
            }
        }

        if (canvas.activeSelf) // Si el Canvas está desactivado
        {
            foreach (GameObject obj in gameObjectsToActivate)
            {
                obj.SetActive(false);  // Activa cada uno de los objetos
            }
        }
    }
}

