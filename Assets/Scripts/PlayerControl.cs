using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    protected Rigidbody2D rigid; // 리지드바디 이름 선언
    protected Vector2 movementDirection = Vector2.zero; // 방향값 선언 및 초기화
    public Vector2 MovementDirection { get { return movementDirection; } }
    void Start()
    {
       rigid = GetComponent<Rigidbody2D>(); // 리지드 바디 가져와서 쓸게요
    }

    // Update is called once per frame
    void Update() // 유니티 내에 있는 InputManager의 "Horizontal"과 "vertical"키 값 사용
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Movement(moveInput.normalized); //방향을 정규화시켜준다
    }
    private void Movement(Vector2 direction)
    { // 방향에 따른 값의 5를 곱하여 리지드 바디 만큼의 velocity를 속도로 설정함

        direction = direction * 5;

        rigid.velocity = direction;
    }
}

