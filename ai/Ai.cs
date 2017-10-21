using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;

namespace ai
{
    public class Ai
    {
        private GameState game;
        private Random rand = new Random();
        private HashSet<int> knownUnits = new HashSet<int>();
        public Ai()
        {
            GameState game = new GameState();
        }

        public string GoJson(string line)
        {
            // Json message is converted into something else. I don't know what because the var isn't typed
            var gameMessage = JsonConvert.DeserializeObject<GameMessage>(line);
            // Calls go
            var commandSet = Go(gameMessage);

            return JsonConvert.SerializeObject(commandSet)+"\n";
        }

        public CommandSet Go(GameMessage gameMessage)
        {
            foreach(var unitUpdate in gameMessage.Unit_Updates){
                knownUnits.Add(unitUpdate.Id);
            }
            var gameCommands = knownUnits.Select(uid => new GameCommand{
                command = "MOVE",
                unit = uid,
                dir = "NEWS".Substring(rand.Next(4),1)
            });

            return new CommandSet { commands = gameCommands };
        }
    }
    public class GameMessage
    {
        public int Player { get; set; }
        public IList<UnitUpdate> Unit_Updates { get; set; }
        public IList<TileUpdate> Tile_Updates { get; set; }
        public int Turn  { get; set; }
        public int Time  { get; set; }
        public GameInfo Game_Info { get; set; }
    }

    public class UnitUpdate
    {
        public int Id { get; set; }
        public int Player_Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public bool Can_Attack { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public int Resource { get; set; }
    }

    public class TileUpdate
    {
        public bool Visible { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Blocked { get; set; }
        public TileResource Resources { get; set; }
        public IList<EnemyUnit> Units { get; set; }
    }

    public class TileResource
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Total { get; set; }
        public int Value { get; set; }
    }

    public class EnemyUnit
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int Player_Id { get; set; }
        public int Health { get; set; }
    }

    public class GameInfo
    {
        public int Map_Width { get; set; }
        public int Map_Height { get; set; }
        public int Game_Duration { get; set; }

        public int Turn_Duration { get; set; }

    }

    public class CommandSet
    {
        public IEnumerable<GameCommand> commands;
    }
    public class GameCommand {
      public string command { get; set; }
      public int unit { get; set; }
      public string dir { get; set; }
    }
}