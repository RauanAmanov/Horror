using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour {
  public float speed = 5;
  public float jumpForce = 8;

  public Rigidbody2D rigidbody;
  bool isGrounded = false;

  SpriteRenderer sprite;
  Animator anim;
  private PlayerState State {
    get {
      return (PlayerState)anim.GetInteger("state");
    }
    set {
      anim.SetInteger("state", (int)value);
    }
  }
  private Bullet bullet;

  void Start() {
    rigidbody = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sprite = GetComponentInChildren<SpriteRenderer>();

    bullet = Resources.Load<Bullet>("Bullet");
  }
  public void FixedUpdate() {
    CheckGround();
  }
  void Update() {
    if (isGrounded)
      State = PlayerState.Idle;
    if (Input.GetButton("Horizontal"))
      Run();
    if (isGrounded && Input.GetKeyDown(KeyCode.Space))
      Jump();
    if (Input.GetMouseButtonDown(0))
      Shoot();
  }
  public enum PlayerState {
    Idle, Run, Jump
  }
  void Run() {
    Vector3 direction = transform.right * Input.GetAxis("Horizontal");
    transform.position = Vector3.MoveTowards(transform.position,
      transform.position + direction,
      speed * Time.deltaTime);
    sprite.flipX = direction.x < 0;
    if (isGrounded)
      State = PlayerState.Run;
  }
  public void Jump() {
    rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
  }
  private void CheckGround() {
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
    isGrounded = colliders.Length > 1;
    if (!isGrounded)
      State = PlayerState.Jump;
  }
  private void Shoot() {
    Vector3 position = transform.position;
    position.y += 0.9f;
    Bullet newBullet = Instantiate(bullet, position,
      rotation: bullet.transform.rotation) as Bullet;
    newBullet.Parent = gameObject;
    newBullet.Direction = newBullet.transform.right *
      (sprite.flipX ? -1 : 1);
  }
}
