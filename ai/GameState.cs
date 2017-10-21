using System;
using System.Collections;

namespace ai
{
    public class GameState
    {
        private Map map;
        
    }

    class Map
    {
        private Tile[,] tilemap;

        public Map()
        {
            tilemap = new Tile[60, 60];
        }

        public Tile getTile(int x, int y)
        {
            return tilemap[x, y];
        }
        // Gets tile adjecent to the provided tile
        public Tile getAdj(Tile t, char dir)
        {
            switch (dir)
            {
                case 'N':
                    return tilemap[t.x, t.y + 1];
                case 'E':
                    return tilemap[t.x + 1, t.y];
                case 'S':
                    return tilemap[t.x, t.y - 1];
                case 'W':
                    return tilemap[t.x - 1, t.y];
                default:
                    throw new Exception("Invalid Direction");
            }
            return null;
        }
        
    }

    class Tile
    {
        public int x, y;
        private bool wall;
        private bool visible;

    }

    class Unit
    {
        // This unit's position
        private int x, y;
        // Current command to execute
        private Command cmd;
        // Whether this unit is allied
        private bool ally;

        private void executeCommand()
        {
            cmd.execute();
        }
    }

    class Worker : Unit
    {
        
    }

    class Scout : Unit
    {
        
    }

    abstract class Command
    {
        public abstract void execute();

    }
}