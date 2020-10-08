using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameButton : MonoBehaviour {
  bool soundOn;
  void Awake() {
    soundOn = FindObjectOfType<Music>()._audioSource.isPlaying ? true : false;
  }
  // Start is called before the first frame update
  public void OnClick() {
    if (soundOn) {
      FindObjectOfType<Music>().StopMusic();
      soundOn = false;
    } else {
      FindObjectOfType<Music>().PlayMusic();
      soundOn = true;
    }
  }

  // Update is called once per frame

}
