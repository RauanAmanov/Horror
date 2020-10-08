using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
  public Text text;
  public Text healthText;
  // Start is called before the first frame update
  void Start() {
    text.enabled = false;
  }

  // Update is called once per frame
  void Update() {

  }
  public void GameOver() {
    text.enabled = true;
    Application.LoadLevel(Application.loadedLevel);
  }
  public void TakeDamage(float amount) {
    if (Convert.ToInt32(healthText) > 0) {
      healthText.text = (Convert.ToInt32(healthText) - amount).ToString();
    } else {
      GameOver();
    }
  }
}
