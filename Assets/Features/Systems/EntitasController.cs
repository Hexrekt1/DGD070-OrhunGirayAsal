using UnityEngine;
using Entitas;

public class EntitasController : MonoBehaviour {
    private Systems _systems; // Use Systems instead of Feature

    void Start() {
        // Create a shared instance of contexts
        var contexts = Contexts.sharedInstance;

        // Initialize the systems
        _systems = new Systems()
            .Add(new CreatePlayerHealthSystem(contexts))
            .Add(new CheckPlayerHealthSystem(contexts))
            .Add(new ChangePlayerHealthSystem(contexts));

        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
        _systems.Cleanup(); // Call Cleanup if needed
    }
}
