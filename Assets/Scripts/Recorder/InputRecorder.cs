//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InputRecorder : MonoBehaviour
//{
//    public List<PlaybackCommand> recordedCmds;
//    public float LastRecordedTime;

//    [SerializeField]
//    private RecorderState _state;

//    public InputHandler InputHandler { get; set;}

//    public static InputRecorder I { get; private set; }

//    private bool isMacroRecording = false;
//    private bool isMacroPlaying = false;
//    private int frameSinceLastCmd = 0;

//    [SerializeField]
//    private List<RecordedCommand> macro = new List<RecordedCommand>();

//    private void Awake()
//    {
//        recordedCmds = new List<PlaybackCommand>();

//        if (I != null && I != this)
//        {
//            Destroy(this);
//        }
//        else 
//        {
//            I = this;

//        }

//        recordedCmds.Add(new PlaybackCommand(KeyCode.P, this));
//        recordedCmds.Add(new RecordCommand(KeyCode.R));
//    }

//    private void Update()
//    {
//        frameSinceLastCmd++;
//        foreach (var cmd in recordedCmds)
//        {
//            if (Input.GetKeyDown(cmd.Key))
//            {
//                if (isMacroRecording && !(cmd is RecordCommand) && !(cmd is PlaybackCommand))
//                {
//                    macro.Add(new RecordedCommand(cmd, frameSinceLastCmd));

//                }
//                if (cmd is RecordCommand)
//                {
//                    Record();
//                }
//                if (cmd is PlaybackCommand)
//                {
//                    Play();
//                }
//                if (!(cmd is RecordCommand) && !(cmd is PlaybackCommand))
//                {
//                    frameSinceLastCmd = 0;
//                    cmd.Command.Execute(InputHandler.GetCurrent());
//                }
//            }
//        }
//    }

//    internal void EnterState(RecorderIdleState recorderIdleState)
//    {
//        throw new System.NotImplementedException();
//    }

//    internal void EnterState(RecorderRecordState recorderRecordState)
//    {
//        throw new System.NotImplementedException();
//    }

//    public void Add(Command cmd) 
//    {
//        if (cmd is RecorderInputCommand)
//            return;

//        var time = Time.fixedTime - LastRecordedTime;

//        LastRecordedTime = Time.fixedTime;

//        var recordedCmd = new PlaybackCommand
//        {
//            Command = cmd,
//            Time = time,
//            Key = cmd.Key
//        };

//        _state.Add(recordedCmd);
//    }

//    public void EnterState(RecorderState state) 
//    {
//        _state = state;
//        _state.Enter(this);
//    }

//    public void Play() 
//    {
//        _state.Play();
//        if (isMacroPlaying)
//        {
//            isMacroPlaying = false;
//        }
//        else
//        {
//            isMacroPlaying = true;
//            StartCoroutine(playMacro());
//        }

//        isMacroRecording = false;
//    }

//    public void Record() 
//    {
//        _state.Record();
//        if (isMacroRecording)
//        {
//            isMacroRecording = false;
//        }
//        else
//        {
//            isMacroRecording = true;
//        }
//    }

//    public void PlayBack(IEnumerator playback) 
//    {
//        StartCoroutine(playback);
//    }

//    IEnumerator playMacro()
//    {
//        bool firstCommand = true;
//        foreach (RecordedCommand cmd in macro)
//        {
//            if (!firstCommand)
//            {
//                int framesFromLast = 0;
//                while (framesFromLast < cmd.frameSinceLastCmd)
//                {
//                    framesFromLast++;
//                    yield return null;
//                    if (!isMacroPlaying) yield break;
//                    //Debug.Log($"waiting for delay between frames. framesfromlast: {framesFromLast} < {cmd.framesSinceLastCommand}");
//                }
//            }
//            else
//            {
//                firstCommand = false;
//            }
//            cmd.cmd.Execute(InputHandler.GetCurrent());
//            Debug.Log($"Executing command { cmd.cmd.Description}, delay between frames: {cmd.frameSinceLastCmd}");
//        }

//        isMacroPlaying = false;
//        yield break;

//    }
//}
