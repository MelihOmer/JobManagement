$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7035/api/ClientNotifications/status-messagelist',
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data && data.length > 0) {
                data.forEach(function (stateData) {
                    createNewStateBox(stateData);
                });
            }
        }
    })
});




const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7035/statehub").build();
connection.start().then(function () {
    console.log("StateHub Baglanti Kuruldu");
}).catch(function (err) {
    return console.error("StateHub Baðlanamadý.", err.toString());
});


$("#stateSendBtn").click(() => {
    const statusText = $("#stateInput").val();

    $.ajax({
        url: 'https://localhost:7035/api/ClientNotifications',
        method: 'POST',
        data: JSON.stringify({ StatusMessage: statusText }),
        contentType: 'application/json',
        success: function () {
            console.info('Ajax ile statusMessage gonderildi...')
        },
        error: function (err) {
            console.error('Ajax ile statusMessage Gönderilemedi...',err)
        }
    })
})


connection.on("ReceiveState", (entryData) => {
    createNewStateBox(entryData);

});




//stateBox.children('.mb-3').hover(function () {
//    $(this).css("background-color","grey")
//});


function createNewStateBox(userData) {
    const newStateBox = $('<div class="col-md-3"><div class="alert" style="height:100px; background-color:#e9e9e9; border-radius:0px; opacity: 0; display: none;" role="alert"></div></div>');
    const stateAlert = newStateBox.children('.alert');

    // Kullanýcý resmi, ad-soyad ve statü bilgilerini içeren içerik
    const userImage = `<img src="${userData.userImagePath}" class="rounded-circle" alt="User Image" style="width: 40px; height: 40px; margin-right: 10px;">`;
    const userFullName = `<strong style="margin-left:15px;" >${userData.userFullName}</strong>`;
    const statusText = userData.statusContent;
    const statusDate = userData.createdDate;
    const formattedDate = formatTime(statusDate);

    // Ýçeriði birleþtir
    const contentHtml = `
    <div class="row">
    <div class="col-md-10">${userImage}${userFullName} <br><span style="margin-left:65px;">${statusText}</span></div>
    <div class="text-right small col-md-2" style="color:grey;padding:5px;">${formattedDate}</div>
    </div> 
    `;

    stateAlert.html(contentHtml);

    const stateBox = $("#stateBox");
    stateBox.prepend(newStateBox);

    if (stateBox.children('.mb-3').length > 24) {
        stateBox.children(":last").fadeOut(500, function () {
            $(this).remove();
        });
    }

    stateAlert.css({ display: "block" }).animate({ opacity: 1 }, 2000, "swing");
}
function formatTime(rawDate) {
    const date = new Date(rawDate);
    const hours = date.getHours();
    const minutes = date.getMinutes();
    const seconds = date.getSeconds();

    // Ýsteðe baðlý olarak sýfýr ekleyebilirsiniz (örneðin, 09 instead of 9)
    const formattedHours = hours < 10 ? `0${hours}` : hours;
    const formattedMinutes = minutes < 10 ? `0${minutes}` : minutes;
    const formattedSeconds = seconds < 10 ? `0${seconds}` : seconds;

    return `${formattedHours}:${formattedMinutes}:${formattedSeconds}`;
}