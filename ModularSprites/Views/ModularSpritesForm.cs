using Core;
using Core.Interfaces;
using Core.Models;
using Core.Views;
using ModularSprites.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModularSprites.Views
{
    public partial class ModularSpritesForm : BaseForm, IGameView
    {
        private IModularSpritesGame _game;

        public ModularSpritesForm(IModularSpritesGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }
    }
}
