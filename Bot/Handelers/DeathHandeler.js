const LogChannelId = require("./../config").LogChannelId

async function OnDeath(req, res, client){
    try{
        const Killer = req.body.Killer;
        const KillerId = req.body.KillerId;
        const KillerRole = req.body.KillerRole;
        const Target = req.body.Target;
        const TargetId = req.body.TargetId;
        const TargerRole = req.body.TargetRole;
        const TK = req.body.TK;
        const Weapon = req.body.Weapon

        if(TK == "kill"){
            client.channels.cache.get(LogChannelId).send(`☠️ | Hráč ${Killer} (${KillerId}) <${KillerRole}> zabil hráče ${Target} (${TargetId}) <${TargerRole}> pomocí ${Weapon}`)
        }
        else if(TK == "TK"){
            client.channels.cache.get(LogChannelId).send(`⚠️☠️ | Hráč ${Killer} (${KillerId}) <${KillerRole}> zabil spoluhráče ${Target} (${TargetId}) <${TargerRole}> pomocí ${Weapon}`)
        }

        res.sendStatus(200)
    }
    catch {
        res.sendStatus(500)
    }

}

module.exports = {OnDeath}