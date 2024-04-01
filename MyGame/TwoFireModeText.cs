using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class TwoFireModeText : GameObject
    {
        private readonly Text _text = new Text();

        public TwoFireModeText(Vector2f pos)
        {
            _text.Font = Game.GetFont("Resources/Courneuf-Regular.ttf");
            _text.Position = pos;
            _text.CharacterSize = 24;
            _text.FillColor = Color.Yellow;
            AssignTag("modeText");
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_text);
        }

        public override void Update(Time elapsed)
        {
            if (Ship.twoFireMode)
            {
                _text.DisplayedString = "!!TWO FIRE MODE!!";
            }
            else
            {
                _text.DisplayedString = "";
            }

        }
    }
}
