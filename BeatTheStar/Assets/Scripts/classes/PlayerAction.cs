using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour, IPlayable
{
    public float moveSpeed;
    public float jumpPower;

    private Rigidbody2D playerRigid;
    public float h { get; private set; }
    public bool hDown { get; private set; }
    public bool hStay { get; private set; }
    // private float v;
    public bool isJump { get; private set; }
    public Vector3 dirVec { get; private set; }

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        isJump = false;
    }

    // Update is called once per frame
    private void Update()
    {
        // UpdateValue();
        Jump(); // 단발적인 입력에 한에서는 Update에 써라!!!
        SelectDirVec(); // Object를 scan하기 위한 Ray 방향 결정
    }

    private void FixedUpdate()
    {
        Move();
        Land();
    }

    public void UpdateValue(bool isAction)
    {
        h = isAction ? 0 : Input.GetAxisRaw("Horizontal");
        hDown = isAction ? false : Input.GetButtonDown("Horizontal");
        hStay = isAction ? false : Input.GetButton("Horizontal");
    }

    public void Move()
    {
        Vector2 velocity = (Vector2.right * h) * moveSpeed;
        velocity.y = playerRigid.velocity.y; // 중요!!! 이 코드가 없을 시 jump 후 player의 내려오는 속도가 느려짐.
        playerRigid.velocity = velocity;
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Fire2") && !isJump)
        {
            playerRigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    public void Land()
    {
        if (playerRigid.velocity.y < 0)
        {
            Debug.DrawRay(playerRigid.position, Vector3.down, Color.green);
            RaycastHit2D rayHit = Physics2D.Raycast(playerRigid.position, Vector3.down,
                1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 2.0f)
                    isJump = false;
            }
        }
    }

    void SelectDirVec()
    {
        if (h == -1)
            dirVec = Vector3.left;
        else if (h == 1)
            dirVec = Vector3.right;
    }

    /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isJump = false;
            Debug.Log(isJump);
        }
    } */
}
