using System;
using Godot;

[Tool]
public partial class CharacterPresenter : Node
{
    [Signal] public delegate void HealthChangedEventHandler(float val);

    private Character Character => _character ?? throw new InvalidOperationException("Character isn't set.");
    private Character? _character;

    [Export] private Sprite2D? _sprite;

    public override string[] _GetConfigurationWarnings()
    {
        if (_sprite == null)
            return new[] {"Sprite isn't set."};

        return Array.Empty<string>();
    }

    public void Init(Character c, bool flip = false)
    {
        if (_sprite == null)
            throw new InvalidOperationException("Sprite isn't set.");

        if (flip)
            _sprite.FlipH = !_sprite.FlipH;

        EmitSignal(SignalName.HealthChanged, c.Health);
        c.HealthChanged += (_, val) => {
            EmitSignal(SignalName.HealthChanged, val);
            if (val <= 0) QueueFree();
        };
        
        _character = c;
    }

    public void TestDamage() => Character.Health -= 10;

    public void TestHeal() => Character.Health += 10;
}
