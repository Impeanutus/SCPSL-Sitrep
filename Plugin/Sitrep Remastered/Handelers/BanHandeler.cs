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
    internal class BanHandeler
    {
        public async void OnBan(BanningEventArgs ev)
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    {"Admin", ev.Player.Nickname },
                    {"AdminId", ev.Player.UserId },
                    {"Target", ev.Target.Nickname },
                    {"TargetId", ev.Player.UserId },
                    {"Reason", ev.Reason },
                    {"Time", ev.Duration.ToString() }
                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnBan", content);
            }
            catch (Exception err) 
            {
                Log.Error(err);
            }
        }

        public async void OnOfflineBan(BannedEventArgs ev)
        {
            try
            {
                if (ev.Details.OriginalName == "Unknown - offline ban")
                {
                    if (ev.Type == BanHandler.BanType.UserId)
                    {
                        var values = new Dictionary<string, string>
                         {
                            {"Admin", ev.Player.Nickname },
                            {"AdminId", ev.Player.UserId },
                            {"TargetId", ev.Target.UserId },
                            {"Reason", ev.Details.Reason },
                            {"Time", new DateTime(ev.Details.Expires).ToString("dd;MM;yy, HH:mm:ss")}
                         };

                        var content = new FormUrlEncodedContent(values);

                        await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnOfflineBan", content);
                    }
                }
            }
            catch
            {

            }
        }

    }
}
