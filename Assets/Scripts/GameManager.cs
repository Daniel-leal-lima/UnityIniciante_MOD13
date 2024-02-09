using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner spawner; 
    public static int lifes;
    public static int currentWave;
    private void Awake()
    {
        StartCoroutine(DelayHandler.DelayAction(6f, NextWave));
    }

    void NextWave()
    {
        if(currentWave!=0) spawner.EndWave();
        spawner.CanSpawn = true;
        currentWave++;
    }
}
