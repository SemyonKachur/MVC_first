namespace Pinball_MVC
{
    public interface IInteractable : IInitialization
    {
        bool IsInteractable { get; }
    }
}
