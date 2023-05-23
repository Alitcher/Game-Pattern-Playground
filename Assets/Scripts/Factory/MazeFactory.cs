using UnityEngine;

public class MazeFactory : MonoBehaviour, IMapFactory
{
    public GameObject ground;
    public GameObject riverRight;
    public GameObject riverForward;
    public GameObject portal;
    [SerializeField] private Pools pools;

    [SerializeField] private int initialSize = 20;
    public void Awake()
    {
        ServiceLocator.Provide<MazeFactory>(this);
        pools = new Pools();


        // Create a pool for each prefab
        pools.CreatePool(ground.name, ground, transform, initialSize);
        pools.CreatePool(riverRight.name, riverRight, transform, initialSize);
        pools.CreatePool(riverForward.name, riverForward, transform, initialSize);
        pools.CreatePool(portal.name, portal, transform, initialSize);
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
        return new Portal(room, portal, position, pools);
    }

    public MapTile CreateGround(Room room, Vector3 position)
    {
        return new Ground(room, ground, position, pools);
    }

    public MapTile CreateRiver(Room room, Vector3 position)
    {
        GameObject riverPrefab = position.z == 1 ? riverRight : riverForward;
        return new Ground(room, riverPrefab, position, pools);
    }
}