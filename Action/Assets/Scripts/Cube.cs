using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
  public void RecolorMe() {
    MeshRenderer mr = GetComponent<MeshRenderer>();
    mr.material.color = Color.black;
  }
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }
}
