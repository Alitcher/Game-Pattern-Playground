//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RecorderPlayState : RecorderState
//{
//    private bool macroIsPlaying;

//    private InputRecorder inputRec;

//    public override void Enter(InputRecorder inputRecorder)
//    {
//        base.Enter(inputRecorder);
//        macroIsPlaying = true;
//        this.inputRec = inputRecorder;
//        inputRecorder.PlayBack(PlayMacro());
//    }

//    public override void Play()
//    {
//        base.Play();
//        macroIsPlaying = false;
//        inputRec.EnterState(new RecorderIdleState());

//    }

//    public override void Record()
//    {
//        base.Record();
//        Debug.Log("From Recorder paly state");
//        macroIsPlaying = false;
//        inputRec.EnterState(new RecorderRecordState());

//    }

//    IEnumerator PlayMacro() 
//    {
//        foreach (var cmd in inputRec.recordedCmds)
//        {
//            cmd.Command.Execute(inputRec.InputHandler.GetCurrent());

//            var time = 0f;

//            while (time < cmd.Time)
//            {
//                time += Time.deltaTime;
//                yield return null;

//                if (macroIsPlaying) yield break;

//            }

//        }

//        inputRec.EnterState(new RecorderIdleState());

//    }
//}
