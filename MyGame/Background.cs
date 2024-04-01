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
        public readonly Sprite _sprite2 = new Sprite();

        public Background(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/background.png");
            _sprite2.Texture = Game.GetTexture("Resources/background.png");
            _sprite.Position = pos;
            pos.Y -= _sprite2.GetGlobalBounds().Height;
            _sprite2.Position = pos;
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
            Game.RenderWindow.Draw(_sprite2);
        }

        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;
            Vector2f pos2 = _sprite2.Position;

            if (pos.Y > Game.RenderWindow.Size.Y)
            {
                pos.Y = -_sprite.GetGlobalBounds().Height;
                _sprite.Position = pos;
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X, pos.Y + ScrollSpeed);
            }

            if (pos2.Y > Game.RenderWindow.Size.Y)
            {
                pos2.Y = -_sprite2.GetGlobalBounds().Height;
                _sprite2.Position = pos2;
            }
            else
            {
                _sprite2.Position = new Vector2f(pos2.X, pos2.Y + ScrollSpeed);
            }
        }
    }
}
