using Exiled.Events.EventArgs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sitrep_Remastered.Handelers
{
    internal class RespawningHandeler
    {
        public async void OnRespawn (RespawningTeamEventArgs ev)
        {
            try
            {

                var values = new Dictionary<string, string>
                {
                    {"team", ev.NextKnownTeam.ToString() },
                    {"count", ev.Players.Count.ToString()}
                };

                var content = new FormUrlEncodedContent(values);

                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnRespawn", content);
            }
            catch
            {

            }
        }

    }
}
