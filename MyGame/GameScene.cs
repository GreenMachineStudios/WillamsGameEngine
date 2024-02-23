using GameEngine;
using SFML.Audio;
using System.Runtime.CompilerServices;

namespace MyGame
{
    class GameScene : Scene
    {
        public GameScene()
        {
            Sound _music = new Sound();
            _music.SoundBuffer = Game.GetSoundBuffer("Resources/gameMusic.wav");
            _music.Volume = 10;
            _music.Play();

            Ship ship = new();
            AddGameObject(ship);

            Spawner meteorSpawner = new Spawner();
            AddGameObject(meteorSpawner);
        }
    }
}