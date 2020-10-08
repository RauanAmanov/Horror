using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
  GameObject player;
  Vector3 offset;
  void Start() {
    player = GameObject.FindGameObjectWithTag("Player");
    offset = new Vector3(0, 1.5f, -4);
  }

  void Update() {
    transform.position = player.transform.position + offset;
  }
}
