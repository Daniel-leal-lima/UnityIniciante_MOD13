using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenu : MonoBehaviour
{
    [SerializeField] Button button;

    private void Awake()
    {
        button.onClick.AddListener(OnButtonGotoMenuClick);
    }
    private void OnButtonGotoMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
