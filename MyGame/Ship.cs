using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MyGame
{
    class Ship : GameObject
    {
        private readonly Sprite _sprite = new();
        private const float Speed = 0.8f;
        private const int FireDelay = 10;
        private int _fireTimer;
        private bool canFire = true;

        public Ship()
        {
            _sprite.Texture = Game.GetTexture("Resources/ship.png");
            _sprite.Position = new Vector2f(100, 100);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;
            float x = pos.X;
            float y = pos.Y;

            int msElapsed = elapsed.AsMilliseconds();

            if (x > Game.RenderWindow.Size.X) { x = 0; }
            if (x < 0) { x = 800; }
            if (y > Game.RenderWindow.Size.Y) { y = 0; }
            if (y < 0) { y = 800; }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) { x += Speed * msElapsed; }
            _sprite.Position = new Vector2f(x, y);

            if (_fireTimer > 0) { _fireTimer -= msElapsed; }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                if (canFire)
                {
                    _fireTimer = FireDelay;
                    FloatRect bounds = _sprite.GetGlobalBounds();
                    float laserX = x + bounds.Width;
                    float laserY = y + bounds.Height / 2.0f;
                    Laser laser = new Laser(new Vector2f(laserX, laserY));
                    Game.CurrentScene.AddGameObject(laser);
                    canFire = false;
                }
            }
            if (!Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                canFire = true;
            }
        }
    }
}