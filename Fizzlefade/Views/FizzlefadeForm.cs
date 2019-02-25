using Core.Interfaces;
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
using Fizzlefade.Interfaces;
using Core.Models;

namespace Fizzlefade.Views
{
    public partial class FizzlefadeForm : BaseForm, IGameView
    {
        private IFizzlefadeGame _game;

        public FizzlefadeForm(IFizzlefadeGame game, RenderInformation renderInformation)
            : base(game)
        {
            InitializeComponent();
            _game = game;
            ClientSize = new Size(renderInformation.Width, renderInformation.Height);
        }
    }
}
