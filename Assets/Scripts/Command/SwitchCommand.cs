using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCommand : Command
{
    public override KeyCode Key { get; set; }
    public override string Description { get; }

    private InputHandler receiver;

    public override void Execute(MonoBehaviour receiver)
    {
        if (receiver is InputHandler)
        {
            this.receiver = (receiver as InputHandler);
            (receiver as InputHandler).SwitchCharacter(1);
        }
    }

    public override void Undo()
    {
        (this.receiver as InputHandler).SwitchCharacter(-1);
    }
}
