using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Linq;
using System;

public class Enemy : MonoBehaviour {
  float health = 100;
  bool enemyInSight;
  public Text text;
  Animator anim;
  NavMeshAgent navigation;
  void Start() {
    navigation = GetComponent<NavMeshAgent>();
    anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update() {
    if (!enemyInSight) Patrol();
    else {
      Follow();
    }
  }
  void Patrol() {
    anim.SetBool("Walking", true);
    navigation.destination = transform.position + new Vector3(0, 0, 20);
  }
  void Follow() {

  }
  public void TakeDamage() {
    if (health > 0) health -= 10;
    else {
      text.text = (Convert.ToInt32(text.text) + 1).ToString();
      if (Convert.ToInt32(text.text) >= 10)
        Application.LoadLevel(Application.loadedLevel);
      Destroy(gameObject);
    }
  }
}
