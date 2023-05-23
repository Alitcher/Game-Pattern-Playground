﻿using UnityEngine;
using System.Collections;

public class MazeGame : MonoBehaviour {

    protected Maze maze;
    public MazeFactory factory;
    public GameObject ground;
    public GameObject riverRight;
    public GameObject riverForward;
    public GameObject portal;

	// Use this for initialization
	void Start () {
        CreateMaze();
    }

    /**
        The following method has the responsibility to create a simple maze with two rooms. Each 
        of the rooms consists of ground tiles and portals.

        The required GameObjects along with all the components of each tile are only instantiated
        into the game when the player enters a room. The tiles are also unloaded upon exiting.

        A portal is a special kind of tile, which has a reference to another door. When player walks
        into this tile, then the current room is unloaded and another room is loaded.

        
        The task:
        
        Currently the CreateMaze method is tightly coupled to the types of tiles it creates for the
        maze. Your task is to refactor this class so that:
            * CreateMaze will take a factory as a method parameter
            * CreateMaze does no longer call a single constructor
            * all objects for maze, rooms, portals, ground and river are received from the factory.
            * The public GameObject fields for prefabs should be removed.
            * The start method makes use of singleton or service locator to access a factory.
        
        Also of note is that the river tiles are simply ground tiles with different graphic.

    */
    public virtual void CreateMaze()
    {
        IMapFactory factory = ServiceLocator.Locate<IMapFactory>();

        maze = factory.StartNewMaze();

        Room room1 = factory.CreateNewRoom(1);
        Room room2 = factory.CreateNewRoom(2);

        Portal door1 = factory.CreatePortal(room1, new Vector3(2f, 0, 0));
        Portal door2 = factory.CreatePortal(room2, new Vector3(0, 0, 2f));
        door1.SetExit(door2);
        door2.SetExit(door1);
        room1.AddTile(door1);
        room2.AddTile(door2);

        maze.AddRoom(room1);
        maze.AddRoom(room2);

        for(int i = -1; i<2; i++)
        {
            for (int j = -1; j < 3; j++)
            {
                MapTile tile = j == 1 ? factory.CreateRiver(room1, new Vector3(i, 0, j)) : factory.CreateGround(room1, new Vector3(i, 0, j));
                room1.AddTile(tile);
            }
        }

        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                MapTile tile = i == 1 ? factory.CreateRiver(room2, new Vector3(i, 0, j)) : factory.CreateGround(room2, new Vector3(i, 0, j));
                room2.AddTile(tile);
            }
        }

        maze.Load();
    }
}
