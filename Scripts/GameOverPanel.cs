using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    private static GameOverPanel instance;
    public static GameOverPanel Instance => instance;

    public Button tryBtn;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        tryBtn.onClick.AddListener(() =>
        {
            GameManeger.Instance.NewGame();
        });
    }
}
