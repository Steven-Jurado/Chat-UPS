
let ConnectionSignalR = new signalR.HubConnectionBuilder().withUrl("/signal").build();

ConnectionSignalR.start().then(() => {
    console.log("Conectado")
}).catch((error) => {
    console.log("Error", error)
});

ConnectionSignalR.on("MessageUsuario", (message) => {
    AgregarMensajeHistorialChat(message)
});


function AgregarGrupoChat(identificadorGrupo) {

    ConnectionSignalR.invoke("CreateGroupChat", identificadorGrupo).then(() => {
        console.log("Grupo Agregado");
    }).catch((error) => {
        console.log("Error Al Envio de Mensaje", error);
    })
}

function EnviarMensaje(message, identificacionGrupo) {

    ConnectionSignalR.invoke("SendMessage", message, identificacionGrupo).then(() => {
        $("#chat-message").val("");
    }).catch((error) => {
        console.log("Error Al Envio de Mensaje", error);
    })



    ConnectionSignalR.invoke("SendMessageSqlServer", message).then(() => {
        console.log("Agregado En Base Datos");
    }).catch((error) => {
        console.log("Error Al Envio de Mensaje", error);
    })
}

function EnviarMensajeEnter(code, message, identificacionGrupo) {

    if (code.keyCode === 13)
        EnviarMensaje(message, identificacionGrupo)
}

function AgregarMensajeHistorialChat(message) {

    let historyMessage = `
            <li class="clearfix">
                <div class="message-data text-right">
                    <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="avatar">
                </div>
                <div class="message other-message float-right"> ${message}</div>
            </li>`

    $("#history-chat").append(historyMessage)
}


function CerrarHistorialChat() {
    $("#init-chat").empty();
}

function AbrirHistorialChat(nombreUsuario, imagenUsuario, identificacionGrupo) {

    CerrarHistorialChat()

    AgregarGrupoChat(identificacionGrupo)

    let agregarHistorialChat = `
        <div class="chat-header clearfix">
            <div class="row">
                <div class="col-lg-6">
                    <a href="javascript:void(0);" data-toggle="modal" data-target="#view_info">
                        <img src="${imagenUsuario}" alt="avatar">
                    </a>
                    <div class="chat-about">
                        <h6 class="m-b-0">${nombreUsuario}</h6>
                    </div>
                </div>
            </div>
        </div>
        <div class="chat-history">
            <ul id="history-chat" class="m-b-0">
                
            </ul>
        </div>
        <div class="chat-message clearfix">
            <div class="input-group mb-0">
                <div class="input-group-prepend">
                    <span class="input-group-text" onclick="EnviarMensaje($('#chat-message').val(),'${identificacionGrupo}')"><i class="fa fa-send"></i></span>
                </div>
                <input id="chat-message" onkeypress="EnviarMensajeEnter(event,$('#chat-message').val(),'${identificacionGrupo}')" type="text" class="form-control" placeholder="Enter text here...">
            </div>
        </div>`

    $("#init-chat").html(agregarHistorialChat)
}