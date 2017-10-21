using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Transactions;

namespace ai
{
    public class GameState
    {
        public int playerId;
        public int mapW, mapH;
        public Map map;
        private List<Worker> workers;
        private List<Scout> scouts;
        private List<Tank> tanks;
        private List<Worker> enemyworkers;
        private List<Scout> enemyscouts;
        private List<Tank> enemytanks;
        private List<Resource> resources;
        private bool started = false;

        public Resource GetBestResource()
        {
            Resource best = resources[0];
            foreach (Resource r in resources)
            {
                if (r.priority > best.priority)
                {
                    best = r;
                }
            }
            return best;
        }

        public GameState()
        {
            started = false;
        }

        public void Update(GameMessage game)
        {
            // handle initial setup
            if (started == false)
            {
                playerId = game.Player;
                mapW = game.Game_Info.Map_Width;
                mapH = game.Game_Info.Map_Height;
                started = true;
            }
            
            // handling other changes
            
            
        }


    }

    public class Map
    {
        private GameState game;
        private Tile[,] tilemap;

        public Map(GameState game)
        {
            tilemap = new Tile[60, 60];
            this.game = game;
        }

        public Tile getTile(int x, int y)
        {
            return tilemap[x + 30, y + 30];
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

        public double distance(Tile t1, Tile t2)
        {
            // TODO: use a* to get the distance
            return Math.Sqrt(Math.Pow(t2.x - t1.x, 2) + Math.Pow(t2.y - t1.y, 2));
        }

        public double distance(int x1, int y1, int x2, int y2)
        {
            return distance(getTile(x1, y1), getTile(x2, y2));
        }

        public char PathNext(int x1, int x2, int y1, int y2)
        {
            int mapW = game.mapW * 2;
            int mapH = game.mapH * 2;
            Tile t1 = getTile(x1, y1);
            Tile t2 = getTile(x2, y2);
            HashSet<Tile> open = new HashSet<Tile>();
            open.Add(getTile(x1, y1));
            HashSet<Tile> closed = new HashSet<Tile>();
            int[,] gScore = new int[mapW, mapH];
            for (int x = 0; x < mapW; x++)
            {
                for (int y = 0; y < mapH; y++)
                {
                    gScore[x, y] = Int32.MaxValue;
                }
            }
            gScore[t1.x, t1.y] = 0;
            double[,] fScore = new double[mapW, mapH];
            for (int x = 0; x < mapW; x++)
            {
                for (int y = 0; y < mapH; y++)
                {
                    fScore[x, y] = Int32.MaxValue;
                }
            }
            fScore[t1.x, t1.y] = distance(t1, t2);
            
            while (open.Count > 0)
            {
                
            }
            
            
            
            
            
            return 's';
        }
        
    }

    public class Tile
    {
        public int x, y;
        private bool wall;
        private bool visible;

    }

    class Unit
    {
        public enum State {idle, moving}

        private GameState game;
        
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
            cmd.execute(game, this, x, y);
        }
    }

    public class Resource
    {
        private GameState game;
        public int x, y;
        public int id;
        public int amount;
        public double priority;

        public Resource(GameState game, int x, int y)
        {
            this.game = game;
            priority = game.map.distance(x, y, 0, 0);
        }

    }

    class Worker : Unit
    {
        public int resourceValue;
        
    }

    class Scout : Unit
    {
        
    }
    
    class Tank : Unit
    {
        
    }

    abstract class Command
    {
        private GameState game;

        public Command(GameState game)
        {
            this.game = game;
        }
        public abstract void execute(GameState game, Unit caller, int x, int y);

    }

    class GatherCommand : Command
    {
        private bool full;
        public override void execute(GameState game, Unit caller, int x, int y)
        {
            if (((Worker)caller).resourceValue == 0)
            {
                
            }
        }

        public GatherCommand(GameState game) : base(game)
        {
        }

    }
    
}