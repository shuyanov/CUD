using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject]
    private GManager _gameManager;
    
    void Start()
    {
        _gameManager.StartGame();
    }
}
