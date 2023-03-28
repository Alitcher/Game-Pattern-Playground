using UnityEngine;


[System.Serializable]
public abstract class Command
{

    public abstract KeyCode Key { get; set; }
    public abstract string Description { get; }

    public abstract void Execute(MonoBehaviour receiver);

    public abstract void Undo();

}
