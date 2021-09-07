using System;
using System.Linq;
using Kuiper.Domain;
using Newtonsoft.Json;

namespace Kuiper.Systems
{
    public class CaptainsConsole
    {
        Captain _currentCaptain;
        public CaptainsConsole()
        {
            if(_currentCaptain == null) 
            {
                //attempt to load captain
                SetupCaptain();
            }
        }

        public void ConsoleMapper(string input)
        {
            switch (input)
            {
                case "help":
                    Help();
                    break;
                case "save":
                    Save();
                    break;
                default:
                    ConsoleWriter.Write($"{Environment.NewLine}{input} not recognized. Try 'help' for list of commands");
                    break;
            }
        }

        public void Help()
        {
            ConsoleWriter.Write($"{Environment.NewLine}No help availiable.");

        }

        public void Save()
        {
            _currentCaptain.LastSeen = DateTime.Now;
            SaveLoad.SaveGame(_currentCaptain);
            ConsoleWriter.Write($"{Environment.NewLine}Game saved successfully.", ConsoleColor.Red);
        }

        public void SetupCaptain()
        {
            ConsoleWriter.Write("Greetings captain, what is your name?");
            var name = Console.ReadLine();
            var currentDate = DateTime.Now;
            var saves = SaveLoad.LookForSaves(name);
            if(saves.Count() > 0)
            {
                _currentCaptain = SaveLoad.Load(saves.FirstOrDefault());
                ConsoleWriter.Write($"{Environment.NewLine}Welcome back Captain {_currentCaptain.Name}, you were last seen on {_currentCaptain.LastSeen}!");    
                return;
            }

            ConsoleWriter.Write($"{Environment.NewLine}Welcome, Captain {name}, you have logged in on {currentDate:d} at {currentDate:t}!");
            _currentCaptain = new Captain(name);
        }
    }
}