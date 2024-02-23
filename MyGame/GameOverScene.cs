using GameEngine;

namespace MyGame
{
    class GameOverScene : Scene
    {
        public GameOverScene(int score)
        {
            GameOverText gameOverText = new GameOverText(score);
            AddGameObject(gameOverText);
        }
    }
}