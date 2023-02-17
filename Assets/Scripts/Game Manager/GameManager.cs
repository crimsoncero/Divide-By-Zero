using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public System.Random Random;


    public int Score { get { return (int)Math.Ceiling(_scoreFloat); } }

    [Header("Platform Generation")]
    [SerializeField] private GameObject FirstPlatform;
    [SerializeField] private GameObject PlatformPrefab;

    private Queue<GameObject> PlatformQueue = new Queue<GameObject>();
    private float _scoreFloat;

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
        _scoreFloat = 0;
        PlatformQueue.Enqueue(FirstPlatform);
    }

    private void Update()
    {
        _scoreFloat += Time.deltaTime;
    }
    internal void NextPlatform(Vector3 pos)
    {

        GameObject newPlatform = Instantiate(PlatformPrefab,pos,Quaternion.identity);
        PlatformQueue.Enqueue(newPlatform);
        DeletePlatform();
    }

    private void DeletePlatform()
    {
        if(PlatformQueue.Count > 2)
        {
            Destroy(PlatformQueue.Dequeue());
        }
    }

    

}
