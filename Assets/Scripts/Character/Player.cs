using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Player : MonoBehaviour
{
    // Z座標が変わったことを通知するイベント
    public static event Action<float> OnPlayerZChanged;

    [SerializeField] private float layerDistance = 1.0f; // 層と層の間の距離
    [SerializeField] private float moveSpeed = 5.0f; // 左右移動速度
    [SerializeField] private float jumpForce = 5.0f; // ジャンプ力
    [SerializeField] private int MultipleJump = 1; // 空中でジャンプできる回数(0なら空中ジャンプ不可)
    public float playerbrightness = 1.0f;
    private InputAction frontlayer;
    private InputAction backlayer;
    private InputAction moveRight;
    private InputAction moveLeft;
    private InputAction jump;
    private Rigidbody2D rb;
    private Collider2D col;
    private int jumpsUsed = 0; // 着地してから消費したジャンプ回数

    private void Start()
    {
        // ゲーム開始時に初期位置の判定を通知して色を反映させる
        OnPlayerZChanged?.Invoke(transform.position.z);
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // タイルマップの継ぎ目(隣接するタイルのコライダーの境目)に
        // 摩擦で引っかかって止まってしまう問題を防ぐため、摩擦0のマテリアルを適用する
        PhysicsMaterial2D noFriction = new PhysicsMaterial2D("PlayerNoFriction")
        {
            friction = 0f,
            bounciness = 0f
        };
        if (col != null)
        {
            col.sharedMaterial = noFriction;
        }

        // 高速移動時に薄いコライダーをすり抜けたり、継ぎ目で微妙な位置ずれが起きるのを防ぐ
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        frontlayer = InputSystem.actions.FindAction("FrontLayer");
        backlayer = InputSystem.actions.FindAction("BackLayer");
        frontlayer.started += context => MoveLayer(layerDistance);
        backlayer.started += context => MoveLayer(-layerDistance);

        moveRight = InputSystem.actions.FindAction("MoveRight");
        moveLeft = InputSystem.actions.FindAction("MoveLeft");
        jump = InputSystem.actions.FindAction("Jump");
        jump.started += context => Jump();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        // MoveRight/MoveLeftを押している間、左右に移動する
        float moveInput = 0f;
        if (moveRight.IsPressed())
        {
            moveInput += 1f;
        }
        if (moveLeft.IsPressed())
        {
            moveInput -= 1f;
        }
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        // 着地ジャンプ+空中ジャンプ(MultipleJump回)までジャンプ可能
        if (jumpsUsed > MultipleJump)
        {
            return;
        }

        // 真上に力を加える
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpsUsed++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 足元(下向き)で接触した場合のみ着地とみなし、ジャンプ回数をリセットする
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                jumpsUsed = 0;
                break;
            }
        }
    }


    private void MoveLayer(float zOffset)
    {
        Vector3 newPos = this.gameObject.transform.position;
        newPos.z += zOffset;
        this.gameObject.transform.position = newPos;

        // Z座標が変わったとき、登録されているすべての層に新しいZ座標を通知
        OnPlayerZChanged?.Invoke(transform.position.z);
    }
}
