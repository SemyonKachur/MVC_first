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
            var startingBallInitialization = new StartingBallInitialization(startingBallFactory);

            var enemyFactory = new EnemyFactory(data.Enemy);
            CreateEnemies(enemyFactory, 5);

            var ball = startingBallInitialization.GetBall().gameObject.AddComponent<BallController>();
            ball.GetComponent<BallController>().SetPosition(playerInitialization.GetPlayer(), ball.transform);

            var enemyCounterFactory = new EnemyCounterFactory(data.EnemyCounter);
            var enemyCounterInitialization = new EnemyCounterInitialization(enemyCounterFactory, ball);
            enemyCounterInitialization.BonusInvoke += CreateBonus;

                void CreateBonus(int bonusType)
                {
                    var bonusFactory = new BonusFactory(data.BonusData);
                    var bonusInitialization = new BonusInitialization(bonusFactory, bonusType);
                }

            var bounceCounterFactory = new BounceCounterFactory(data.BounceCounter);
            var bounceCounterInitialization = new BounceCounterInitialization(bounceCounterFactory, ball);

            
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(backgroundInitialization);
            controllers.Add(framesInitialization);
            controllers.Add(centerInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput(), inputInitialization.GetStartButton()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player, data.Ball, inputInitialization.GetStartButton()));
            controllers.Add(new CameraController());
            controllers.Add(ball);
            controllers.Add(enemyCounterInitialization);
            controllers.Add(bounceCounterInitialization);
            //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
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
