using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe4 : EnemigoBase
{
    private float tiempo;
    [SerializeField] private float tiempoLimite;
    private JugadorMovimiento jugador_;
    private bool activado = false;

    private void Update()
    {
        Actividad();
    }

    public override void Actividad()
    {
        jugador_ = GameObject.FindWithTag("Jugador").GetComponent<JugadorMovimiento>();
        tiempo += Time.deltaTime;

        if (tiempo >= tiempoLimite && activado == false)
        {
            StartCoroutine(ReducirVelocidadTemporal());
            activado = true;
        }
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

    private IEnumerator ReducirVelocidadTemporal()
    {
        float velocidadOriginal = jugador_.velocidadMovimiento;

        jugador_.velocidadMovimiento = velocidadOriginal - 6;
        Debug.Log("Jugador detenido");

        yield return new WaitForSeconds(5f);

        jugador_.velocidadMovimiento = velocidadOriginal;
        Debug.Log("Jugador liberado");
    }
}
