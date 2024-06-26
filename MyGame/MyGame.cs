﻿using GameEngine;

//Resource credits: pixabay, craftpix, and me

namespace MyGame
{
    static class MyGame
    {
        private const int WindowWidth = 800;
        private const int WindowHeight = 800;

        private const string WindowTitle = "Spacetalactica";

        private static void Main(string[] args)
        {
            // Initialize the game.
            Game.Initialize(WindowWidth, WindowHeight, WindowTitle);

            // Create our scene.
            GameScene scene = new GameScene();
            Game.SetScene(scene);

            // Run the game loop.
            Game.Run();
        }
    }
}