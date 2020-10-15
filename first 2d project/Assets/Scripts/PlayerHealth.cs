using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
  public float health = 100;
  public Image healthBar;
  void Start() {

  }
  public void TakeDamage(float damage) {
    health -= damage;
    healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - 0.1f,
      healthBar.transform.localScale.y,
      healthBar.transform.localScale.z);
    if (health <= 0)
      Application.LoadLevel(Application.loadedLevel);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.E))
      TakeDamage(10);
  }
}
