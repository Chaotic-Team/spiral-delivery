using Godot;
using System;

public partial class BattleManager : Node
{
    private readonly Battle _battle = new();

    [Export] private PackedScene? _characterScene;

    public override void _Ready()
    {
        Init();
    }

    private void Init()
    {
        _battle.Initialized += (_, _) =>
        {
            foreach (var character in _battle.FirstTeam)
            {
                CreatePresenterFor(character);
            }
            foreach (var character in _battle.SecondTeam)
            {
                CreatePresenterFor(character);
            }
        };

        _battle.Init();
    }

    private void CreatePresenterFor(Character character)
    {
        if (_characterScene == null)
            throw new InvalidOperationException("Character scene isn't set.");

        var presenter = _characterScene.Instantiate<CharacterPresenter>();
        presenter.Init(character);
        AddChild(presenter);
    }
}
