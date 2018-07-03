using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace JimboButton
{
    public static class Msgbox
    {
        static public async void Show(string msg, string title)
        {
            var dialog = new MessageDialog(msg, title);
            await dialog.ShowAsync();
        }
    }
}
