using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullMapFactory : IMapFactory
{
    public Maze StartNewMaze()
    {
        Debug.Log($"{GetType().Name} null implementation");
        return null;
    }

    public Room CreateNewRoom(int id)
    {
        Debug.Log($"{GetType().Name} null implementation");
        return null;
    }

    public Portal CreatePortal(Room room, Vector3 position)
    {
        Debug.Log($"{GetType().Name} null implementation");
        return null;
    }

    public MapTile CreateGround(Room room, Vector3 position)
    {
        Debug.Log($"{GetType().Name} null implementation");
        return null;
    }

    public MapTile CreateRiver(Room room, Vector3 position)
    {
        Debug.Log($"{GetType().Name} null implementation");
        return null;
    }
}
