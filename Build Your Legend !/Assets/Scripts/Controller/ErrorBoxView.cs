using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorBoxView : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasbg;
    private static ErrorBoxView instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        instance.canvas.SetActive(false);
    }
    public static void Show()
    {
        instance.canvas.SetActive(true);
        instance.canvasbg.SetActive(false);
    }
    public static void Hide()
    {
        instance.canvas.SetActive(false);
        instance.canvasbg.SetActive(true);
    }
}
