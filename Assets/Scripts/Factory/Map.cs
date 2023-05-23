using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Maze consists of rooms.
/// </summary>
public class Maze
{
    public List<Room> rooms = new List<Room>();

    public void AddRoom(Room room)
    {
        rooms.Add(room);
    }

    public void Load()
    {
        if(rooms.Count == 0)
        {
            return;
        }
        rooms[Random.Range(0,rooms.Count)].Load();
    }
}

/// <summary>
/// Base class for tiles and rooms. Defines that all things must be loaded and unload.
/// Enter method is called when actor enters the mapsite.
/// </summary>
public abstract class MapSite
{
    public virtual void Enter(Actor actor) { }
    /// <summary>
    /// Used to instantiate game objects into the scene.
    /// </summary>
    public virtual void Load() { }
    /// <summary>
    /// Used to clean up game objects from the scene.
    /// </summary>
    public virtual void Unload() { }
}

/// <summary>
/// Consists of tiles. Only one room is loaded at a time.
/// </summary>
public class Room : MapSite
{
    public int nr;
    public List<MapTile> tiles = new List<MapTile>();

    private GameObject go;

    public Room(int nr)
    {
        this.nr = nr;
    }

    public override void Load()
    {
        float startTime = Time.realtimeSinceStartup;
        go = new GameObject("Room " + nr);
        foreach (var tile in tiles)
        {
            tile.Load();
        }

        float loadTime = (Time.realtimeSinceStartup - startTime) * 1000;
        Debug.Log("Room loaded in " + loadTime + " ms");
    }

    public void AddTile(MapTile tile)
    {
        tile.room = this;
        tiles.Add(tile);
    }

    public override void Unload()
    {
        Debug.Log("Unloading room " + nr);
        foreach (var tile in tiles)
        {
            tile.Unload();
        }
        Object.Destroy(go);
    }

    public Transform GetTransform()
    {
        return go.transform;
    }
}

/// <summary>
/// Smallest part of the map. A single tile.
/// </summary>
public abstract class MapTile : MapSite {

    [SerializeField] private ObjectPool pooledGameObject;
    public Pools pools;
    public Room room;
    protected Vector3 position;
    protected GameObject prefab;
    private GameObject go;
    protected const float tileSize = 3f; //hard coded ugliness

    public MapTile(Room room, GameObject pref, Vector3 pos, Pools pools)
    {
        this.room = room;
        this.position = pos;
        this.prefab = pref;
        this.pools = pools;
    }

    public override void Enter(Actor actor)
    {
        Debug.Log(string.Format("{0} entered tile {1}", actor.name, position));
    }

    public override void Load()
    {
        //Instantiate
        //go = Object.Instantiate<GameObject>(prefab, position * tileSize, Quaternion.identity);
        //go.transform.parent = room.GetTransform();
        //go.GetComponent<TileEvent>().tile = this;


        //Pool
        pooledGameObject = pools.GetObject(prefab.name);
        go = pooledGameObject.GetGameObject();
        go.transform.position = position * tileSize;
        go.transform.parent = room.GetTransform();
        go.GetComponent<TileEvent>().tile = this;
    }

    public override void Unload()
    {
        pools.ResetPool(prefab.name);
    }
}

/// <summary>
/// Doesn't really do anything
/// </summary>
public class Ground : MapTile
{
    public Ground(Room room, GameObject pref, Vector3 pos, Pools pools) : base (room, pref, pos, pools)
    {
    }
}

/// <summary>
/// A tile that moves player into anothe room when entered.
/// </summary>
public class Portal : MapTile
{
    Portal exit;

    public Portal(Room room, GameObject pref, Vector3 pos , Pools pools) : base (room, pref, pos, pools)
    {
    }

    public void SetExit(Portal exit)
    {
        this.exit = exit;
    }

    public override void Enter(Actor actor)
    {
        Debug.Log(string.Format("{0} entered portal {1}", actor.name, position));
        if (room != exit.room)
        {
            room.Unload();
            exit.room.Load();
        }
        Vector3 cornerOffset = new Vector3(-2f, 0, -3f);
        actor.SetPosition(exit.position * tileSize + cornerOffset);
    }
}