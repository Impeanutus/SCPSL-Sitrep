using Exiled.API.Features;
using Exiled.API.Enums;
using System;
using System.Net.Http;
using System.Timers;

using Player = Exiled.Events.Handlers.Player;
using Map = Exiled.Events.Handlers.Map;
using Server = Exiled.Events.Handlers.Server;
using Sitrep_Remastered.Handelers;

namespace Sitrep_Remastered
{
    public class PluginMain : Plugin<Config>
    {
        private static readonly Lazy<PluginMain> LazyInstance = new Lazy<PluginMain>(valueFactory: () => new PluginMain());
        public static PluginMain Instance => LazyInstance.Value;

        public static readonly HttpClient client = new HttpClient();

        public Timer PlayerCountTimer;

        private Handelers.DeathHandeler DeathHandeler;
        private Handelers.JoinLeave JoinLeave;
        private Handelers.Decontamination Decontamination;
        private Handelers.RespawningHandeler RespawningHandeler;
        private Handelers.RoundHandeler RoundHandeler;
        private Handelers.BanHandeler BanHandeler;
        private Handelers.HurtingHandeler DemageHandeler;
        private Handelers.WaitingForPlayers WaitingForPlayersHandeler;
        private Handelers.CuffHandeler CuffHandeler;
        public override void OnEnabled()
        {
            DeathHandeler = new Handelers.DeathHandeler();
            JoinLeave= new Handelers.JoinLeave();
            Decontamination = new Handelers.Decontamination();
            RespawningHandeler = new Handelers.RespawningHandeler();
            RoundHandeler = new Handelers.RoundHandeler();
            BanHandeler = new Handelers.BanHandeler();
            DemageHandeler = new Handelers.HurtingHandeler();
            WaitingForPlayersHandeler = new Handelers.WaitingForPlayers();
            CuffHandeler = new Handelers.CuffHandeler();

            PlayerCountTimer = new Timer();
            PlayerCountTimer.Interval= 10000;
            PlayerCountTimer.Enabled= true;
            PlayerCountTimer.Elapsed += Handelers.PlayerCount.OnTimer;

            Enable();
        }

        public override void OnDisabled()
        {
            Disable();
        }


        public void Enable()
        {
            Player.Dying += DeathHandeler.OnDeath;
            Player.Verified += JoinLeave.OnJoin;
            Player.Left += JoinLeave.OnLeave;
            Map.Decontaminating += Decontamination.OnDecontamination;
            Server.RespawningTeam += RespawningHandeler.OnRespawn;
            Server.RoundStarted += RoundHandeler.OnRoundStart;
            Server.RoundEnded += RoundHandeler.OnRoundEnd;
            Player.Banning += BanHandeler.OnBan;
            Player.Hurting += DemageHandeler.OnHurt;
            Server.WaitingForPlayers += WaitingForPlayersHandeler.OnWaiting;
            Player.Handcuffing += CuffHandeler.OnCuff;
            Player.RemovingHandcuffs += CuffHandeler.OnUncuff;
            Player.Banned += BanHandeler.OnOfflineBan;
        }

        public void Disable()
        {
            Player.Dying -= DeathHandeler.OnDeath;
            Player.Verified -= JoinLeave.OnJoin;
            Player.Left -= JoinLeave.OnLeave;
            Map.Decontaminating -= Decontamination.OnDecontamination;
            Server.RespawningTeam -= RespawningHandeler.OnRespawn;
            Server.RoundStarted -= RoundHandeler.OnRoundStart;
            Server.RoundEnded -= RoundHandeler.OnRoundEnd;
            Player.Banning -= BanHandeler.OnBan;
            Player.Hurting -= DemageHandeler.OnHurt;
            Server.WaitingForPlayers -= WaitingForPlayersHandeler.OnWaiting;
            Player.Handcuffing -= CuffHandeler.OnCuff;
            Player.RemovingHandcuffs -= CuffHandeler.OnUncuff;
            Player.Banned -= BanHandeler.OnOfflineBan;
        }
    }
}
