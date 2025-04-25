using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class JeuEspaceV2 : MonoBehaviour
{

    public int etoiles = 0;
    private int etoilesDebutNiveau;
    public TextMeshProUGUI textEtoiles;

    public AudioSource sonPortail;
    
    public GameObject fxExplosion;

    // Variable pour garder une r�f�rence � la copie global
    public static JeuEspaceV2 instance;

    // Avant de faire Start d'une nouvelle instance de notre script
    void Awake()
    {
        // Si on n'a pas encore une copie global pr�te
        if(instance == null)
        {
            // On va cr�er notre instance singleton
            // Garder la copie actuel comme global
            instance = this;
            // Marquer ce objet comme persistant
            DontDestroyOnLoad(gameObject);
        }
        // Si on a deja un singleton pret
        else
        {
            // On va detruire cette nouvelle copie extra
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        // Garder la valeur initiale des etoiles au debut du niveau
        etoilesDebutNiveau = etoiles;
        textEtoiles.text = etoiles.ToString("0");
    }

    public void ChangerScene(int indexScene)
    {
        sonPortail.Play();
        SceneManager.LoadScene(indexScene);
        // Apres que la nouvelle scene est charge,
        // on garde la valeur de etoiles au debut
        etoilesDebutNiveau = etoiles;
    }

    public void CollecterEtoile()
    {
        // Sommer e la variable
        etoiles++;
        // Montrer e le Canvas
        textEtoiles.text = etoiles.ToString("0");
    }

    public void DetruireJoueur(GameObject joueur)
    {
        // Cr�er une copie du prefab d'explosion � la position du joueur
        Instantiate(fxExplosion, joueur.transform.position, joueur.transform.rotation);
        // Recommencer la sc�ne apr�s 3 s
        Invoke("RecommencerScene", 3f);
    }

    void RecommencerScene()
    {
        // Recharger la sc�ne actuel
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Retourner la valeur initiale des �toiles avant ce niveau
        etoiles = etoilesDebutNiveau;
        textEtoiles.text = etoiles.ToString("0");
    }
}
