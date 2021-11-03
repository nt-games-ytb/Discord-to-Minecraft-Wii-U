const Discord = require('discord.js');

const client = new Discord.Client();

client.login("");//Bot token

client.on("ready", () => { 
    console.log("Message recording can begin !")
    client.user.setActivity("save messages and put them on Minecraft Wii U !")
});

client.on(`message`, message => {
    var fs = require('fs');
    fs.writeFile("./discord message.txt", "[" + message.channel.name + "] <" + message.author.username + "> " + message.content, (err) => {if (err) console.error(err);});
});
