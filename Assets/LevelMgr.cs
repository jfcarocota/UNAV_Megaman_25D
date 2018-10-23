using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{
    public void CargaNivel(string pNombreNivel)
    {
        SceneManager.LoadScene (pNombreNivel);
    }

    public void Exit()
    {
        Application.Quit();

        //Debug.Log("Salir");
    }
}
