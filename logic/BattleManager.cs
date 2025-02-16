using Godot;
using System;

public partial class BattleManager : Node
{
    private readonly Battle _battle = new();

    [Export] private PackedScene? _characterScene;

    [Export] private Node2D[] _leftSpawnPositions = Array.Empty<Node2D>();
    [Export] private Node2D[] _rightSpawnPositions = Array.Empty<Node2D>();

    public override void _Ready()
    {
        Init();
    }

    private void Init()
    {
        _battle.Initialized += (_, _) =>
        {
            if (_leftSpawnPositions.Length < _battle.FirstTeam.Count)
                throw new InvalidOperationException("Not enough left spawn positions.");

            for (int i = 0; i < _battle.FirstTeam.Count; i++)
                CreatePresenterFor(_battle.FirstTeam[i], _leftSpawnPositions[i]);

            if (_rightSpawnPositions.Length < _battle.SecondTeam.Count)
                throw new InvalidOperationException("Not enough right spawn positions.");

            for (int i = 0; i < _battle.SecondTeam.Count; i++)
                CreatePresenterFor(_battle.SecondTeam[i], _rightSpawnPositions[i], true);
        };

        _battle.Init();
    }

    private void CreatePresenterFor(Character character, Node2D position, bool flip = false)
    {
        if (_characterScene == null)
            throw new InvalidOperationException("Character scene isn't set.");

        var presenter = _characterScene.Instantiate<CharacterPresenter>();
        position.AddChild(presenter);
        presenter.Init(character, flip);
    }
}
