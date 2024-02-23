using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
namespace MyGame
{
    class Laser : GameObject
    {
        private readonly Sound _zap = new Sound();
        private const float Speed = 1.2f;
        private readonly Sprite _sprite = new Sprite();

        public Laser(Vector2f pos)
        {
            _zap.SoundBuffer = Game.GetSoundBuffer("Resources/laser.wav");
            _zap.Volume = 50;
            _zap.Play();

            _sprite.Texture = Game.GetTexture("Resources/laser.png");
            _sprite.Position = pos;
            AssignTag("laser");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.Y < 0)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X, pos.Y - Speed * msElapsed);
            }
        }
    }
}