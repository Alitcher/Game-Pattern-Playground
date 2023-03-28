using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecordedCommand 
{
    public int frameSinceLastCmd { get; private set; }
    public  Command cmd { get; private set; }


    public RecordedCommand(Command cmd, int frameSinceLastCmd)
    {
        this.cmd = cmd;
        this.frameSinceLastCmd = frameSinceLastCmd;
    }
}
