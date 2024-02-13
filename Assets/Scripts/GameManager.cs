using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    public int secondsToStart;
    public static int currentWave;
    public static int errorLimit = 3;
    [SerializeField] UIManager uiManager;
    private static int currErrors;
    public static float limitY = -8f;
    public static bool GameFinished
    {
        get { return gameFinished; }
        set { gameFinished = value;
            if (value) 
                uimanagerStatic.EndScreen(currErrors.Equals(errorLimit));
        }
    }
    private static bool gameFinished;
    private static UIManager uimanagerStatic;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        uimanagerStatic = uiManager;
        IEnumerator counter = uiManager.TextCounter(() =>
        {
            NextWave();
        });
        StartCoroutine(counter);
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
            AudioManager.instance.PlayAudio(AudioManager.IDMISS);
            uiManager.AppearImage(currErrors);
            currErrors++;
            return;
        }
        spawner.CanSpawn = false;
        StopAllCoroutines();
        GameFinished = true;
    }

    private void OnDisable()
    {
        gameFinished = false;
        currErrors = 0;
        uimanagerStatic = null;
    }
}
