using Entitas;
using UnityEngine;

public class CheckPlayerHealthSystem : IExecuteSystem {
    private readonly IGroup<GameEntity> _playerGroup;

    public CheckPlayerHealthSystem(Contexts contexts) {
        _playerGroup = contexts.game.GetGroup(GameMatcher.PlayerHealth);
    }

    public void Execute() {
        foreach (var entity in _playerGroup.GetEntities()) {
            if (entity.isPlayerDamaged) {
                entity.ReplacePlayerHealth(Mathf.Max(entity.playerHealth.Value - 10, 0));
                entity.isPlayerDamaged = false;
            }

            if (entity.isPlayerHealed) {
                entity.ReplacePlayerHealth(Mathf.Min(entity.playerHealth.Value + 10, 100));
                entity.isPlayerHealed = false;
            }
        }
    }
}
