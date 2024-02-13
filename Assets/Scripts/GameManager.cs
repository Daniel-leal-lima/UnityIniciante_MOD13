using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    public static int lifes;
    public static int currentWave;
    public static int errorLimit = 3;
    [SerializeField] UIManager uiManager;
    private static int currErrors;
    public static float limitY = -8f;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        StartCoroutine(DelayHandler.DelayAction(6f, NextWave));
    }

    void NextWave()
    {
        if (currentWave != 0) spawner.EndWave();
        spawner.CanSpawn = true;
        currentWave++;
    }

    public void Error()
    {
        if (currErrors < errorLimit)
        {
            AudioManager.instance.PlayAudio("Miss");
            uiManager.AppearImage(currErrors);
            currErrors++;
            return;
        }
        StopAllCoroutines();
    }
}
