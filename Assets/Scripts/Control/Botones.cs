using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using GameJolt.UI;
using GameJolt.API;

public class Botones : MonoBehaviour
{
    private void Start()
    {
        Trophies.Unlock(270166);
    }

    public void EmpezarPartida()
    {
        SceneManager.LoadScene("Partida");
        Trophies.Unlock(270167);
    }

    public void MostrarTrofeos()
    {
        GameJoltUI.Instance.ShowTrophies();
        Trophies.Unlock(270170);
    }
    public void MostrarRankings()
    {
        GameJoltUI.Instance.ShowLeaderboards();
        Trophies.Unlock(270168);
    }
}
