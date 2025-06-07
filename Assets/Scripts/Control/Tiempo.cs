using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tiempo : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    private float tiempoTranscurrido = 0f;
    private bool contar = true;

    private void Update()
    {
        if (contar)
        {
            tiempoTranscurrido += Time.deltaTime;

            int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60f);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);

            textoTiempo.text = $"{minutos:00}:{segundos:00}";
        }
    }

    public void GuardarTiempo()
    {
        DatosJuego.Instancia.tiempoFinal = tiempoTranscurrido;
        contar = false;
    }
}
