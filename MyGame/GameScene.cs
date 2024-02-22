using GameEngine;

namespace MyGame
{
    class GameScene : Scene
    {
        public GameScene()
        {
            Ship ship = new();
            AddGameObject(ship);
        }
    }
}