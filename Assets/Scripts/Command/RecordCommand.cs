using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordCommand : PlaybackCommand
{
    public override KeyCode Key { get; set; }
    public override string Description { get; }
    private InputRecorder receiver;


    public RecordCommand(KeyCode key)
    {
        this.Key = key;
        this.Description = "record cmd implemented";
    }

    public override void Execute(MonoBehaviour receiver)
    {
        if (receiver is InputRecorder)
        {
            this.receiver = (receiver as InputRecorder);
            Debug.Log("recording something");
            this.receiver.Record();
        }
    }

    public override void Undo()
    {
        
    }
}
