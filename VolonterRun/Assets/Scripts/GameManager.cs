using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;
    public ScoreDisplay scoreDisplay;
    public HealDisplay healDisplay;
    public DopomogaDisplay dopomogaDisplay;
    
    public int score;
    public bool isGameOver;
    public bool isPaused;
    public int hp;
    public int dopomoga;

    private void Start()
    {
        Instance = this;
        score = 0;
        isGameOver = false;
        isPaused = false;
        hp = 3;
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        healDisplay = FindObjectOfType<HealDisplay>();
        dopomogaDisplay = FindObjectOfType<DopomogaDisplay>();
        healDisplay.SetHearts(hp);
        dopomogaDisplay.UpdateDopomoga(dopomoga);
        StartCoroutine(UpdateScore());
    }

    private void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
    }

    public void TakeDamage()
    {
        hp--;
        healDisplay.SetHearts(hp);
        if (hp <= 0) GameOver();
    }

    private IEnumerator UpdateScore()
    {
        while (!isGameOver)
        {
            score++;
            scoreDisplay.UpdateScore(score);
            yield return new WaitForSeconds(1f);
        }
    }


    public void DopomogaCollected()
    {
        dopomoga++;
        dopomogaDisplay.UpdateDopomoga(dopomoga);
    }

    public void ZsuHit()
    {
        score += 100*dopomoga;
        scoreDisplay.UpdateScore(score);
        dopomoga = 0;
        dopomogaDisplay.UpdateDopomoga(dopomoga);
        if(hp < 3) hp++;
        healDisplay.SetHearts(hp);
    }
}