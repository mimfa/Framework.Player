using MiMFa.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiMFa.UIL.Player
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        public void Show(string path)
        {
            if (ViewBox.Open(path)) SourcePanel.Hide();
            base.Show();
        }
        public void Show(object source)
        {
            if (ViewBox.Open(source)) SourcePanel.Hide();
            SourcePanel.Hide();
            base.Show();
        }
        public DialogResult ShowDialog(string path)
        {
            if (ViewBox.Open(path)) SourcePanel.Hide();
            return base.ShowDialog();
        }
        public DialogResult ShowDialog(object source)
        {
            if (ViewBox.Open(source)) SourcePanel.Hide();
            SourcePanel.Hide();
            return base.ShowDialog();
        }

        private void EverythingPlayer_Load(object sender, EventArgs e)
        {

        }

        private void btn_SelectPath_Click(object sender, EventArgs e)
        {
            ViewBox.Open((tb_SelectPath.Text =
                InfoService.IsFile(tb_SelectPath.Text, false) ?
                    DialogService.OpenFile(tb_SelectPath.Text) :
                        InfoService.IsDirectory(tb_SelectPath.Text, false) ?
                            DialogService.OpenDirectory(tb_SelectPath.Text)
                            : string.IsNullOrWhiteSpace(tb_SelectPath.Text)?
                                DialogService.OpenFile()
                                :tb_SelectPath.Text));
        }

        private void tb_SelectPath_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ViewBox.Open(tb_SelectPath.Text);
                    break;
                case Keys.Escape:
                    tb_SelectPath.Clear();
                    break;
            }
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            ViewBox.Open(tb_SelectPath.Text);
        }
    }
}
