using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JeuEspaceV1 : MonoBehaviour
{
    public int etoiles = 0;

    void Start()
    {
         DontDestroyOnLoad(gameObject);
    }

    public void ChangerScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void CollecterEtoile(GameObject etoile)
    {
        Destroy(etoile);
        etoiles++;
    }
   
}
