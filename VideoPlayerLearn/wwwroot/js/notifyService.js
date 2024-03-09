var NotifyService = NotifyService || {};
var Config = Config || {};
NotifyService.getNotifyList = function () {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "GET",
            url: Config.notifyAppUserUrl,
            dataType: "json",
            cache: "false",
            success: function (data) {


                if (data != null) {
                    resolve(data);
                }
            },
            error: function (xhr) {
                console.error('Mesaj Getirmede Hata : ' + xhr.status);
            }
        })
    })

}
NotifyService.getNotifyListAssigned = function () {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "GET",
            url: Config.notifyAssignedUserUrl,
            dataType: "json",
            cache: "false",
            success: function (datas) {


                if (datas != null) {
                    resolve(datas);
                }
            },
            error: function (xhr) {
                console.error('Mesaj Getirmede Hata : ' + xhr.status);
            }
        })
    })

}
