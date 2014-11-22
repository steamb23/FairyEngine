using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using w = System.Windows.Forms;

namespace SteamB23.FairyEngine
{
    public static class MessageBox
    {
        public static void GetServiceError(object sender,Type target, string message, Microsoft.Xna.Framework.Game game)
        {
            //System.Media.SystemSounds.Exclamation.Play();
            w.MessageBox.Show(
                sender.ToString() + "가 " + target + "서비스를 가져오는데 실패했습니다. " + message, game.Window.Title+" - 오류",w.MessageBoxButtons.OK,w.MessageBoxIcon.Error);
        }
    }
}
