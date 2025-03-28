using System;
using System.Collections.Generic;

public class Battle
{
    public event EventHandler? Initialized;

    public readonly List<Character> FirstTeam = new();
    public readonly List<Character> SecondTeam = new();

    public void Init()
    {
        for (var i = 0; i < 5; i++)
        {
            FirstTeam.Add(new Character($"First team {i} dude"));
            SecondTeam.Add(new Character($"Second team {i} dude"));
        }

        Initialized?.Invoke(this, EventArgs.Empty);
    }
}
