using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using System;
using UnityEditor.PackageManager;
namespace Legacy.LJH
{
    public class TouchManager : Singleton<TouchManager>
    {
        private Camera cam;
        private RaycastHit hitInfo;

        private int floorLayerMask;

        private void Awake()
        {
            cam = Camera.main;
            floorLayerMask = 1 << LayerMask.NameToLayer(LayerStrings.Floor);
            LeanTouch.OnFingerTap += OnMovePlayer;
        }

        private void OnMovePlayer(LeanFinger finger)
        {
            if (finger.IsOverGui) return;

            if (Physics.Raycast(cam.ScreenPointToRay(finger.ScreenPosition), out hitInfo, Mathf.Infinity, floorLayerMask))
            {
                GameManagerSample_LJH.Instance.Player.Move(hitInfo.point);
            }
        }

        private void OnDestroy()
        {
            LeanTouch.OnFingerTap -= OnMovePlayer;
        }
    }
}