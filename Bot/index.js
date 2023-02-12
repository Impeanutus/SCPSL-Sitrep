const express = require("express");
const app = express();
var bodyParser = require('body-parser');
const { Client, GatewayIntentBits } = require('discord.js');
const DeathHandeler = require("./Handelers/DeathHandeler")
const JoinLeaveHandeler = require("./Handelers/JoinLeaveHandeler")
const DecontaminationHandeler = require("./Handelers/DecontaminationHandeler")
const RespawnHandeler = require("./Handelers/RespawnHandelers")
const RoundHandeler = require("./Handelers/RoundHandeler")
const PlayerCountHandeler = require("./Handelers/PlayerCountHandeler")
const BanHandeler = require("./Handelers/BanHandeler")
const HurtingHandeler = require("./Handelers/HurtingHandeler")
const WaitingForPlayerHandeler = require("./Handelers/WaitingForPlayerHandeler")
const CuffHandeler = require("./Handelers/CuffHandeler")

const client = new Client({ intents: [GatewayIntentBits.Guilds] });

app.use(bodyParser.urlencoded({ extended: true }));

app.listen(6868, async function(){
    console.log(`Aplikace naslouchá na portu 6868`)
});

app.post("/OnDeath", async function (req, res){
    DeathHandeler.OnDeath(req, res, client)
})

app.post("/OnJoin", async function (req, res){
    JoinLeaveHandeler.OnJoin(req, res, client)
})

app.post("/OnLeave", async function (req, res){
    JoinLeaveHandeler.OnLeave(req, res, client)
})

app.post("/OnDecontamination", async function (req, res){
    DecontaminationHandeler.OnDecontamination(req, res, client)
})

app.post("/OnRespawn", async function (req, res){
    RespawnHandeler.OnRespawn(req, res, client)
})

app.post("/OnRoundStart", async function (req, res){
    RoundHandeler.OnRoundStart(req, res, client)
})

app.post("/OnRoundEnd", async function (req, res){
    RoundHandeler.OnRoundEnd(req, res, client)
})

app.post("/PlayerCount", async function (req, res){
    PlayerCountHandeler.PlayerCount(req, res, client)
})

app.post("/OnBan", async function(req, res){
    BanHandeler.OnBan(req, res, client)
})

app.post("/OnOfflineBan", async function (req, res){
    BanHandeler.OnOfflineBan(req, res, client)
})

app.post("/OnHurt", async function(req, res){
    HurtingHandeler.OnHurt(req, res, client)
})

app.post("/OnWaiting", async function (req, res){
    WaitingForPlayerHandeler.OnWaiting(req, res, client)
})

app.post("/OnCuff", async function (req, res){
    CuffHandeler.OnCuff(req, res, client)
})

app.post("/OnUnCuff", async function (req, res){
    CuffHandeler.OnUnCuff(req, res, client)
})

client.login(require("./config").Token);