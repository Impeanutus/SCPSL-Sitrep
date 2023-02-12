using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sitrep_Remastered.Handelers
{
    internal class JoinLeave
    {

        public async void OnJoin(VerifiedEventArgs ev) 
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"Player", ev.Player.Nickname.ToString() },
                    {"PlayerId", ev.Player.UserId.ToString() },
                    {"PlayerIp", ev.Player.IPAddress.ToString() },
                };

                var content = new FormUrlEncodedContent(values);

                await PluginMain.client.PostAsync($"{PluginMain.IP}/OnJoin", content);
            }
            catch (Exception ex) 
            {
                Log.Error(ex);
            }
        }

        public async void OnLeave(LeftEventArgs ev)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"Player", ev.Player.Nickname.ToString() },
                    {"PlayerId", ev.Player.UserId.ToString() },
                    {"PlayerIp", ev.Player.IPAddress.ToString() },
                };

                var content = new FormUrlEncodedContent(values);

                await PluginMain.client.PostAsync($"{PluginMain.IP}/OnLeave", content);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
