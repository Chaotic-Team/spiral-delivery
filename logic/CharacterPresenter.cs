using System;
using Godot;

public partial class CharacterPresenter : Node
{
    [Signal] public delegate void HealthChangedEventHandler(float val);

    private Character? _character;

    public void Init(Character c)
    {
        Name = c.Name;
        c.HealthChanged += (_, val) => EmitSignal(SignalName.HealthChanged, val);

        var testBtn = new Button { Text = "Test Damage" };
        testBtn.Pressed += () => TestDamage();
        AddChild(testBtn);

        _character = c;
    }

    private void TestDamage()
    {
        if (_character == null)
            throw new InvalidOperationException("Character isn't set.");

        _character.Health -= 1;
    }
}
