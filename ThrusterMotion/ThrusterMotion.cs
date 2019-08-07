using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using System.Drawing;
using ThrusterMotion.Models;
using System.Windows.Forms;

namespace ThrusterMotion
{
    public class ThrusterMotion : KeyboardPyGame
    {
        private const int WIDTH = 640;
        private const int HEIGHT = 480;

        private Spaceship _spaceship;

        // TODO move to Spaceship
        private Point _startPosition;

        public ThrusterMotion(ITimerFactory timerFactory, ISpriteService spriteService)
            : base(WIDTH, HEIGHT, timerFactory)
        {
            // TODO move to factory
            _spaceship = new Spaceship
            {
                Acceleration = 0.01,
                Angle = 0,
                NormalImage = spriteService.LoadImage("spaceship.png"),
                ThrustImage = spriteService.LoadImage("spaceship-thrust.png"),
                TurnSpeed = 0.5f,
                XSpeed = 0,
                YSpeed = 0,
            };

            _startPosition = new Point((WIDTH / 2) - (_spaceship.NormalImage.Width / 2), (HEIGHT / 2) - (_spaceship.NormalImage.Height / 2));
            _spaceship.Position = _startPosition;
            _spaceship.CurrentImage = _spaceship.NormalImage;
        }

        public override void Draw(Graphics g)
        {
            var rotated = Rotate(_spaceship.CurrentImage, _spaceship.Angle);
            g.DrawImage(rotated, _spaceship.Position);
        }

        public override void Update(TimeSpan timeSinceLastUpdate, Graphics g)
        {
            // save the spaceship's current angle, as changing the actor's image resets the angle to 0
            var newAngle = _spaceship.Angle;

            // rotate left on left arrow press
            if (KeyboardState[Keys.A] || KeyboardState[Keys.Left])
            {
                newAngle -= _spaceship.TurnSpeed;
            }

            // rorate right on right arrow press
            if (KeyboardState[Keys.D] || KeyboardState[Keys.Right])
            {
                newAngle += _spaceship.TurnSpeed;
            }

            // accelerate forwards on up arrow press
            // and change displayed image
            if (KeyboardState[Keys.W] || KeyboardState[Keys.Up])
            {
                _spaceship.CurrentImage = _spaceship.ThrustImage;
                _spaceship.XSpeed += Math.Cos(_spaceship.Angle * (Math.PI / 180.0)) * _spaceship.Acceleration;
                _spaceship.YSpeed += Math.Sin(_spaceship.Angle * (Math.PI / 180.0)) * _spaceship.Acceleration;
            }
            else
            {
                _spaceship.CurrentImage = _spaceship.NormalImage;
            }

            if (KeyboardState[Keys.R])
            {
                _spaceship.Position = _startPosition;
                _spaceship.XSpeed = 0;
                _spaceship.YSpeed = 0;
                _spaceship.Angle = 0;
            }

            // Set the new angle
            _spaceship.Angle = newAngle;

            // Use the x and y speed to update the spaceship position
            // subtract the y speed as co-ordinates go from top to bottom
            var newXPosition = (int)(_spaceship.Position.X + _spaceship.XSpeed);
            var newYPosition = (int)(_spaceship.Position.Y + _spaceship.YSpeed);
            _spaceship.Position = new Point(newXPosition, newYPosition);
        }

        // TODO Move to core/graphics service
        private Bitmap Rotate(Image source, float angle)
        {
            // create a new empty bitmap to hold rotated image
            Bitmap result = new Bitmap(source.Width, source.Height);

            // make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(result))
            {
                // move rotation point to center of image
                g.TranslateTransform((float)source.Width / 2, (float)source.Height / 2);

                g.RotateTransform(angle);

                // move image back
                g.TranslateTransform(-(float)source.Width / 2, -(float)source.Height / 2);

                // draw passed in image onto graphics object
                g.DrawImage(source, new Point(0, 0));
            }

            return result;
        }
    }
}
