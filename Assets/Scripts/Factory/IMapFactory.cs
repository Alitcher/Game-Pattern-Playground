using UnityEngine;

public interface IMapFactory 
{
    //void CreateMap();
    Maze StartNewMaze();
    Room CreateNewRoom(int id);
    Portal CreatePortal(Room room, Vector3 position);
    MapTile CreateGround(Room room, Vector3 position);
    MapTile CreateRiver(Room room, Vector3 position);
}