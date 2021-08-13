// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const hubUrl = "/chat1hub";
const hub1_messageDoc = document.getElementById("message_box_1");
const hub1_messageDisplayBodyDoc = document.getElementById("card_body_1");
const userModalDoc = document.getElementById("nickName_modal");
const userNickNameDoc = document.getElementById("nickname_input");

document.addEventListener('DOMContentLoaded', Initialize);

function Initialize() {
    setUpConnection();  
    userCheck();
}

function setUpConnection() {
    var connection = new signalR.HubConnectionBuilder().withUrl(hubUrl).build();
    connection.on("message", function (messageDto) {        
        let currentMessage = hub1_messageDisplayBodyDoc.innerHTML;
        currentMessage += "<b>" + messageDto.name + ":" + "</b>" +
        "<p>" + messageDto.message + "</p>" + "<br/>";
        hub1_messageDisplayBodyDoc.innerHTML = currentMessage;
    });
    connection
        .start()
        .catch(err =>
        {            
            console.error(err.toString())
        })
        .then(response => {        
        console.log("connected")
    });
}
async function sendMessage() {    
    let message = hub1_messageDoc.value;
    let name = localStorage.getItem("user");
    hub1_messageDoc.value = "";
    let res = await fetch("/Chat/Message", {
        method: "POST",
        body: JSON.stringify({
            name,message
        }),
        headers: {
            'content-type': 'application/json'
        }
    })    
}
function setNickName() {
    debugger;
    let nickName = userNickNameDoc.value;
    if (nickName !== '') {
        let nickName = userNickNameDoc.value;
        localStorage.setItem("user", nickName);
        userModalDoc.style.display = "none";
        SuccessMessage();
    }
    else {
        ErrorMessage("Error", "Please insert a nickname");
        userModalDoc.style.display = "block";
    }
    
}
function userCheck() {    
    let currentUser = localStorage.getItem("user");
    if (currentUser !== '') {
        userModalDoc.style.display = "block";
    }
    else {
        userModalDoc.style.display = "none";
    }
}