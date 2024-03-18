﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

using MG_BlocksEngine2.Utils;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Block;

namespace MG_BlocksEngine2.Horizontal.Block
{
    [ExecuteInEditMode]
    public class BE2_HorizontalBlockSectionHeader : MonoBehaviour, I_BE2_BlockSectionHeader
    {
        RectTransform _rectTransform;
        public RectTransform RectTransform => _rectTransform;
        I_BE2_BlockSection _section;
        I_BE2_BlockLayout _blockLayout;
        Image _image;
        public float minHeight;
        public float minWidth = 110;
        public Vector2 Size
        {
            get
            {
                if (_rectTransform == null)
                    _rectTransform = GetComponent<RectTransform>();

                return _rectTransform.sizeDelta;
            }
            set
            {
                _rectTransform.sizeDelta = value;
            }
        }
        I_BE2_BlockSectionHeaderItem[] _itemsArray;
        public I_BE2_BlockSectionHeaderItem[] ItemsArray => _itemsArray;
        I_BE2_BlockSectionHeaderInput[] _inputsArray;
        public I_BE2_BlockSectionHeaderInput[] InputsArray => _inputsArray;
        Shadow _shadow;
        public Shadow Shadow
        {
            get
            {
                if (!_shadow)
                {
                    if (GetComponent<Shadow>())
                        _shadow = GetComponent<Shadow>();
                    else
                        _shadow = gameObject.AddComponent<Shadow>();

                    _shadow.effectColor = Color.green;
                    _shadow.effectDistance = new Vector2(-6, -6);
                }

                return _shadow;
            }
        }

        void OnValidate()
        {
            Awake();
        }

        void Awake()
        {
            UpdateItemsArray();
            UpdateInputsArray();

            _rectTransform = GetComponent<RectTransform>();

            if (transform.parent)
            {
                _section = transform.parent.GetComponent<I_BE2_BlockSection>();
                _blockLayout = transform.parent.parent.GetComponent<I_BE2_BlockLayout>();
            }

            _image = GetComponent<Image>();
            _image.type = Image.Type.Sliced;
            _image.pixelsPerUnitMultiplier = 2;

            if (_section != null && _section.Block != null && (_section.Block.Type == BlockTypeEnum.condition || _section.Block.Type == BlockTypeEnum.loop))
            {
                VerticalLayoutGroup vlg = GetComponent<VerticalLayoutGroup>();
                if (_itemsArray.Length > 1)
                {
                    vlg.padding = new RectOffset(-10, 0, 0, -25);
                    vlg.spacing = 10;
                    vlg.childAlignment = TextAnchor.LowerCenter;
                }
                else
                {
                    vlg.padding = new RectOffset(0, 0, 0, 0);
                    vlg.spacing = 0;
                    vlg.childAlignment = TextAnchor.MiddleCenter;
                }
            }
        }

        // v2.12 - bugfix: header not updating size after it is disabled and reenabled
        void OnEnable()
        {
            BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnDrag, UpdateItemsArray);
            BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateItemsArray);
            BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateInputsArray);
        }

        void OnDisable()
        {
            BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnDrag, UpdateItemsArray);
            BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateItemsArray);
            BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateInputsArray);
        }

        //void Update()
        //{
        //    
        //}

        public void UpdateItemsArray()
        {
            _itemsArray = new I_BE2_BlockSectionHeaderItem[0];
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                I_BE2_BlockSectionHeaderItem item = transform.GetChild(i).GetComponent<I_BE2_BlockSectionHeaderItem>();
                if (item != null && item.Transform.gameObject.activeSelf)
                {
                    BE2_ArrayUtils.Add(ref _itemsArray, item);
                }
            }
        }

        public void UpdateInputsArray()
        {
            _inputsArray = new I_BE2_BlockSectionHeaderInput[0];
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                I_BE2_BlockSectionHeaderInput input = transform.GetChild(i).GetComponent<I_BE2_BlockSectionHeaderInput>();
                if (input != null && input.Transform.gameObject.activeSelf)
                {
                    BE2_ArrayUtils.Add(ref _inputsArray, input);
                }
            }
        }

        public void UpdateLayout()
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
                UpdateItemsArray();
                //UpdateInputsList();
            }
#endif

            if (_blockLayout != null)
                _image.color = _blockLayout.Color;

            if (_section.RectTransform.transform.GetSiblingIndex() == 0)
            {
                float height = minHeight;

                if (_section.Block != null)
                    if (_section.Block.Type != BlockTypeEnum.trigger && _section.Body != null)
                    {
                        if (_section.Body.Size.y > minHeight)
                            height = _section.Body.Size.y;
                    }

                _rectTransform.sizeDelta = new Vector2(minWidth, height);
            }
            else
            {
                float height = minHeight;

                if (_section.Block.Type != BlockTypeEnum.trigger && _section.Body != null)
                {
                    if (_section.Body.Size.y > minHeight)
                        height = _section.Body.Size.y;
                }
                _rectTransform.sizeDelta = new Vector2(50, height);
            }
        }
    }
}