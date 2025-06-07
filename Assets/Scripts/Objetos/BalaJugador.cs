using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    [SerializeField] private float duracion;
    void Start()
    {
        Destroy(gameObject, duracion);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemigoBase enemigo = other.GetComponent<EnemigoBase>();
            if (enemigo != null)
            {
                enemigo.RecibirDa�o(1);
                Destroy(gameObject);
            }
        }
    }

}
