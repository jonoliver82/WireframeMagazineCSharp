using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Interfaces;

namespace Core.Views
{
    public partial class BaseForm : Form
    {
        private readonly IGame _game;

        protected BaseForm()
        {
            // For designer only
        }

        public BaseForm(IGame game)
        {
            _game = game;
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
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
                _game.Render(e.Graphics);
            }
        }
    }
}
