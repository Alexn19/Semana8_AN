using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe3 : EnemigoBase
{
    void Start()
    {
        BuscarJugador();
    }

    void Update()
    {
        Actividad();
    }

    public void BuscarJugador()
    {
        GameObject jugador_ = GameObject.FindWithTag("Jugador");
        if (jugador_ != null)
        {
            jugador = jugador_.transform;
        }
    }

    public override void Actividad()
    {
        transform.LookAt(jugador);
        transform.position += transform.forward * velocidad * Time.deltaTime;
    }

    public override void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            FindObjectOfType<ContadorMuertes>().AumentarMuertes();
            Destroy(gameObject);
        }
    }
}
