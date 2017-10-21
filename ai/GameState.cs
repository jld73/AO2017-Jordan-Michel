using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace ai
{
    public class GameState
    {
        private Map map;
        private List<Worker> workers;
        private List<Scout> scouts;
        private List<Tank> tanks;
        private List<Worker> enemyworkers;
        private List<Scout> enemyscouts;
        private List<Tank> enemytanks;
        
        

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
        public enum State {idle, moving}
        
        // This unit's position
        private int x, y;
        // TJis unit's health
        private int health;
        // This unit's id
        private int id;
        
        // Current command to execute
        private Command cmd;
        // Whether this unit is allied
        private bool ally;
        // Whether this unit is busy`
        private State state;
        // Whether attack is ready
        private bool attackReady;
        
        

        private void executeCommand()
        {
            cmd.execute();
        }
    }

    class Resource
    {
        public int x, y;
        private int id;

    }

    class Worker : Unit
    {
        
    }

    class Scout : Unit
    {
        
    }
    
    class Tank : Unit
    {
        
    }

    abstract class Command
    {
        public abstract void execute();

    }
    
}