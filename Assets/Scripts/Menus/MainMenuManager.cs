using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] AudioSource ButtonPress;



    public void StartGame()
    {
        ButtonPress.Play();
        SceneManager.LoadScene(1);
    }



}
