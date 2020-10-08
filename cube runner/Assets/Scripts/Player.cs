using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  Rigidbody rb;
  public int speedX = 5;
  public int speed = 10;
  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    rb.AddForce(0, 0, speed);
    if (Input.GetKey(KeyCode.A))
      rb.AddForce(-speedX, 0, 0);
    if (Input.GetKey(KeyCode.D))
      rb.AddForce(speedX, 0, 0);
  }
}
