using Entitas;
using UnityEngine;

public class ChangePlayerHealthSystem : IExecuteSystem {
    private readonly IGroup<GameEntity> _playerGroup;

    public ChangePlayerHealthSystem(Contexts contexts) {
        _playerGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute() {
        foreach (var entity in _playerGroup.GetEntities()) {
            // Check for D key to damage the player
            if (Input.GetKeyDown(KeyCode.D)) {
                Debug.Log("Damage Key Pressed");
                entity.isPlayerDamaged = true;
            }

            // Check for H key to heal the player
            if (Input.GetKeyDown(KeyCode.H)) {
                Debug.Log("Heal Key Pressed");
                entity.isPlayerHealed = true;
            }
        }
    }
}
