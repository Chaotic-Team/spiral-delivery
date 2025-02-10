using System;
using System.Collections.Generic;

public class Battle
{
    public event EventHandler? Initialized;

    public readonly List<Character> FirstTeam = new();
    public readonly List<Character> SecondTeam = new();

    public void Init()
    {
        FirstTeam.Add(new Character("First dude"));
        SecondTeam.Add(new Character("Second dude"));

        Initialized?.Invoke(this, EventArgs.Empty);
    }
}
