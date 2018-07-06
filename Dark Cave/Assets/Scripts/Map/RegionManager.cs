using System.Collections;
using System.Collections.Generic;

using UnityEngine;

    //The coordinate structure we use to keep track of the tile position for the region detection
    public struct Coord
    {
        public int tileX;
        public int tileY;

        public Coord(int x, int y)
        {
            tileX = x;
            tileY = y;
        }
    }
namespace MapSystem
{

    public class RegionManager
    {


        public List<List<Coord>> GetRegions(Tile[,] map, int width, int height, TileType tileType)
        {

            //Init the list of region lists
            List<List<Coord>> regions = new List<List<Coord>>();
            //Create an aray of ints the width and height of the map so we can keep track of what tiles we already scaned by using mapFlags as a list
            int[,] mapFlags = new int[width, height];

            //Start looping through the map 
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //if the mapFlags are 0 and the the rawMap tile value is the same as tileType which is set to 0 at this moment
                    if (mapFlags[x, y] == 0 && map[x, y].Type == tileType)
                    {
                        //We create a new region becuase we detected a new tile of type 0 and get the region returned from the GetRegionTiles()
                        List<Coord> newRegion = GetRegionTiles(map, width, height, x, y);
                        //We then add the newRegion to the list of regions to be returned
                        regions.Add(newRegion);
                        //We then loop throught the newRegion and set the mapFlags in those positions to 0
                        foreach (Coord tile in newRegion)
                        {
                            //We set the mapflags to one at the positions we have in the newRegion to not go over them again
                            mapFlags[tile.tileX, tile.tileY] = 1;
                        }
                    }
                }
            }
            return regions;
        }

        public List<Coord> GetRoomTiles(Tile[,] map, int width, int height, int startX, int startY)
        {
            //Create the list for storing all the room tiles
            List<Coord> roomTiles = new List<Coord>();

            //An array of ints to keep track of tiles already scanned
            int[,] mapFlags = new int[width, height];
            //Set the tile type so we know what tile we are looking for
            TileType tileType = TileType.Room;
            //Set the roomType so we knoe what room we are looking for
            RoomType roomType = map[startX, startY].Room;

            if (map[startX, startY].Room == RoomType.None)
            {
                Debug.LogError("Room tile is still set to null, check room asignment at tile change interval");
                return null;
            }
            //Here we create the queue that will hold the coordinates for this regions tiles
            Queue<Coord> queue = new Queue<Coord>();
            //Here the queues first element is set to our starting tile
            queue.Enqueue(new Coord(startX, startY));
            //We set the mapFlags first element to 0 as weel to let the program know we doe not want to check it again
            mapFlags[startX, startY] = 1;

            while (queue.Count > 0)
            {
                //Here we set the variable tile to the value of the first item in the queue then the queue items is removed due to us using queue.Decueue();
                //So this means that queue is now empty after this line of code is run
                Coord tile = queue.Dequeue();
                //We add the tile to the tiles list for
                roomTiles.Add(tile);

                //Here we run a special loop that is designed to to check all the tiles around the tile coord
                for (int x = tile.tileX - 1; x <= tile.tileX + 1; x++)
                {
                    for (int y = tile.tileY - 1; y <= tile.tileY + 1; y++)
                    {
                        //Check if the coordinates given are in the map region as not to cuase an error, then we check that we do not add the the original tile to the list
                        if (WorldManager.Instance.map.IsInMapRange(x, y) && (y != tile.tileY || x != tile.tileX))
                        {
                            if (mapFlags[x, y] == 0 && map[x, y].Type == tileType && map[x, y].Room == roomType)
                            {
                                mapFlags[x, y] = 1;
                                queue.Enqueue(new Coord(x, y));
                            }
                        }

                    }
                }

            }
            return roomTiles;
        }

        List<Coord> GetRegionTiles(Tile[,] map, int width, int height, int startX, int startY)
        {
            //Create a list of coordinatyes for the tiles that will be returned
            List<Coord> tiles = new List<Coord>();
            //An array of ints to keep track of tiles already scanned
            int[,] mapFlags = new int[width, height];
            //Set the tile type to the type of the starting tile so we know what tile type we are looking for
            TileType tileType = map[startX, startY].Type;
            //Here we create the queue that will hold the coordinates for this regions tiles
            Queue<Coord> queue = new Queue<Coord>();
            //Here the queues first element is set to our starting tile
            queue.Enqueue(new Coord(startX, startY));
            //We set the mapFlags first element to 0 as weel to let the program know we doe not want to check it again
            mapFlags[startX, startY] = 1;

            while (queue.Count > 0)
            {
                //Here we set the variable tile to the value of the first item in the queue then the queue items is removed due to us using queue.Decueue();
                //So this means that queue is now empty after this line of code is run
                Coord tile = queue.Dequeue();
                //We add the tile to the tiles list for
                tiles.Add(tile);

                //Here we run a special loop that is designed to to check all the tiles around the tile coord
                for (int x = tile.tileX - 1; x <= tile.tileX + 1; x++)
                {
                    for (int y = tile.tileY - 1; y <= tile.tileY + 1; y++)
                    {
                        //Check if the coordinates given are in the map region as not to cuase an error, then we check that we do not add the the original tile to the list
                        if (WorldManager.Instance.map.IsInMapRange(x, y) && (y != tile.tileY || x != tile.tileX))
                        {
                            if (mapFlags[x, y] == 0 && map[x, y].Type == tileType)
                            {
                                mapFlags[x, y] = 1;
                                queue.Enqueue(new Coord(x, y));
                            }
                        }

                    }
                }

            }
            return tiles;
        }
    }
}

