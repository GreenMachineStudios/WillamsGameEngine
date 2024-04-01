using GameEngine;
using SFML.Audio;
using SFML.System;

namespace MyGame
{
    class GameScene : Scene
    {
        private int _score;
        private int _lives = 3;
        Sound _music = new Sound();

        public GameScene()
        {
            _music.SoundBuffer = Game.GetSoundBuffer("Resources/gameMusic.wav");
            _music.Volume = 10;
            _music.Play();

            Ship ship = new();
            AddGameObject(ship);

            Spawner meteorSpawner = new Spawner();
            AddGameObject(meteorSpawner);

            Score score = new Score(new Vector2f(10f, 10f));
            AddGameObject(score);
        }

        public int GetScore()
        {
            return _score;
        }

        public void IncrementScore()
        {
            _score++;
        }

        public int GetLives()
        {
            return _lives;
        }

        public void DecrementLives()
        {
            _lives--;
            if (_lives == 0)
            {
                _music.Stop();
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }
    }
}