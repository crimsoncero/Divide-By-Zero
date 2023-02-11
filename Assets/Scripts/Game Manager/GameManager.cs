using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public System.Random Random;

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

        PlatformQueue.Enqueue(FirstPlatform);
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
