using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_lyd : MonoBehaviour
{
    public Dialogue_lyd info;
    public bool isClick = false;
    public void Trigger()
    {
        var system = FindObjectOfType<DioalogSystem_LYD>();
        system.Begin(info);
        isClick = true;
    }
}
