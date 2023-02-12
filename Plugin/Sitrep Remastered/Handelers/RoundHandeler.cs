using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sitrep_Remastered.Handelers
{
    internal class RoundHandeler
    {
        public async void OnRoundStart()
        {
            try
            {
                var values = new Dictionary<string, string>
                {

                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnRoundStart", content);
            }
            catch (Exception err)
            {
                Log.Error(err);
            }
        }

        public async void OnRoundEnd(RoundEndedEventArgs ev)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"vyhral", ev.LeadingTeam.ToString()}
                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnRoundEnd", content);
            }
            catch (Exception err)
            {
                Log.Error(err);
            }
        }
    }
}
