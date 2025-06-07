using System.Collections;
using System.Collections.Generic;
using System.Threading;
using GameJolt.API;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class JugadorMovimiento : MonoBehaviour
{
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Transform puntoDeDisparo;
    [SerializeField] private float velocidadBala;

    public float velocidadMovimiento = 5;
    private Rigidbody rb;
    private Vector3 direccionMovimiento;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        Movimiento();
        AccionDisparar();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direccionMovimiento * velocidadMovimiento * Time.fixedDeltaTime);
    }

    private void Movimiento()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        direccionMovimiento = new Vector3(moveX, 0f, moveZ).normalized;

        if (direccionMovimiento != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direccionMovimiento, Vector3.up);
            transform.rotation = toRotation;
        }
    }

    private void AccionDisparar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
    }
    private void Disparar()
    {
        if (balaPrefab != null && puntoDeDisparo != null)
        {
            GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, Quaternion.Euler(-90f, transform.eulerAngles.y, 0f));
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.velocity = transform.forward * velocidadBala;
            }
        }
    }

    private void Muerte()
    {
        FindObjectOfType<Tiempo>().GuardarTiempo();
        FindObjectOfType<ContadorMuertes>().GuardarMuertes();
        FindObjectOfType<ContadorNivel>().GuardarNivel();
        PonerRankings();
        SceneManager.LoadScene("Derrota");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Muerte();
        }
    }

    private void PonerRankings()
    {
        float tiempo = DatosJuego.Instancia.tiempoFinal;
        float nivel = DatosJuego.Instancia.nivelesFinal;

        Scores.Add(Mathf.CeilToInt(tiempo), $"{Mathf.CeilToInt(tiempo)} segundos", 1010952, "", (success) =>
        {
        });
        Scores.Add(Mathf.CeilToInt(nivel), $"{Mathf.CeilToInt(nivel)} niveles", 1010949, "", (success) =>
        {
        });

    }
}
