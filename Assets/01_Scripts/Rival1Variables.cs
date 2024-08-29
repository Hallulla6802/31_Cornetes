using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival1Variables: MonoBehaviour
{
    [Header("Rival 1 Variables")]
    [Space]

    public float rival1CurrentLife;
    public float rival1MaxLife = 600;

    void Update()
    {
        if (rival1CurrentLife <0)
        {
            rival1CurrentLife = 0;
        }
    }

}
