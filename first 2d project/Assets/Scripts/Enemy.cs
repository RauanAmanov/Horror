using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  float health;
  Animator anim;

  void Start() {
    health = 100;
    anim = GetComponent<Animator>();
  }
  void Die() {
    Destroy(gameObject);
  }
  public void TakeDamage(float amount) {
    health -= amount;
    StartCoroutine(WaitForAnimation(1));
    if (health <= 0)
      Die();
  }

  private IEnumerator WaitForAnimation(float timer) {
    anim.SetBool("GotHit", true);
    yield return new WaitForSeconds(timer);
    anim.SetBool("GotHit", false);
    Debug.Log("Running");
    yield break;
  }
  // Update is called once per frame
  void Update() {

  }
}
