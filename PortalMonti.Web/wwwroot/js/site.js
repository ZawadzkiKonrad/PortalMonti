// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//crate a cpnnection for signal r
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

//recevice the message
connection.on("ReceiveMessage", (user, message) => {
    const rec_msg = user + ": " + message;
    const li = document.createElement("li");
    li.textContent = rec_msg;
    document.getElementById("messagesList").appendChild(li);
})

connection.start().catch(err => console.error(err.toString()));

//send messasge
document.getElementById("sendMessage").addEventListener("click", event => {

    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;

    connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    event.preventDefault();
});



