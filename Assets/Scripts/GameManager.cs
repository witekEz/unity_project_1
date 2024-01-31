using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform startPosition;
    public void Awake()
    {
        Instantiate(ballPrefab, startPosition.position, Quaternion.identity);
    }
}
