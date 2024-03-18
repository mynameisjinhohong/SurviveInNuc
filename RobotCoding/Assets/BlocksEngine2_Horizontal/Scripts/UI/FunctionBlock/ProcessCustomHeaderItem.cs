using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Horizontal.UI.FunctionBlock;
using UnityEngine.UI;
using MG_BlocksEngine2.Environment;
using MG_BlocksEngine2.Horizontal.Environment;

namespace MG_BlocksEngine2.Horizontal
{
    // v2.12 - added class to precess the horizontal Function Blocks header after creation by getting the custom header value and loading the correct icon sprite 
    public class ProcessCustomHeaderItem : MonoBehaviour
    {
        BE2_BlockSectionHeader_Custom customHeaderItem;

        void Awake()
        {
            customHeaderItem = GetComponent<BE2_BlockSectionHeader_Custom>();
        }

        void Start()
        {
            Process();
        }

        public void Process()
        {
            StartCoroutine(C_Process());
        }

        IEnumerator C_Process()
        {
            yield return new WaitForEndOfFrame();
            int iconIndex = -1;
            int.TryParse(customHeaderItem.serializableValue.Split(':')[1], out iconIndex);
            if (iconIndex > -1)
                customHeaderItem.GetComponent<Image>().sprite = (BE2_FunctionBlocksManager.Instance as BE2_HorizontalFunctionBlocksManager).icons[iconIndex];
        }
    }
}
