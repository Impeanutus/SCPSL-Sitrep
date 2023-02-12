const LogChannelId = require("./../config").LogChannelId

async function OnWaiting(req, res, client ){
    try{
        client.channels.cache.get(LogChannelId).send(`ℹ️ | Server čeká na hráče`)
        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

module.exports = {OnWaiting}