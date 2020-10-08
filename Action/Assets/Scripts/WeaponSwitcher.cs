using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour {
  public int selectedWeapon = 0;
  public Image[] originalIcons;
  public List<Color> originalColors;
  // Start is called before the first frame update
  void Start() {
    originalColors = originalIcons.Select(i => i.color).ToList();
    SelectWeapon();
  }

  // Update is called once per frame
  void Update() {
    int prevWeapon = selectedWeapon;
    if (Input.GetAxis("Mouse ScrollWheel") > 0) {
      if (selectedWeapon >= transform.childCount - 1) {
        selectedWeapon = 0;
      } else {
        selectedWeapon++;
      }
    }
    if (Input.GetAxis("Mouse ScrollWheel") < 0) {
      if (selectedWeapon <= 0) {
        selectedWeapon = transform.childCount - 1;
      } else {
        selectedWeapon--;
      }
    }
    if (prevWeapon != selectedWeapon)
      SelectWeapon();
  }
  public void SelectWeapon() {
    for (int i = 0; i < transform.childCount; ++i) {
      if (i == selectedWeapon) {
        transform.GetChild(i).gameObject.SetActive(true);
        originalIcons[i].color = Color.yellow;
      } else {
        transform.GetChild(i).gameObject.SetActive(false);
        originalIcons[i].color = originalColors[i];
      }
    }
  }
}
