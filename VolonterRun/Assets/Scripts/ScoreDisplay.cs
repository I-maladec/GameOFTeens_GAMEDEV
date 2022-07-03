using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public void UpdateScore(int score) => scoreText.text = $"Score: {score}";
}