using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image[] img;
    [SerializeField] TextMeshProUGUI textCounter;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject canvasRetry;
    [SerializeField] GameObject CanvasVictory;

    public void AppearImage(int index)
    {
        Color col = Color.white;
        col.a = 1f;
        img[index].color = col;
    }

    public IEnumerator TextCounter(System.Action callback)
    {
        yield return new WaitForSeconds(1f);
        textCounter.text = gameManager.secondsToStart.ToString();
        while (gameManager.secondsToStart > 0)
        {
            yield return new WaitForSeconds(1);
            gameManager.secondsToStart--;
            textCounter.text = gameManager.secondsToStart.ToString();
            yield return null;
        }
        textCounter.text = "GO!";
        yield return new WaitForSeconds(.3f);
        textCounter.enabled = false;
        callback?.Invoke();

    }
    
    public void EndScreen(bool flag)
    {
        if (flag) Retry();
        else Victory();
    }
    private void Retry()
    {
        canvasRetry.SetActive(true);
    }
    private void Victory()
    {
        CanvasVictory.SetActive(true);
    }
}
