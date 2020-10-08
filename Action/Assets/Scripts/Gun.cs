using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
  public float damage = 10;
  public float range = 100;
  public Camera fpsCam;
  public Text bulletText;
  public Text reloadMessage;
  public ParticleSystem shootEffect;
  public GameObject bulletEffect;
  public GameObject holeEffect;
  public float impactForce = 200;
  // Start is called before the first frame update
  void Start() {
    reloadMessage.enabled = false;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      Shoot();
    }
    if (Input.GetKeyDown(KeyCode.R)) {
      reloadMessage.enabled = false;
      bulletText.text = "30";
    }
  }
  public void Shoot() {
    if (Convert.ToInt32(bulletText.text) > 0) {
      bulletText.text = (Convert.ToInt32(bulletText.text) - 1).ToString();
      shootEffect.Play();
      RaycastHit hit;
      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
        GameObject effect;
        Rigidbody rigidbody = hit.collider.GetComponent<Rigidbody>();
        if (hit.collider.tag == "Wall")
          effect = Instantiate(holeEffect, hit.point, Quaternion.LookRotation(hit.normal));
        if (hit.collider.tag == "Obstacle") {
          effect = Instantiate(bulletEffect, hit.point, Quaternion.LookRotation(hit.normal));
          Destroy(effect, 1);
          if (hit.rigidbody != null)
            hit.rigidbody.AddForce(-hit.normal * impactForce);
          Target target = hit.collider.GetComponent<Target>();
          Debug.Log(hit.collider.name);
          if (target != null)
            target.TakeDamage(damage);
        }
        if (hit.collider.tag == "Enemy") {
          Enemy enemy = hit.collider.GetComponent<Enemy>();
          Debug.Log("Enemy hit");
          enemy.TakeDamage();
        }
      }
    } else {
      reloadMessage.enabled = true;
    }

  }
}
