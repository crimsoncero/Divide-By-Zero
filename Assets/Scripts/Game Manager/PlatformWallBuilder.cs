using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformWallBuilder : MonoBehaviour
{
    [SerializeField] GameObject[] WallPrefabs;

    [Range(1,20)]
    [SerializeField] int WallBuffer;
    [SerializeField] Transform PlatformBase;

    private void Awake()
    {
        GenerateObstacles();
    }

    private void GenerateObstacles()
    {
        float edgePos = (PlatformBase.lossyScale.x / 2) - 0.5f;

        //Starting position of the first wall.
        float xPos = -edgePos;

        //Create walls randomly until there is no more buffer space.
        while (xPos <= edgePos - WallBuffer + 1)
        {
            Vector3 pos = new Vector3(xPos, 1f, 0);
            pos = transform.position + pos;
            int index = GameManager.Instance.Random.Next(WallPrefabs.Length);

            // Create a wall element
            Instantiate(WallPrefabs[index], pos, Quaternion.identity, transform);

            xPos += WallBuffer;
        }

    }
}
