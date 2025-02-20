using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        // canvas를 하이러라키 창에서 자동 생성되는 evevntSystemdmf 무시하고 UI를 따로 프리팹 화 시켰습니다
        // 따로 canvas를 생성해서 eventSystem을 만들었어야 했는데, 이미 Home UI에 들어가 생성이 되지 않습니다;;
        this.uiManager = uiManager;
    }
}

