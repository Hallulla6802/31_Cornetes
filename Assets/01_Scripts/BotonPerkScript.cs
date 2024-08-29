using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BotonPerkScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI textoTitulo;
    public TextMeshProUGUI textoDescripcion;
    public TextMeshProUGUI textoParentisis;

    public string textoCambiadoTitulo = "";   
    public string textoCambiadoDescripcion = "";
    public string defaultTextoDescripcion = "";
    public string textoCambiadoParentisis = "";
    public void OnPointerEnter(PointerEventData eventData)
    {
        textoTitulo.text = textoCambiadoTitulo;
        textoDescripcion.text = textoCambiadoDescripcion;
        textoParentisis.text = textoCambiadoParentisis;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textoTitulo.text = null;
        textoDescripcion.text = defaultTextoDescripcion;
        textoParentisis.text = null;

    }
}
