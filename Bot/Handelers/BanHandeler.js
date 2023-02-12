const BanChannelId = require("./../config").BanChannelId
const { EmbedBuilder } = require('discord.js');

async function OnBan(req, res, client){
    try{
        const Time = parseInt(req.body.Time)
        var ReformatedTime;
        if(Time <= 60){
            ReformatedTime = `${Time} sekund`
        }
        else if(Time <= 3600){
            ReformatedTime = `${Time/60} minut`
        }
        else if(Time < 86400 ){
            ReformatedTime = `${Time/60/60} hodin`
            } 
        else {
            ReformatedTime = `${Time/60/60/24} dní`
        }
            

        const BanEmbed = new EmbedBuilder()
            .setTitle("Hráč byl zabanován")
            .addFields(
                {name: "Admin", value: req.body.Admin},
                {name: "Admin ID", value: req.body.AdminId},
                {name: "Hráč", value: req.body.Target},
                {name: "Hráč ID", value: req.body.TargetId},
                {name: "Důvod", value: req.body.Reason},
                {name: "Délka", value: ReformatedTime}
            )
            client.channels.cache.get(BanChannelId).send({embeds: [BanEmbed]});
            res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

async function OnOfflineBan(req, res, client){
    try{
        const Admin = req.body.Admin;
        const AdminId = req.body.AdminId
        const TargetId = req.body.TargetId;
        const Reason = req.body.Reason;
        const Time = req.body.Time

        const OfflineBanEmbed = new EmbedBuilder()
            .setTitle("Hráč byl offline zabanován")
            .addFields(
                {name: "Admin", value: Admin},
                {name: "Admin ID", value: AdminId},
                {name : "Hráč ID", value: TargetId},
                {name: "Důvod",value: Reason},
                {name: "Zabanová do", value: Time}
            )
        client.channels.cache.get(BanChannelId).send({embeds: [OfflineBanEmbed]});
        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

module.exports = {OnBan, OnOfflineBan}