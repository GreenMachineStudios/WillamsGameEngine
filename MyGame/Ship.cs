using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace MyGame
{
    class Ship : GameObject
    {
        private readonly Sprite _sprite = new();
        private const float Speed = 0.4f;
        private const int FireDelay = 10;
        private int _fireTimer;
        private bool canFire = true;
        private bool twoFireMode = false;

        public Ship()
        {
            SetCollisionCheckEnabled(true);
            _sprite.Texture = Game.GetTexture("Resources/ship.png");
            _sprite.Position = new Vector2f((Game.RenderWindow.Size.X - _sprite.GetGlobalBounds().Width) / 2, 720);
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }

        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("enemy"))
            {
                GameScene scene = (GameScene)Game.CurrentScene;
                Vector2f pos = _sprite.Position;
                pos.X = pos.X + (float)_sprite.GetGlobalBounds().Width / 2.0f;
                pos.Y = pos.Y + (float)_sprite.GetGlobalBounds().Height / 2.0f;
                Explosion explosion = new Explosion(pos);
                Game.CurrentScene.AddGameObject(explosion);
                scene.DecrementLives();
            }
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

            //if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) { y -= Speed * msElapsed; }
            //if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) { y += Speed * msElapsed; }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) { x += Speed * msElapsed; }

            if (x < 0) { x = 0; }
            if (x > Game.RenderWindow.Size.X - _sprite.GetGlobalBounds().Width) { x = Game.RenderWindow.Size.X - _sprite.GetGlobalBounds().Width - 4; }

            _sprite.Position = new Vector2f(x, y);

            if (_fireTimer > 0) { _fireTimer -= msElapsed; }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                if (canFire)
                {
                    _fireTimer = FireDelay;
                    FloatRect bounds = _sprite.GetGlobalBounds();
                    if (twoFireMode)
                    {
                        float laserX = x + 6;
                        float laserY = y + 20;
                        Laser laser = new Laser(new Vector2f(laserX, laserY));
                        Game.CurrentScene.AddGameObject(laser);

                        laserX = x + bounds.Width - 18;
                        laserY = y + 20;
                        laser = new Laser(new Vector2f(laserX, laserY));
                        Game.CurrentScene.AddGameObject(laser);
                    }
                    else
                    {
                        float laserX = x + bounds.Width / 2.0f - 5;
                        float laserY = y;
                        Laser laser = new Laser(new Vector2f(laserX, laserY));
                        Game.CurrentScene.AddGameObject(laser);
                    }
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