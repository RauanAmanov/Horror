using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiamondPickup : MonoBehaviour {
  // Start is called before the first frame update
  public void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      FindObjectOfType<GameManager>().AddScoreDiamond();
      Destroy(gameObject);
    }
  }
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }
}
