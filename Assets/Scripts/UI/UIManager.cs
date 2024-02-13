using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image[] img;
    public void AppearImage(int index)
    {
        Color col = Color.white;
        col.a = 1f;
        img[index].color = col;
    }
}
