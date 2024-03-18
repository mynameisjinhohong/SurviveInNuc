using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.UI.FunctionBlock;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.EditorScript;
using TMPro;
using System.Linq;
using MG_BlocksEngine2.Utils;
using MG_BlocksEngine2.Environment;
using UnityEngine.UI;
using MG_BlocksEngine2.Horizontal.DragDrop;

namespace MG_BlocksEngine2.Horizontal.Environment
{
    // v2.12 - added class to manage thecreation of the horizontal Function Blocks 
    public class BE2_HorizontalFunctionBlocksManager : BE2_FunctionBlocksManager
    {
        public List<Sprite> icons;
        [SerializeField] Transform iconsPanel;

        void Start()
        {
            icons = new List<Sprite>();
            foreach (Button child in iconsPanel.GetComponentsInChildren<Button>())
            {
                icons.Add(child.transform.GetChild(0).GetComponent<Image>().sprite);
            }
        }

        public override void CreateFunctionBlock(List<Serializer.DefineItem> items)
        {
            I_BE2_ProgrammingEnv programmingEnv = BE2_ExecutionManager.Instance.ProgrammingEnvsList.Find(x => x.Visible == true);

            BE2_Ins_DefineFunction templateDefine = DefineFunctionBlockTemplate.GetComponent<BE2_Ins_DefineFunction>();

            BE2_Ins_DefineFunction defineBlockIns = Instantiate<BE2_Ins_DefineFunction>(templateDefine, Vector3.zero, Quaternion.identity, programmingEnv.Transform);
            I_BE2_BlockLayout layoutDefine = defineBlockIns.GetComponent<I_BE2_BlockLayout>();

            defineBlockIns.name = templateDefine.name;

            defineBlockIns.transform.position = positionToInstantiate;

            List<string> alreadyUsedVariableNames = new List<string>();
            foreach (Serializer.DefineItem item in items)
            {
                if (item.type == "custom")
                {
                    GameObject headerItemGO = Instantiate(BE2_FunctionBlocksManager.Instance.templateDefineCustomHeaderItem, Vector3.zero, Quaternion.identity,
                                                    layoutDefine.SectionsArray[0].Header.RectTransform);

                    BE2_BlockSectionHeader_Custom headerItem = headerItemGO.GetComponent<BE2_BlockSectionHeader_Custom>();
                    headerItem.serializableValue = item.value;
                }
            }

            BE2_BlockUtils.UnloadPrefab();

            CreateSelectionFunction(items, defineBlockIns);

        }

        public override void CreateSelectionFunction(List<Serializer.DefineItem> items, BE2_Ins_DefineFunction defineBlockIns)
        {
            bool panelIsActive = functionBlocksPanel.gameObject.activeSelf;
            functionBlocksPanel.gameObject.SetActive(true);

            GameObject selectionFunctionBlock = Instantiate(templateSelectionBlock, Vector3.zero, Quaternion.identity, functionBlocksPanel);
            I_BE2_BlockLayout selectionLayout = selectionFunctionBlock.GetComponent<I_BE2_BlockLayout>();

            foreach (Serializer.DefineItem item in items)
            {
                if (item.type == "custom")
                {
                    GameObject headerItemGO = Instantiate(BE2_FunctionBlocksManager.Instance.templateDefineCustomHeaderItem, Vector3.zero, Quaternion.identity,
                                                   selectionLayout.SectionsArray[0].Header.RectTransform);
                    
                    BE2_BlockSectionHeader_Custom headerItem = headerItemGO.GetComponent<BE2_BlockSectionHeader_Custom>();
                    headerItem.serializableValue = item.value;
                }
            }

            selectionLayout.UpdateLayout();
            selectionFunctionBlock.GetComponent<BE2_DragHorizontalSelectionFunction>().defineFunctionInstruction = defineBlockIns;

            functionBlocksPanel.gameObject.SetActive(panelIsActive);
        }
    }
}
