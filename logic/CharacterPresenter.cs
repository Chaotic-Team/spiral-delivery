using System;
using Godot;

public partial class CharacterPresenter : Node
{
    [Signal] public delegate void HealthChangedEventHandler(float val);

    private Character? _character;

    private Character Character => _character ?? throw new InvalidOperationException("Character isn't set.");

    [Export] private Sprite2D? _sprite;

    public void Init(Character c, bool flip = false)
    {
        if (_sprite == null)
            throw new InvalidOperationException("Sprite isn't set.");

        _sprite.FlipH = flip;

        EmitSignal(SignalName.HealthChanged, c.Health);
        c.HealthChanged += (_, val) => EmitSignal(SignalName.HealthChanged, val);

        _character = c;
    }

    public void TestDamage() => Character.Health -= 10;

    public void TestHeal() => Character.Health += 10;
}
