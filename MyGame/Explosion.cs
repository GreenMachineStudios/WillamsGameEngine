using GameEngine;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
namespace MyGame
{
    class Explosion : AnimatedSprite
    {
        private readonly Sound _boom = new Sound();

        public Explosion(Vector2f pos) : base(pos)
        {
            Texture = Game.GetTexture("Resources/explosion-spritesheet.png");
            SetUpExplosionAnimation();
            PlayAnimation("explosion", AnimationMode.OnceForwards);

            _boom.SoundBuffer = Game.GetSoundBuffer("Resources/silentboom.wav");
            _boom.Volume = 100;
            _boom.Play();
        }
        public override void Update(Time elapsed)
        {
            base.Update(elapsed);
            if (!IsPlaying())
            {
                MakeDead();
            }
        }
        private void SetUpExplosionAnimation()
        {
            var frames = new List<IntRect>
              { new IntRect( 1, 1, 256, 256), 
                new IntRect( 259, 1, 256, 256),
                new IntRect(517, 1, 256, 256),
                new IntRect(775, 1, 256, 256),
                new IntRect(1033, 1, 256, 256),
                new IntRect(1291, 1, 256, 256),
                new IntRect(1549, 1, 256, 256),
                new IntRect(1807, 1, 256, 256),
                new IntRect(2065, 1, 256, 256),
                new IntRect(2323, 1, 256, 256)
               };
            AddAnimation("explosion", frames);
        }
    }
}