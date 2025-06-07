using System.Collections;
using System.Collections.Generic;
using GameJolt.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioGamejolt : MonoBehaviour
{
    void Start()
    {
        GameJoltUI.Instance.ShowSignIn((success) =>
        {
            if (success)
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                Debug.Log("Error");
            }
        });
    }
}
