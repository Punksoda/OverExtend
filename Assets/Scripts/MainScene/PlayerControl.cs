using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    protected Rigidbody2D rigid; // 리지드바디 이름 선언
    protected AnimationHandler anim; // 애니메이터 핸들러 선언
    protected Vector2 movementDirection = Vector2.zero; // 방향값 선언 및 초기화
    public Vector2 MovementDirection { get { return movementDirection; } }
    public Vector2 lookDir = Vector2.right; // 초기 방향을 오른쪽으로 설정



    void Start()
    {
       rigid = GetComponent<Rigidbody2D>(); // 리지드 바디 가져와서 쓸게요
        anim = GetComponent<AnimationHandler>(); // 애니메이터 가져와서 쓸게요

        if (anim == null)
        {
            Debug.LogWarning("AnimationHandler가 이 오브젝트에 할당되지 않았습니다. 애니메이터를 추가해주세요.");
        }
    }
    private void Movement(Vector2 direction)
    { // 방향에 따른 값의 5를 곱하여 리지드 바디 만큼의 velocity를 속도로 설정함

        direction = direction * 5;

        rigid.velocity = direction;
        anim.Move(movementDirection);
        if (direction != Vector2.zero)
        {
            lookDir = direction;
            UpdateSpriteDirection(); // 스프라이트 방향 변경
        }
    }

    // Update is called once per frame
    void Update() // 유니티 내에 있는 InputManager의 "Horizontal"과 "vertical"키 값 사용
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection = moveInput.normalized;// 방향을 정규화시켜준다
        if (anim != null) //움직여!
        {
            Movement(movementDirection);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트 태그가 "NPC"일 경우 
        if (other.CompareTag("NPC"))
        {
            // 미니게임 씬으로 변경
            SceneManager.LoadScene("MiniGame");
        }

        if(other.CompareTag("BOMB")) // 충돌한 오브젝트 태그가 "BOMB"일 경우
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 에디터에서도 종료할수 있게 변경
#else
        Application.Quit(); // 어플리케이션 종료
#endif
        }
    }

    private void UpdateSpriteDirection()
    {
        if (lookDir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 오른쪽 방향
        }
        else if (lookDir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 방향 (좌우 반전)
        }
    }

}

