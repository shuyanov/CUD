using Zenject;

public class GameInstallerT : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameManager>().AsSingle();
    }
}