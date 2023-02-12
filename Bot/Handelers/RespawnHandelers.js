const LogChannelId = require("./../config").LogChannelId

async function OnRespawn(req, res, client){
    try{
        client.channels.cache.get(LogChannelId).send(`👮 | Právě přijeli ${req.body.team} v počtu: ${req.body.count}`)
        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

module.exports = {OnRespawn}