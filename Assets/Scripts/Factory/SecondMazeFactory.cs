using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMazeFactory : MonoBehaviour, IMapFactory
{
    public GameObject someGround;
    public GameObject someRiverRight;
    public GameObject someRiverForward;
    public GameObject somePortal;
    private Pools pools;

    public void Awake()
    {
        ServiceLocator.Provide<IMapFactory>(this);
        pools = new Pools();
    }

    public Maze StartNewMaze()
    {
        return new Maze();
    }

    public Room CreateNewRoom(int id)
    {
        return new Room(id);
    }

    public Portal CreatePortal(Room room, Vector3 position)
    {
        return new Portal(room, somePortal, position, pools);
    }

    public MapTile CreateGround(Room room, Vector3 position)
    {
        return new Ground(room, someGround, position, pools);
    }

    public MapTile CreateRiver(Room room, Vector3 position)
    {
        GameObject riverPrefab = position.z == 1 ? someRiverRight : someRiverForward;
        return new Ground(room, riverPrefab, position, pools);
    }
}
