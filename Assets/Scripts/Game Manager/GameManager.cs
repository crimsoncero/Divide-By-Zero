using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public System.Random Random;

    public AudioSource BGM;


    public int Score { get; set; }
    [SerializeField] private PlayerController PlayerController;
    [SerializeField] private UIManager UIManager;
    [SerializeField] private GameObject GamePauseScreen;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private int ScorePerWall;
    [SerializeField] private int ScorePerDestructible;

    [Header("Platform Generation")]
    [SerializeField] private GameObject FirstPlatform;
    [SerializeField] private GameObject PlatformPrefab;


    private Queue<GameObject> PlatformQueue = new Queue<GameObject>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        Random = new System.Random(DateTime.Now.GetHashCode());
        Score = 0;
        PlatformQueue.Enqueue(FirstPlatform);
    }


    internal void NextPlatform(Vector3 pos)
    {

        GameObject newPlatform = Instantiate(PlatformPrefab,pos,Quaternion.identity);
        PlatformQueue.Enqueue(newPlatform);
        DeletePlatform();
    }


    internal void GamePause(bool state)
    {
        PlayerController.Pause(state);
        GamePauseScreen.SetActive(state);
        UIManager.UIOpenSFX.Play();
    }

    internal void GameOver()
    {
        BGM.Stop();
        GameOverScreen.SetActive(true);
        UIManager.UIOpenSFX.Play();
    }

    internal void AddWallScore()
    {
        Score += ScorePerWall;
    }

    internal void AddDestructibleScore()
    {
        Score += ScorePerDestructible;
    }

    private void DeletePlatform()
    {
        if(PlatformQueue.Count > 2)
        {
            Destroy(PlatformQueue.Dequeue());
        }
    }

    
    

}
