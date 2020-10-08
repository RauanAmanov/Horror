using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthKit : MonoBehaviour {
  public Text healthText;
  public void PickMe() {
    Destroy(gameObject);
    healthText.text = "100";
  }
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }
}
