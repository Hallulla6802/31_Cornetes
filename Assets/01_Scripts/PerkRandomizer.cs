using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkRandomizer : MonoBehaviour
{
    public GameObject[] cartas;
    void Start()
    {
        RamdomizaLasCartas();
    }
    void RamdomizaLasCartas()
    {
        foreach(GameObject obj in cartas)
        {
            obj.SetActive(false);
        }
        int ramdomIndex = Random.Range(0, cartas.Length);
        if(cartas.Length > 0)
        {
            cartas[ramdomIndex].SetActive(true);
        }
    }
}
