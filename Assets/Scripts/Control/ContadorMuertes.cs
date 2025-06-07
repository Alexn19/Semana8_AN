using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameJolt.UI;

public class ContadorMuertes : MonoBehaviour
{
    public TextMeshProUGUI textoMuertes;
    private float muertesActuales;

    private void Update()
    {
        textoMuertes.text = $"Enemigos matados: {muertesActuales}";
    }

    public void AumentarMuertes()
    {
        muertesActuales++;
    }

    public void GuardarMuertes()
    {
        DatosJuego.Instancia.muertesFinales = muertesActuales;
    }
}
