using Core;
using Core.Interfaces;
using Core.Models;
using Core.Views;
using Explosion.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Explosion.Views
{
    public partial class ExplosionForm : BaseForm, IGameView
    {
        private IExplosionGame _game;

        public ExplosionForm(IExplosionGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }

        private void timerExplode_Tick(object sender, EventArgs e)
        {
            _game.ExplodeRandom();
        }
    }
}
