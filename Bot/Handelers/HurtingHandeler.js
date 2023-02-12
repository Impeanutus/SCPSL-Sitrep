const HurtChannelId = require("./../config").HitChannelId

async function OnHurt(req, res, client){
    try{
        const Attacker = req.body.Attacker;
        const AttackerId = req.body.AttackerId;
        const AttackerRole = req.body.AttackerRole;
        const Player = req.body.Player;
        const PlayerId = req.body.PlayerId;
        const PlayerRole = req.body.PlayerRole;
        const Item = req.body.Item;

        client.channels.cache.get(HurtChannelId).send(`⚠️ | Hráč ${Attacker} (${AttackerId}) <${AttackerRole}> zranil spoluhráče ${Player} (${PlayerId}) <${PlayerRole}> pomocí ${Item}`)

        res.sendStatus(200)
    }
    catch{
        res.sendStatus(500)
    }
}

module.exports = {OnHurt}