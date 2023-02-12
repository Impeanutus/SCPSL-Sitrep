const {ActivityType} = require("discord.js")

var PlayerCountNumber;

async function PlayerCount (req, res, client){
    try{
        if(req.body.count != PlayerCountNumber){
            client.user.setPresence({
                activities:[{name: `${req.body.count}/${req.body.maxcount}`, type: ActivityType.Competing,}],
           })
           PlayerCountNumber = req.body.count
           res.sendStatus(201)
        }
        else {
            res.sendStauts(200)
        }

    }
    catch{
        res.sendStatus(500)
    }
}

module.exports = {PlayerCount}