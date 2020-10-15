using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  private float speed = 10;
  private Vector3 direction;
  private SpriteRenderer sprite;

  public GameObject parent;
  public GameObject Parent {
    get { return parent; }
    set { parent = value; }
  }
  public Vector3 Direction {
    set { direction = value; }
  }
  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.tag == "Enemy")
      collision.GetComponent<Enemy>().TakeDamage(25);
  }
  void Start() {
    sprite = GetComponent<SpriteRenderer>();
    Destroy(gameObject, 1.5f);
  }

  void Update() {
    transform.position = Vector3.MoveTowards(transform.position,
      transform.position + direction,
      speed * Time.deltaTime);
  }
}
