using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
  public int score = 0;
  public Text scoreText;

  public void AddScore() {
    score += 1;
    scoreText.text = score.ToString();
  }
  public void AddScoreDiamond() {
    score += 10;
    scoreText.text = score.ToString();
  }
  void Start() {

  }

  void Update() {

  }
}
