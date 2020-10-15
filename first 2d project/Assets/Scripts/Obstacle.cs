using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Player") {
      other.GetComponent<PlayerHealth>().TakeDamage(10);
      Destroy(gameObject);
    }
  }
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }
}
