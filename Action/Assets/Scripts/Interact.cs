using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interact : MonoBehaviour {
  // Start is called before the first frame update
  public LayerMask interactLayer;
  public float interactDistance;
  public Image interactIcon;
  void Start() {
    if (interactIcon != null)
      interactIcon.enabled = false;
  }

  // Update is called once per frame
  void Update() {
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, interactDistance, interactLayer)) {
      if (interactIcon != null)
        interactIcon.enabled = true;
      if (Input.GetKeyDown(KeyCode.E)) {
        if (hit.collider.tag == "Key") {
          hit.collider.GetComponent<Key>().DestroyMe();
        }
        if (hit.collider.tag == "Cube") {
          hit.collider.GetComponent<Cube>().RecolorMe();
        }
        if (hit.collider.tag == "HealthKit") {
          hit.collider.GetComponent<HealthKit>().PickMe();
        }
      }
    } else {
      if (interactIcon != null)
        interactIcon.enabled = false;
    }
  }
}
