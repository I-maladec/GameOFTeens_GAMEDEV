using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DopomogaDisplay : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public void UpdateDopomoga(int score) => scoreText.text = $"{score}";
}