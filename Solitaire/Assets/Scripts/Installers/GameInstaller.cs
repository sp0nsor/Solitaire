using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IDeckView>().To<DeckView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ICardContainer>().To<CardContainer>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ISpriteLoader>().To<SpriteLoader>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ICardFactory>().To<CardFactory>().FromComponentInHierarchy().AsSingle();
    }
}
