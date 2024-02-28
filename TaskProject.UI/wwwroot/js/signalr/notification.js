"use strict";
function initNotifyHub(userId, isAdmin) {
    var connection = new signalR.HubConnectionBuilder().withUrl(`/NotificationHub?UserID=${userId}&IsAdmin=${isAdmin}`).build();
    connection.on("ShowNotify", function (notifyObj) {
        if (typeof handleNotification !== 'undefined') {
            handleNotification(notifyObj);
        }
        else if (typeof notifySystem != 'undefined') {
            notifySystem(notifyObj);
        }
    });

    connection.start().then(function () {
        console.log("connection started")
    }).catch(function (err) {
        return console.error(err.toString());
    });
}