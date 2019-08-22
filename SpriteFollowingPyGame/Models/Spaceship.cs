// **********************************************************************************
// Filename					- Spaceship.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Collections.Generic;
using System.Drawing;

namespace SpriteFollowingPyGame.Models
{
    public class Spaceship
    {
        private List<Point> _previousPositions;

        public Spaceship(Point startPosition, Image sprite, int speed)
        {
            Position = startPosition;
            Sprite = sprite;
            Speed = speed;

            _previousPositions = new List<Point>();
        }

        public Image Sprite { get; private set; }

        public int Speed { get; private set; }

        public Point Position { get; private set; }

        public void PopulateDefaultPreviousPositions()
        {
            for (int i = 0; i < 100; i++)
            {
                _previousPositions.Add(new Point(Position.X - (i * Speed), Position.Y));
            }
        }

        public void StorePosition()
        {
            // TODO add the current position to the list of previous positions
            // and ensure the list contains at most 100 positions
            // Avoid recreating the list...
            _previousPositions.Add(Position);
        }

        public Point PreviousPosition(int index)
        {
            return _previousPositions[index];
        }

        public void MoveUp()
        {
            Position = new Point(Position.X, Position.Y - Speed);
        }

        public void MoveDown()
        {
            Position = new Point(Position.X, Position.Y + Speed);
        }

        public void MoveLeft()
        {
            Position = new Point(Position.X - Speed, Position.Y);
        }

        public void MoveRight()
        {
            Position = new Point(Position.X + Speed, Position.Y);
        }
    }
}
