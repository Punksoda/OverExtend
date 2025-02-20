using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameButton : MonoBehaviour
{
   
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서도 종료할수 있게 변경
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

   
    void Update()
    {
        
    }
}
