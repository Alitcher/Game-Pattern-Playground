using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
public class InputHandler : MonoBehaviour
{

    //SerializeField let's us assign a value in the Unity editor for private variables.
    [SerializeField]
    //The character currently being commanded
    private GridMovement currentActor;

    [SerializeField]
    //A list of all characters in the scene
    private List<GridMovement> allActors;

    //Variables for binding commands to input and executing commands
    public List<Command> Keymap = new List<Command>();  //keycode to command mapping

    public Stack<Command> cmdHistory = new Stack<Command>();

    [SerializeField]
    private List<RecordedCommand> macro = new List<RecordedCommand>();

    [SerializeField]
    private Command SwitchCharCommand;

    [SerializeField]
    private InputRecorder inputRecorder;

    // Use this for initialization
    void Awake()
    {
        //allActors = FindObjectsOfType<GridMovement>().ToList();
        Keymap.Add(new MoveCommand(KeyCode.W, "move up", Vector3.up));
        Keymap.Add(new MoveCommand(KeyCode.S, "move down", Vector3.down));
        Keymap.Add(new MoveCommand(KeyCode.A, "move left", Vector3.left));
        Keymap.Add(new MoveCommand(KeyCode.D, "move right", Vector3.right));

        Keymap.Add(new UndoCommand(KeyCode.LeftControl, "Undo", this));

        //Keymap.Add(new PlayCommand(KeyCode.P, this));
        Keymap.Add(new RecordCommand(KeyCode.R));

        CheckCurrentChar();
        SwitchCharCommand = new SwitchCommand();
    }

    private void CheckCurrentChar()
    {
        for (int i = 0; i < allActors.Count; i++)
        {
            if (currentActor == allActors[i])
            {
                currentChar = i;
                return;
            }
        }
    }

    void Update()
    {
        //TODO: Uncomment
        foreach (var cmd in Keymap.Where(cmd => Input.GetKeyDown(cmd.Key)))
        {
            cmd.Execute(currentActor);

            if (!(cmd is UndoCommand))
            {
                cmdHistory.Push(cmd);
            }
            inputRecorder.Add(cmd);
        }

        //TODO: Move all record and play related to InputRecorder
        foreach (var cmd in Keymap)
        {
            inputRecorder.Add(cmd);

            if (Input.GetKey(cmd.Key))
            {
                if (!(cmd is UndoCommand))
                {
                    cmdHistory.Push(cmd);
                    cmd.Execute(currentActor);
                }
                else
                {
                    cmd.Execute(this);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            cmdHistory.Push(SwitchCharCommand);
            SwitchCharCommand.Execute(this);
        }
    }

    public GridMovement GetCurrent() 
    {
        return currentActor;
    }

    public void Undo()
    {
        if (cmdHistory.Count == 0) return;

        var cmd = cmdHistory.Pop();
        cmd.Undo();
    }

    private int currentChar = 0;
    public void SwitchCharacter(int adder)
    {
        currentChar += adder;
        if (currentChar >= allActors.Count)
        {
            currentChar = 0;
        }
        else if (currentChar < 0)
        {
            currentChar = allActors.Count - 1;
        }
        print(currentChar);
        currentActor = allActors[currentChar];
        Camera.main.GetComponentInParent<CameraMovement>().SetTarget(currentActor.gameObject.transform);
    }
}

