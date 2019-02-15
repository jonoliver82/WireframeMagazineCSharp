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
    public partial class KeyboardForm : BaseForm
    {
        private readonly IKeyboardGame _keyboardGame;

        public KeyboardForm(IKeyboardGame keyboardGame)
            : base((IGame)keyboardGame)
        {
            InitializeComponent();
            _keyboardGame = keyboardGame;
        }

        private void KeyboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            _keyboardGame.KeyDown(e);
        }

        private void KeyboardForm_KeyUp(object sender, KeyEventArgs e)
        {
            _keyboardGame.KeyUp(e);
        }
    }
}
