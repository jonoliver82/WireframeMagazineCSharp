// **********************************************************************************
// Filename					- Spaceship.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SpriteFollowingPyGame.Models
{
    public class Spaceship
    {
        private Queue<Point> _previousPositions;

        public Spaceship(Point startPosition, Image sprite, int speed)
        {
            Position = startPosition;
            Sprite = sprite;
            Speed = speed;

            _previousPositions = new Queue<Point>();
        }

        public Image Sprite { get; private set; }

        public int Speed { get; private set; }

        public Point Position { get; private set; }

        public void PopulateDefaultPreviousPositions()
        {
            for (int i = 0; i < 100; i++)
            {
                _previousPositions.Enqueue(new Point(Position.X - (i * Speed), Position.Y));
            }
        }

        public void StorePosition()
        {
            // Note python implementation is:
            // previouspositions = [(spaceship.x, spaceship.y)] +previouspositions[:99]
            _previousPositions.Dequeue();
            _previousPositions.Enqueue(Position);
        }

        public Point PreviousPosition(int index)
        {
            // Note this is an O(n) opertion to access the queue
            return _previousPositions.ElementAt(index);
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
