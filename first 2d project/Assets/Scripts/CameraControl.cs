using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
  public float speed = 3;
  public Transform player;
  void Start() {
    if (!player)
      player = FindObjectOfType<Player>().transform;
  }

  // Update is called once per frame
  void Update() {
    Vector3 position = player.position;
    position.z = -9;
    transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
  }
}
