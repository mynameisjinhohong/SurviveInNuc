using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG_BlocksEngine2.Block.Instruction;
using MG_BlocksEngine2.Block;

public class BE2_Cst_RotateYAxis : BE2_InstructionBase, I_BE2_Instruction
{
    //protected override void OnAwake()
    //{
    //
    //}
    
    //protected override void OnStart()
    //{
    //    
    //}

    I_BE2_BlockSectionHeaderInput _input0;

    public new void Function()
    {
        _input0 = Section0Inputs[0];
        TargetObject.Transform.Rotate(Vector3.up, _input0.FloatValue);

        ExecuteNextInstruction();
    }
}
