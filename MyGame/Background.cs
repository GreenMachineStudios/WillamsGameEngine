using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class Background : GameObject
    {
        private const float ScrollSpeed = 4.0f;
        private readonly Sprite _sprite = new Sprite();

        public Background(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/background.png");
            _sprite.Position = pos;
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;

            if (pos.Y > Game.RenderWindow.Size.Y)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X, pos.Y + ScrollSpeed);
            }
        }
    }
}
