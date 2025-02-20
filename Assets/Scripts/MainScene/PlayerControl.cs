using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    protected Rigidbody2D rigid; // ������ٵ� �̸� ����
    protected AnimationHandler anim; // �ִϸ����� �ڵ鷯 ����
    protected Vector2 movementDirection = Vector2.zero; // ���Ⱚ ���� �� �ʱ�ȭ
    public Vector2 MovementDirection { get { return movementDirection; } }
    public Vector2 lookDir = Vector2.right; // �ʱ� ������ ���������� ����



    void Start()
    {
       rigid = GetComponent<Rigidbody2D>(); // ������ �ٵ� �����ͼ� ���Կ�
        anim = GetComponent<AnimationHandler>(); // �ִϸ����� �����ͼ� ���Կ�

        if (anim == null)
        {
            Debug.LogWarning("AnimationHandler�� �� ������Ʈ�� �Ҵ���� �ʾҽ��ϴ�. �ִϸ����͸� �߰����ּ���.");
        }
    }
    private void Movement(Vector2 direction)
    { // ���⿡ ���� ���� 5�� ���Ͽ� ������ �ٵ� ��ŭ�� velocity�� �ӵ��� ������

        direction = direction * 5;

        rigid.velocity = direction;
        anim.Move(movementDirection);
        if (direction != Vector2.zero)
        {
            lookDir = direction;
            UpdateSpriteDirection(); // ��������Ʈ ���� ����
        }
    }

    // Update is called once per frame
    void Update() // ����Ƽ ���� �ִ� InputManager�� "Horizontal"�� "vertical"Ű �� ���
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementDirection = moveInput.normalized;// ������ ����ȭ�����ش�
        if (anim != null) //������!
        {
            Movement(movementDirection);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ������Ʈ �±װ� "NPC"�� ��� 
        if (other.CompareTag("NPC"))
        {
            // �̴ϰ��� ������ ����
            SceneManager.LoadScene("MiniGame");
        }

        if(other.CompareTag("BOMB")) // �浹�� ������Ʈ �±װ� "BOMB"�� ���
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ����� �����Ҽ� �ְ� ����
#else
        Application.Quit(); // ���ø����̼� ����
#endif
        }
    }

    private void UpdateSpriteDirection()
    {
        if (lookDir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // ������ ����
        }
        else if (lookDir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // ���� ���� (�¿� ����)
        }
    }

}

