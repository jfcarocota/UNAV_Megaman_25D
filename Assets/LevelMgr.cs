using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
