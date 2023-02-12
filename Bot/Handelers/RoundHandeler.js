const LogChannelId = require("./../config").LogChannelId


async function OnRoundStart(req, res, client){
    try{
        client.channels.cache.get(LogChannelId).send(`🎬 | Kolo právě začalo`)
        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

async function OnRoundEnd(req, res, client){
    try{
        client.channels.cache.get(LogChannelId).send(`🏁 | Kolo právě skončilo a vyhrál: ${req.body.vyhral}`)
        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

module.exports = {OnRoundEnd, OnRoundStart}