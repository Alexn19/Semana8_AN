using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    private float tiempoActual;

    private float tiempo = 0;

    private float tiempo2 = 0;

    private int nivel = 0;

    private List<int> fibonacci = new List<int>() { 1, 1 };

    [SerializeField] private GameObject[] enemigos;

    [SerializeField] private GameObject[] jefes;

    [SerializeField] private float intervaloJefe;

    [SerializeField] private float espacioEntreApariciones = 0.3f;

    [SerializeField] private float tiempoinicial = 10f;

    [SerializeField] private float tiempoMinimo = 2f;

    [SerializeField] private float aumentoDificultad = 0.5f;

    public int Nivel => nivel;

    private void Start()
    {
        tiempoActual = tiempoinicial;
    }

    private void Update()
    {
        tiempo += Time.deltaTime;
        tiempo2 += Time.deltaTime;

        if (tiempo >= tiempoActual)
        {
            IniciarNivel();
            tiempo = 0f;

            nivel++;
            FindObjectOfType<ContadorNivel>().AumentarNivel();

            tiempoActual = Mathf.Max(tiempoMinimo, tiempoActual - aumentoDificultad);
        }
        if (tiempo2 >= intervaloJefe)
        {
            GeneracionJefe();
            tiempo2 = 0;
        }
    }

    void IniciarNivel()
    {
        int contarEnemigos = Fibonacci(nivel);

        for (int i = 0; i < contarEnemigos; i++)
        {
            Vector3 posicion = PosicionDeAparicion();
            GameObject prefabEnemigo = enemigos[Random.Range(0, enemigos.Length)];
            Instantiate(prefabEnemigo, posicion, Quaternion.identity);
        }
    }

    #region
    private int Fibonacci(int index)
    {
        while (fibonacci.Count <= index)
        {
            int fibo = fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2];
            fibonacci.Add(fibo);
        }
        return fibonacci[index];
    }

    Vector3 PosicionDeAparicion()
    {
        float x = Random.Range(-10f + espacioEntreApariciones, 10f - espacioEntreApariciones);
        float z = Random.Range(-10f + espacioEntreApariciones, 10f - espacioEntreApariciones);
        return new Vector3(x, 0f, z);
    }

    public int ObtenerNivel()
    {
        return nivel;
    }

    private void GeneracionJefe()
    {
        Vector3 posicion = PosicionDeAparicion();
        GameObject enemyPrefab = jefes[Random.Range(0, jefes.Length)];
        Instantiate(enemyPrefab, posicion, Quaternion.identity);
    }

    #endregion
}
