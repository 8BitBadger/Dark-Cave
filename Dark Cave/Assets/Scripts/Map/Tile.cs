using System.Collections;
using System.Collections.Generic;
using System;


public enum TileType
{
    None,
    Floor,
    Ground,
    Rock,
    MiniralGround,
    Room
};

public enum RoomType
{
    None,
    BedRoom,
    Farm,
    Tresuary,
    Training,
    Library

};

public class Tile
{

    //The type of the tile
    TileType type = TileType.Floor;

    //The type of room the tile is part of
    RoomType room = RoomType.None;

    //External funtion to be called when the tile type is changed
    Action<Tile> cbTileTypeChanged;

    //External function to be called when the visibility of the tile is changed, used for the FOW effect
    Action<Tile> cbTileVisibilityChanged;

    public TileType Type
    {
        get{ return type; }

        set
        {
            //Set the old type to the current type to check for change in the tile
            TileType oldType = type;
            //Set the type to the new type
            type = value;
            //Using action deligate
            if (cbTileTypeChanged != null && oldType != type)
            {
                cbTileTypeChanged(this);
            }
        }
    }

    public RoomType Room
    {
        get { return room; }

        set { room = value; }
    }

    public int X { get; protected set; }

    public int Y { get; protected set; }



    public Tile(int x, int y)
    {
        //The tiles co oordinates
        this.X = x;
        this.Y = y;
    }

    public void RegisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged += callback;
    }
    public void UnregisterTileTypeChangedCallback(Action<Tile> callback)
    {
        cbTileTypeChanged -= callback;
    }
	
	
}
