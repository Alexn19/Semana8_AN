using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using GameJolt.UI;
using GameJolt.API;

public class DerrotaInterfaz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tiempoTexto;
    [SerializeField] private TextMeshProUGUI muertesTexto;
    [SerializeField] private TextMeshProUGUI nivelesTexto;

    private void Start()
    {
        Trophies.Unlock(270169);
        tiempoTexto.text = $"Tiempo sobrevivido: {DatosJuego.Instancia.tiempoFinal}";
        muertesTexto.text = $"Muertes finales: {DatosJuego.Instancia.muertesFinales}";
        nivelesTexto.text = $"Nivel alcanzando: {DatosJuego.Instancia.nivelesFinal}";
    }
}
