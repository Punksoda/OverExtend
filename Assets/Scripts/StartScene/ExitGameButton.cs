using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameButton : MonoBehaviour
{
   
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ����� �����Ҽ� �ְ� ����
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

   
    void Update()
    {
        
    }
}
