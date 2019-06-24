using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Views
{
    public partial class DefaultPyGameForm : Form
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly PyGame _game;

        private DateTime _lastUpdateTime;

        public DefaultPyGameForm(PyGame game, IDateTimeService dateTimeService)
        {
            InitializeComponent();

            _game = game;
            _dateTimeService = dateTimeService;

            ClientSize = new Size(game.Width, game.Height);
        }

        private void PyGameForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void ClearScreen(Graphics g)
        {
            g.Clear(Color.Black);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.DesignMode)
            {
                ClearScreen(e.Graphics);

                _game.Update(_dateTimeService.Now - _lastUpdateTime, e.Graphics);
                _game.Draw(e.Graphics);   
                         
                _lastUpdateTime = _dateTimeService.Now;
            }
        }

        private void DefaultPyGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            (_game as KeyboardPyGame)?.KeyDown(e.KeyCode);            
        }

        private void DefaultPyGameForm_KeyUp(object sender, KeyEventArgs e)
        {
            (_game as KeyboardPyGame)?.KeyUp(e.KeyCode);            
        }

        private void DefaultPyGameForm_MouseDown(object sender, MouseEventArgs e)
        {
            (_game as MousePyGame)?.MouseDown(e.X, e.Y);
        }

        private void DefaultPyGameForm_MouseMove(object sender, MouseEventArgs e)
        {
            (_game as MousePyGame)?.MouseMove(e.X, e.Y);
        }

        private void DefaultPyGameForm_MouseUp(object sender, MouseEventArgs e)
        {
            (_game as MousePyGame)?.MouseUp(e.X, e.Y);
        }
    }
}
