using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Core.Views;
using Core.Models;
using Core.Interfaces;
using DoomFire.Interfaces;

namespace DoomFire.Views
{
    public partial class DoomFireForm : BaseForm, IGameView
    {
        private IDoomFireGame _game;

        public DoomFireForm(IDoomFireGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }
    }
}
