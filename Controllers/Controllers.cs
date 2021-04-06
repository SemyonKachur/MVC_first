using System.Collections.Generic;

namespace Pinball_MVC
{
    internal sealed class Controllers : IInitialization, IExecute, ICleanup
    {
        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _cleanupControllers = new List<ICleanup>();
        }
        internal Controllers Add(IController controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Add(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }
        public void Initialization()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }
        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }
    }
} 