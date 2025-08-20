using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    private int score = 0;
    private int best = 0;



    public Button newGameBtn;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;
    private static GameManeger instance;

    public static GameManeger Instance => instance;
    public TileBoard board;

    public CanvasGroup gameOver;

    public void SetScore(int addScroe)
    {
        instance.score += addScroe;
        scoreText.text = instance.score.ToString();
    }

    public int GetScore()
    {
        return instance.score;
    }

    public void SetBest(int MaxScroe)
    {
        instance.score = MaxScroe;
        bestText.text = MaxScroe.ToString();
    }
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        newGameBtn.onClick.AddListener(() =>
        {
            NewGame();
        });
        NewGame();
    }

    public void NewGame()
    {
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;

        if (best < score)
        {
            Instance.SetBest(Instance.GetScore());
        }
        score = 0;
        scoreText.text = instance.score.ToString();
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1, 1));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
