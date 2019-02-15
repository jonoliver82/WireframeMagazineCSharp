using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Core.Views
{
    public partial class MouseForm : BaseForm
    {
        private readonly IMouseGame _mouseGame;

        public MouseForm(IMouseGame mouseGame)
            : base((IGame)mouseGame)
        {
            InitializeComponent();
            _mouseGame = mouseGame;
        }

        private void MouseForm_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseGame.MouseDown(e.X, e.Y);
        }

        private void MouseForm_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseGame.MouseUp(e.X, e.Y);
        }

        private void MouseForm_MouseMove(object sender, MouseEventArgs e)
        {
            _mouseGame.MouseMove(e.X, e.Y);
        }
    }
}
