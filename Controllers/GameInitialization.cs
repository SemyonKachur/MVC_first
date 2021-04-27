using UnityEngine;

namespace Pinball_MVC
{
    internal sealed class GameInitialization
    {
        private readonly CounterInitialization _counterInitialization;

        private float _scaler = 5.625f;
        public GameInitialization(Controllers controllers, Data data)
        {
            var cameraController = new CameraController();
            var inputInitialization = new InputInitialization();

            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory, data.Player.Position);

            var backgroundFactory = new BackgroundFactory(data.Background);
            var backgroundInitialization = new BackgroundInitialzation(backgroundFactory, backgroundFactory._backgroundData.Position);

            var framesFactory = new FramesFactory(data.Frames);
            var framesInitialization = new FramesInitialization(framesFactory);

            var centerFactory = new CenterFactory(data.Center);
            var centerInitialization = new CenterInitialization(centerFactory, centerFactory._centerData.Position);

            var startingBallFactory = new StartingBallFactory(data.Ball);
            var startingBallInitialization = new StartingBallInitialization(startingBallFactory);

            var enemyFactory = new EnemyFactory(data.Enemy);
            CreateEnemies(enemyFactory,5);

            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(backgroundInitialization);
            controllers.Add(framesInitialization);
            controllers.Add(centerInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput(),inputInitialization.GetStartButton()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player, data.Ball, inputInitialization.GetStartButton()));

            var ball = startingBallInitialization.GetBall().gameObject.AddComponent<BallController>();
            ball.transform.position = new Vector2(0, Screen.width / _scaler);
            ball.transform.parent = playerInitialization.GetPlayer();
            controllers.Add(new CameraController());
            //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
            //controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer()));
            //controllers.Add(enemyInitialization);

            var counterFactory = new CounterFactory(data.Counter);
            _counterInitialization = new CounterInitialization(counterFactory,ball);
        }

        private void CreateEnemies(EnemyFactory enemy, int number)
        {
            for(int i = 0; i < number; i++)
            {
                var enemyInitializatoin = new EnemyInitialization(enemy);
            }
        }
    }
}
