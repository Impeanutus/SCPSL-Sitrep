const LogChannelId = require("./../config").LogChannelId

async function OnJoin(req, res, client){
    try{
        const Player = req.body.Player;
        const PlayerId= req.body.PlayerId;
        const PlayerIp = req.body.PlayerIp;

        client.channels.cache.get(LogChannelId).send(`➡️ | Hráč ${Player} (${PlayerId}) {${PlayerIp}} se připojil na server`)
        res.sendStatus(200)
    }catch (err){
        console.log(err)
        res.sendStatus(500)
    }
}

async function OnLeave(req, res, client){
    try{
        const Player = req.body.Player;
        const PlayerId= req.body.PlayerId;
        const PlayerIp = req.body.PlayerIp;

        client.channels.cache.get(LogChannelId).send(`⬅️ | Hráč ${Player} (${PlayerId}) {${PlayerIp}} se odpojil ze serveru`)
        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}
module.exports = {OnJoin, OnLeave}