using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button buttonStart;
    [SerializeField] private Button buttonQuit;

    private void Awake()
    {
        buttonStart.onClick.AddListener(OnButtonStartClick);
        buttonQuit.onClick.AddListener(OnButtonQuitClick);
    }

    private void OnButtonStartClick()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnButtonQuitClick()
    {
        Application.Quit();
    }
}
