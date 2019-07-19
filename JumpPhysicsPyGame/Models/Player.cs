// **********************************************************************************
// Filename					- Player.cs
// Copyright (c) jonoliver82, 2019
// **********************************************************************************

using Core.Models;
using System.Drawing;

namespace JumpPhysicsPyGame.Models
{
    public class Player
    {
        public Player(Point position, Image sprite, Size size, double jumpVelocity, Velocity velocity, double gravity)
        {
            Position = position;
            Sprite = sprite;
            Size = size;
            JumpVelocity = jumpVelocity;
            Velocity = velocity;
            Gravity = gravity;
        }

        public Image Sprite { get; }

        public Point Position { get; set; }

        public Size Size { get; }

        public Velocity Velocity { get; }

        public double JumpVelocity { get; }

        public double Gravity { get; }

        public void UpdateVelocityForGravity()
        {
            Velocity.Y += Gravity;
        }

        public void UpdateVelocityForJumpOnGround()
        {
            Velocity.Y = JumpVelocity;
        }

        public void HandleVerticalCollision()
        {
            Velocity.Y = 0.0;
        }
    }
}
