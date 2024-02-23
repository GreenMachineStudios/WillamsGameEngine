using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class Enemy : GameObject
    {
        private float _speed;

        private readonly Sprite _sprite = new Sprite();
         
        public Enemy(Vector2f pos, double speed)
        {
            SetCollisionCheckEnabled(true);

            _speed = (float)speed;
            _sprite.Texture = Game.GetTexture("Resources/invader.png");
            _sprite.Position = pos;
            AssignTag("enemy");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }

        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("laser"))
            {
                otherGameObject.MakeDead();
                Vector2f pos = _sprite.Position;
                pos.X = pos.X + (float)_sprite.GetGlobalBounds().Width / 2.0f;
                pos.Y = pos.Y + (float)_sprite.GetGlobalBounds().Height / 2.0f;
                Explosion explosion = new Explosion(pos);
                Game.CurrentScene.AddGameObject(explosion);
                MakeDead();
            }
        }

        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.Y > Game.RenderWindow.Size.Y)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X, pos.Y + _speed * msElapsed);
            }
        }
    }
}
