using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sitrep_Remastered.Handelers
{
    internal class CuffHandeler
    {
        public async void OnCuff(HandcuffingEventArgs ev)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"Cuffed", ev.Target.Nickname },
                    {"CuffedId", ev.Target.UserId },
                    {"CuffedRole", ev.Target.Role.Name },
                    {"Player", ev.Player.Nickname },
                    {"PlayerId", ev.Player.UserId },
                    {"PlayerRole", ev.Player.Role.Name }
                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync($"{PluginMain.IP}/OnCuff", content);
            }
            catch (Exception ex)
            {

            }
        }

        public async void OnUncuff(RemovingHandcuffsEventArgs ev)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"Cuffed", ev.Target.Nickname },
                    {"CuffedId", ev.Target.UserId },
                    {"CuffedRole", ev.Target.Role.Name },
                    {"Player", ev.Player.Nickname },
                    {"PlayerId", ev.Player.UserId },
                    {"PlayerRole", ev.Player.Role.Name }
                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync($"{PluginMain.IP}/OnUnCuff", content);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
