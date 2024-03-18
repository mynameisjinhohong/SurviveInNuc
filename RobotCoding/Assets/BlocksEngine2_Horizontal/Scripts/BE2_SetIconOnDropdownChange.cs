using System.Collections;
using System.Collections.Generic;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Horizontal.Block
{
    public class BE2_SetIconOnDropdownChange : MonoBehaviour
    {
        public Image image;
        public BE2_Dropdown dropdown;
        public Sprite spriteLeft;
        public Sprite spriteRight;

        void OnEnable()
        {
            dropdown = BE2_Dropdown.GetBE2ComponentInChildren(transform);
            dropdown.onValueChanged.AddListener(delegate
            {
                SetIcon();
            });
        }

        void OnDisable()
        {
            dropdown.onValueChanged.RemoveAllListeners();
        }

        void SetIcon()
        {
            string value = dropdown.GetSelectedOptionText();
            if (value == "Left")
            {
                image.sprite = spriteLeft;
            }
            else if (value == "Right")
            {
                image.sprite = spriteRight;
            }
        }

        //void Start()
        //{
        //
        //}
        //
        //void Update()
        //{
        //
        //}
    }
}
