using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using GameJolt.UI;
using GameJolt.API;

public class DatosJuego : MonoBehaviour
{
    public static DatosJuego Instancia { get; private set; }

    public float tiempoFinal;
    public float muertesFinales;
    public float nivelesFinal;
    private bool desbloqueado = false;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (muertesFinales >= 10 && desbloqueado == true)
        {
            Trophies.Unlock(269520);
        }
    }
}
