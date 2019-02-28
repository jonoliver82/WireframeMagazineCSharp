using Core.Interfaces;
using Core.Models;
using Core.Views;
using Missiles.Interfaces;
using System;
using System.Drawing;

namespace Missiles.Views
{
    public partial class MissileForm : BaseForm, IGameView
    {
        private IMissileGame _game;

        public MissileForm(IMissileGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _game.NewMissile();
        }
    }
}
