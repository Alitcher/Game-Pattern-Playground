using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderInputCommand : Command
{
    public override KeyCode Key { get; set; }

    public override string Description { get; }

    public override void Execute(MonoBehaviour receiver)
    {
    }

    public override void Undo()
    {
    }
}
