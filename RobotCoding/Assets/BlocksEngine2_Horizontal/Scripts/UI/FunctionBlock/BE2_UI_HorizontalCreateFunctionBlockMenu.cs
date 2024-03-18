using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using MG_BlocksEngine2.Block;
using TMPro;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.UI.FunctionBlock;
using MG_BlocksEngine2.Horizontal.Environment;

namespace MG_BlocksEngine2.Horizontal.UI.FunctionBlock
{
    // v2.12 - added class to manage the UI that directs the creation of horizontal Function blocks
    public class BE2_UI_HorizontalCreateFunctionBlockMenu : MonoBehaviour
    {
        public Transform editorBlockTransform;
        I_BE2_Block _editorBlock;

        public GameObject templateInput;
        public GameObject templateLabel;

        void Awake()
        {
            _editorBlock = editorBlockTransform.GetComponent<I_BE2_Block>();
        }

        BE2_HorizontalFunctionBlocksManager functionBlocksManager => BE2_FunctionBlocksManager.Instance as BE2_HorizontalFunctionBlocksManager;
        
        int currentIconIndex = 0;

        public void SetIcon(Image image)
        {
            BE2_BlockSectionHeader_Custom headerItem = _editorBlock.Transform.GetComponentInChildren<BE2_BlockSectionHeader_Custom>();
            headerItem.GetComponent<Image>().sprite = image.sprite;
            currentIconIndex = image.transform.parent.GetSiblingIndex();
            headerItem.serializableValue = GetCustomString();
        }

        public string GetCustomString()
        {
            return "icon:" + currentIconIndex;
        }

        public void RemoveItem(GameObject item)
        {
            item.transform.SetParent(null);
            _editorBlock.Layout.SectionsArray[0].Header.UpdateItemsArray();
            Destroy(item);
        }

        public void OnButtonCreateFunctionBlock()
        {
            List<Serializer.DefineItem> items = new List<Serializer.DefineItem>();
            items.Add(new Serializer.DefineItem("custom", GetCustomString()));
            
            BE2_FunctionBlocksManager.Instance.CreateFunctionBlock(items);
        }

    }
}
