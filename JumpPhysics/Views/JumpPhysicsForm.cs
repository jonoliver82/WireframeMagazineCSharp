using Core;
using Core.Interfaces;
using Core.Models;
using Core.Views;
using JumpPhysics.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JumpPhysics.Views
{
    public partial class JumpPhysicsForm : KeyboardForm, IGameView
    {
        private IJumpPhysicsGame _game;

        public JumpPhysicsForm(IJumpPhysicsGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }
    }
}
