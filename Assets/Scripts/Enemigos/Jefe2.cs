using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe2 : EnemigoBase
{
    public override void Actividad()
    {
        Debug.Log("Jefe estatico aparecido");
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
