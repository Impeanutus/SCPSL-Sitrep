const LogChannelId = require("./../config").LogChannelId

async function OnCuff(req, res, client){
    try{
        const Cuffed = req.body.Cuffed;
        const CuffedId = req.body.CuffedId;
        const CuffedRole = req.body.CuffedRole;
        const Player = req.body.Player;
        const PlayerId = req.body.PlayerId;
        const PlayerRole = req.body.PlayerRole;

        client.channels.cache.get(LogChannelId).send(`ℹ️ | Hráč ${Player} (${PlayerId}) <${PlayerRole}> zatknul hráče ${Cuffed} (${CuffedId}) <${CuffedRole}>`)

        res.sendStatus(200)
    }
    catch (err){
        res.sendStatus(500)
    }
}


async function OnUnCuff(req, res, client){
    try{
        const Cuffed = req.body.Cuffed;
        const CuffedId = req.body.CuffedId;
        const CuffedRole = req.body.CuffedRole;
        const Player = req.body.Player;
        const PlayerId = req.body.PlayerId;
        const PlayerRole = req.body.PlayerRole;

        client.channels.cache.get(LogChannelId).send(`ℹ️ | Hráč ${Player} (${PlayerId}) <${PlayerRole}> odpoutal hráče ${Cuffed} (${CuffedId}) <${CuffedRole}>`)

        res.sendStatus(200)
    }
    catch (err){
        res.sendStatus(500)
    }
}

module.exports = {OnCuff, OnUnCuff}