using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkRandomizer : MonoBehaviour
{
    public GameObject[] cartasFila1;
    public GameObject[] cartasFila2;
    [SerializeField] int ramdomIndex1;
    [SerializeField] int ramdomIndex2;
    void Start()
    {
        RamdomizaLasCartas();
    }
    void RamdomizaLasCartas()
    {
        foreach(GameObject obj in cartasFila1)
        {
            obj.SetActive(false);
        }
        foreach(GameObject obj in cartasFila2)
        {
            obj.SetActive(false);
        }
        do
        {
            ramdomIndex1 = Random.Range(0, cartasFila1.Length);
            ramdomIndex2 = Random.Range(0, cartasFila2.Length);
        }
        while(ramdomIndex1 == ramdomIndex2);
      
        if(cartasFila1.Length > 0)
        {
            cartasFila1[ramdomIndex1].SetActive(true);
        }
        
        if(cartasFila2.Length > 0)
        {
            cartasFila2[ramdomIndex2].SetActive(true);
        }  
    }
}
