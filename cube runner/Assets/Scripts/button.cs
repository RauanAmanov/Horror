using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
  // Start is called before the first frame update
  public bool _soundOn = true;
  private void Awake() {
  }
  public void OnButtonClick() {
    if (_soundOn) {
      FindObjectOfType<Music>().StopMusic();
      _soundOn = false;
    } else {
      FindObjectOfType<Music>().PlayMusic();
      _soundOn = true;
    }
  }

  // Update is called once per frame

}
