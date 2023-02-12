using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Sitrep_Remastered.Handelers
{
    internal class PlayerCount
    {
        public async static void OnTimer(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"count", Server.PlayerCount.ToString()},
                    {"maxcount", Server.MaxPlayerCount.ToString()},
                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync($"{PluginMain.IP}/PlayerCount", content);
            }
            catch (Exception err) 
            {
                Log.Error(err);
            }
        }
    }
}
