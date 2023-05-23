//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlaybackCommand : Command
//{
//    public Command Command { get; internal set; }
//    public float Time { get; internal set; }
//    public override KeyCode Key { get; set; } = KeyCode.None;

//    public override string Description { get; } = null;

//    public override void Execute(MonoBehaviour receiver)
//    {
//        throw new System.NotImplementedException();
//    }

//    public override void Undo()
//    {
//        throw new System.NotImplementedException();
//    }

//    public PlaybackCommand()
//    {

//    }

//    public PlaybackCommand(KeyCode key, InputRecorder input)
//    {
//        this.Key = key;
//        this.Description = "start playing ";
//       // this.receiver = input;
//    }
//}
