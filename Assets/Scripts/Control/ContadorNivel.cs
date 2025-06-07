using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorNivel : MonoBehaviour
{
    public TextMeshProUGUI textoNivel;
    private float nivelActual = 0;

    private void Update()
    {
        textoNivel.text = $"Nivel: {nivelActual + 1}";
    }

    public void AumentarNivel()
    {
        nivelActual++;
    }

    public void GuardarNivel()
    {
        DatosJuego.Instancia.nivelesFinal = nivelActual;
    }
}
