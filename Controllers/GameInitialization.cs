using UnityEngine;

namespace Pinball_MVC
{
    internal sealed class GameInitialization
    {
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
            var startingBallInitialization = new StartingBallInitialization(startingBallFactory, playerInitialization.GetPlayer(),startingBallFactory._ballData.Position);

            var enemyFactory = new EnemyFactory(data.Enemy);
            var enemyInitializatoin = new EnemyInitialization(enemyFactory);

            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(backgroundInitialization);
            controllers.Add(framesInitialization);
            controllers.Add(centerInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput(),inputInitialization.GetStartButton()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player, data.Ball, inputInitialization.GetStartButton()));
            controllers.Add(new StartingBallController(playerInitialization.GetPlayer(), startingBallInitialization.GetBall()));
            controllers.Add(new CameraController());
            //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
            //controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer()));
            //controllers.Add(enemyInitialization);

        }
    }
}
