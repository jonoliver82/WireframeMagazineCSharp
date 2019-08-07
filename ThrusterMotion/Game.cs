using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ThrusterMotion
{
    public class Game
    {
        private RenderInformation _renderInfo;
        private Spaceship _spaceship;
        protected Dictionary<Keys, bool> _keys;
        private Point _startPosition;

        public Game()
        {
            _renderInfo = new RenderInformation
            {
                Height = 480,
                Width = 640,
            };

            _spaceship = new Spaceship
            {
                Acceleration = 0.01,
                Angle = 0,
                NormalImage = Bitmap.FromFile("spaceship.png"),
                ThrustImage = Bitmap.FromFile("spaceship-thrust.png"),
                TurnSpeed = 0.5f,
                XSpeed = 0,
                YSpeed = 0,
            };

            _startPosition = new Point((_renderInfo.Width / 2) - (_spaceship.NormalImage.Width / 2), (_renderInfo.Height / 2) - (_spaceship.NormalImage.Height / 2));
            _spaceship.Position = _startPosition;
            _spaceship.CurrentImage = _spaceship.NormalImage;

            _keys = new Dictionary<Keys, bool>
            {
                { Keys.W, false },
                { Keys.A, false },
                { Keys.S, false },
                { Keys.D, false },
                { Keys.Up, false },
                { Keys.Down, false },
                { Keys.Left, false },
                { Keys.Right, false },
                { Keys.R, false },
            };
        }

        public void Render(Graphics g)
        {
            ClearScreen(g);
            Update();
            Draw(g);
        }

        public void KeyDown(KeyEventArgs e)
        {
            _keys[e.KeyCode] = true;
        }

        public void KeyUp(KeyEventArgs e)
        {
            _keys[e.KeyCode] = false;
        }

        private void ClearScreen(Graphics g)
        {
            g.Clear(Color.Black);
        }

        private void Update()
        {
            // save the spaceship's current angle, as changing the actor's image resets the angle to 0
            var newAngle = _spaceship.Angle;

            // rotate left on left arrow press
            if (_keys[Keys.A] || _keys[Keys.Left])
            {
                newAngle -= _spaceship.TurnSpeed;
            }

            // rorate right on right arrow press
            if (_keys[Keys.D] || _keys[Keys.Right])
            {
                newAngle += _spaceship.TurnSpeed;
            }

            // accelerate forwards on up arrow press
            // and change displayed image
            if (_keys[Keys.W] || _keys[Keys.Up])
            {
                _spaceship.CurrentImage = _spaceship.ThrustImage;
                _spaceship.XSpeed += Math.Cos(_spaceship.Angle * (Math.PI / 180.0)) * _spaceship.Acceleration;
                _spaceship.YSpeed += Math.Sin(_spaceship.Angle * (Math.PI / 180.0)) * _spaceship.Acceleration;
            }
            else
            {
                _spaceship.CurrentImage = _spaceship.NormalImage;
            }

            if (_keys[Keys.R])
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
            _spaceship.Position = new Point(newXPosition, newXPosition);
        }

        private void Draw(Graphics g)
        {
            var rotated = Rotate(_spaceship.CurrentImage, _spaceship.Angle);
            g.DrawImage(rotated, _spaceship.Position);
        }

        private Bitmap Rotate(Image source, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap result = new Bitmap(source.Width, source.Height);

            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(result))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)source.Width / 2, (float)source.Height / 2);

                g.RotateTransform(angle);

                //move image back
                g.TranslateTransform(-(float)source.Width / 2, -(float)source.Height / 2);

                //draw passed in image onto graphics object
                g.DrawImage(source, new Point(0, 0));
            }
            return result;
        }

        public int Width => _renderInfo.Width;

        public int Height => _renderInfo.Height;
    }
}
