using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.Views
{
    public partial class ManagedForm : Form
    {
        private readonly IGame _game;

        protected ManagedForm()
        {
            // For designer only
        }

        public ManagedForm(IGame game)
        {
            _game = game;
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.DesignMode)
            {
                _game.Render(e.Graphics);
            }
        }
    }
}
