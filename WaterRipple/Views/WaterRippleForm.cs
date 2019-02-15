using Core;
using Core.Interfaces;
using Core.Models;
using Core.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterRipple.Interfaces;

namespace WaterRipple.Views
{
    public partial class WaterRippleForm :  MouseForm, IGameView
    {
        private IWaterRippleGame _game;

        public WaterRippleForm(IWaterRippleGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            _game.SplashRandom();
        }
    }
}
