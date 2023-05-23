//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MoveCommand : Command
//{

//    public override KeyCode Key { get; set; }
//    public override string Description { get; }
//    private GridMovement receiver;

//    private Vector3 Direction;

//    public MoveCommand(KeyCode key, string description, Vector3 dir)
//    {
//        this.Key = key;
//        this.Description = description;
//        this.Direction = dir;
//    }

//    public override void Execute(MonoBehaviour receiver) 
//    {
//        if (receiver is GridMovement)
//        {
//            this.receiver = (receiver as GridMovement);
//            (receiver as GridMovement).Walk(Direction);
//        }
//    }

//    public override void Undo()
//    {
//        GridMovement gm = (GridMovement)this.receiver;
//        gm.Walk(-Direction);
//    }

//}
