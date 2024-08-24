using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BotonPerkScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI textoQueCambiar; 
    public string textoCambiado = "X cosa";   
    public string defaultTexto = "";


    public void OnPointerEnter(PointerEventData eventData)
    {
        textoQueCambiar.text = textoCambiado;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textoQueCambiar.text = defaultTexto;
    }
}
