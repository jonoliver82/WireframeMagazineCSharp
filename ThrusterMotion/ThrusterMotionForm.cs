using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThrusterMotion
{
    public partial class ThrusterMotionForm : Form
    {
        private Game _game;

        public ThrusterMotionForm()
        {
            InitializeComponent();
            _game = new Game();
            ClientSize = new Size(_game.Width, _game.Height);
        }

        private void ThrusterMotionForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _game.Render(e.Graphics);
        }

        private void ThrusterMotionForm_KeyDown(object sender, KeyEventArgs e)
        {
            _game.KeyDown(e);
        }

        private void ThrusterMotionForm_KeyUp(object sender, KeyEventArgs e)
        {
            _game.KeyUp(e);
        }
    }
}
