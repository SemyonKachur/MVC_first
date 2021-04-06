namespace Pinball_MVC
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}
