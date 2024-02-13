using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    [SerializeField] Button resetButton;
    void Awake()
    {
        resetButton.onClick.AddListener(OnButtonResetClick);
    }

    private void OnButtonResetClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
