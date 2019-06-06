using Core.Interfaces;
using Core.Models;
using Core.Views;
using Invaders.Interfaces;
using System;
using System.Drawing;

namespace Invaders.Views
{
    public partial class InvadersForm : ManagedForm, IGameView
    {
        private IInvadersGame _game;

        public InvadersForm(IInvadersGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }

        private void shotTimer_Tick(object sender, EventArgs e)
        {
            _game.CreateRandomShot();
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            using (var g = Graphics.FromHwnd(this.Handle))
            {
                _game.Render(g);
            }
        }
    }
}
