using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoCommand : Command
{

    private MonoBehaviour inputHandler;

    public override KeyCode Key { get; set; }
    public override string Description { get; }

    public UndoCommand(KeyCode key, string description, InputHandler inputHandler)
    {
        this.Key = key;
        this.Description = description;
        this.inputHandler = inputHandler;
    }


    public override void Execute(MonoBehaviour receiver)
    {
        if (receiver is InputHandler)
        {
            (receiver as InputHandler).Undo();
        }
    }

    public override void Undo()
    {
        Debug.Log("Undo something");
    }
}
