//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public class PlayCommand : Command
//{
//    public override KeyCode Key { get; set; } = KeyCode.None;

//    public override string Description { get; } = null;

//    private InputRecorder receiver;


//    public PlayCommand(KeyCode key, InputRecorder input)
//    {
//        this.Key = key;
//        this.Description = "start playing macro";
//        this.receiver = input;
//    }

//    public override void Execute(MonoBehaviour receiver)
//    {
//        if (receiver is InputHandler)
//        {
//            this.receiver = (receiver as InputRecorder);
//            Debug.Log("playing something");
//            this.receiver.Play();
//        }
//    }

//    public override void Undo()
//    {
        
//    }
//}
