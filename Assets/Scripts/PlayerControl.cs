using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    protected Rigidbody2D rigid; // ������ٵ� �̸� ����
    protected Vector2 movementDirection = Vector2.zero; // ���Ⱚ ���� �� �ʱ�ȭ
    public Vector2 MovementDirection { get { return movementDirection; } }
    void Start()
    {
       rigid = GetComponent<Rigidbody2D>(); // ������ �ٵ� �����ͼ� ���Կ�
    }

    // Update is called once per frame
    void Update() // ����Ƽ ���� �ִ� InputManager�� "Horizontal"�� "vertical"Ű �� ���
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Movement(moveInput.normalized); //������ ����ȭ�����ش�
    }
    private void Movement(Vector2 direction)
    { // ���⿡ ���� ���� 5�� ���Ͽ� ������ �ٵ� ��ŭ�� velocity�� �ӵ��� ������

        direction = direction * 5;

        rigid.velocity = direction;
    }
}

