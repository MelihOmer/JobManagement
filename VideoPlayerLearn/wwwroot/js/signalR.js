
$(document).ready(() => {
    var notifySound = new Audio('/notifySound.wav');
     //toastr.success('test', 'SignalR Bildirim')

    var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7035/testhub").build();
    connection.start().then(() => {
        console.log(connection.state);
        connection.invoke("SendMessage");
    }).catch((err) => { console.log(err) });


    connection.on("ReceiveMessage", (value) => {
        toastr.success(value, 'SignalR Bildirim')
        notifySound.play();
        console.log(`${value.definition}`)
    });

});
