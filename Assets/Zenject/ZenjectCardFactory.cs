using UnityEngine;
using Zenject;

public class ZenjectCardFactory : MonoBehaviour
{
    [Inject]
    private GameManager _gameManager;

    void Start()
    {
        // _gameManager.Start();
    }
}