using System;

public class Character
{
    private float _health = 100;

    public event EventHandler<float>? HealthChanged;

    public string Name { get; }

    public float Health
    {
        get => _health;
        set
        {
            _health = value;
            HealthChanged?.Invoke(this, value);
        }
    }

    public Character(string name)
    {
        Name = name;
    }

}
