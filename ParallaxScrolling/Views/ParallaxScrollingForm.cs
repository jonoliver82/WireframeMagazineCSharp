using Core;
using Core.Interfaces;
using Core.Models;
using Core.Views;
using ParallaxScrolling.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallaxScrolling.Views
{
    public partial class ParallaxScrollingForm : BaseForm, IGameView
    {
        private IParallaxScrollingGame _game;

        public ParallaxScrollingForm(IParallaxScrollingGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }
    }
}
