using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class LifeCounter : GameObject
    {
        private readonly Text _text = new Text();

        public LifeCounter(Vector2f pos)
        {
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = pos;
            _text.CharacterSize = 24;
            _text.FillColor = Color.Red;
            AssignTag("lifeCounter");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
        }

        public override void Update(Time elapsed)
        {
            GameScene scene = (GameScene)Game.CurrentScene;
            _text.DisplayedString = "Lives Left: " + scene.GetLives();
        }
    }
}
