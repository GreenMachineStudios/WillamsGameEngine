using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;

namespace MyGame
{
    class Spawner : GameObject
    {
        private const int SpawnDelay = 900;

        private int _timer;

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;

            if (_timer <= 0)
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;

                float meteorX = Game.Random.Next(0, 750);

                float meteorY = 1;

                Enemy meteor = new Enemy(new Vector2f(meteorX, meteorY), (Game.Random.Next(1, 3) * 0.1));
                Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}