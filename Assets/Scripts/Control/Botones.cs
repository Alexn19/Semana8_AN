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
        Trophies.Unlock(269518);
    }

    public void EmpezarPartida()
    {
        SceneManager.LoadScene("Partida");
        Trophies.Unlock(269517);
    }

    public void MostrarTrofeos()
    {
        GameJoltUI.Instance.ShowTrophies();
    }
    public void MostrarRankings()
    {
        GameJoltUI.Instance.ShowLeaderboards();
        Trophies.Unlock(269521);
    }
}
