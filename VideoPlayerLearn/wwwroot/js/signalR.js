
$(document).ready(() => {
    var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7035/testhub").build();
    connection.start().then(() => {
        console.log(connection.state);
        connection.invoke("SendMessage");
    }).catch((err) => { console.log(err) });


    connection.on("ReceiveMessage", (value) => {
        playNotificationSound();
        toastr.info(value, 'Bir Bildirim Eklendi')
        Utils.getAppUserList();
        Utils.getAssignedUserList();
        
    });
    function playNotificationSound() {
        var notifySound = new Audio('/notifySound.wav');
        notifySound.play().then(() => {

        }).catch(error => {
            console.log('Bildirim Sesi Calinamadi : ',error)
        })
    }

});
