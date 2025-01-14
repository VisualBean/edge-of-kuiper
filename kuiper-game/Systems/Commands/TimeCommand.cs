﻿namespace Kuiper.Systems
{
    public class TimeCommand : ConsoleCommandBase
    {
        public override string Name => "time";

        public override void Execute(string[] args)
        {
            var currentGameTime = GameTime.Now();
            ConsoleWriter.Write($"The time is currently: {currentGameTime}");
        }
    }
}