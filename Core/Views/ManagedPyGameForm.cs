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
    public partial class ManagedPyGameForm : Form
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly PyGame _game;

        private DateTime _lastUpdateTime;

        public ManagedPyGameForm(PyGame game, IDateTimeService dateTimeService)
        {
            InitializeComponent();

            _game = game;
            _dateTimeService = dateTimeService;

            ClientSize = new Size(game.Width, game.Height);
        }

        private void PyGameForm_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            using (var graphics = Graphics.FromHwnd(this.Handle))
            {
                _game.Update(_dateTimeService.Now - _lastUpdateTime, graphics);
                _game.Draw(graphics);
            }

            _lastUpdateTime = _dateTimeService.Now;
        }
    }
}
