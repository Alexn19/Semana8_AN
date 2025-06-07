using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemigoBase : MonoBehaviour
{
    public float velocidad;
    public float vida;
    public Transform jugador;

    public abstract void Actividad();

    public abstract void RecibirDaño(int cantidad);
}
