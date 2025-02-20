using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        // canvas�� ���̷���Ű â���� �ڵ� �����Ǵ� evevntSystemdmf �����ϰ� UI�� ���� ������ ȭ ���׽��ϴ�
        // ���� canvas�� �����ؼ� eventSystem�� �������� �ߴµ�, �̹� Home UI�� �� ������ ���� �ʽ��ϴ�;;
        this.uiManager = uiManager;
    }
}

