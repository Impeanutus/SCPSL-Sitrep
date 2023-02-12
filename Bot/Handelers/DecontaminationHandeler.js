const LogChannelId = require("./../config").LogChannelId

async function OnDecontamination(req, res, client){
    try{
        client.channels.cache.get(LogChannelId).send("☢️ | Právě začala dekontaminace")
        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

module.exports ={ OnDecontamination}