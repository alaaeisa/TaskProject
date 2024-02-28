"use strict";
function initTrackingHub() {
    var connection = new signalR.HubConnectionBuilder().withUrl(`/TrackingHub`).build();
    connection.on("UpdateMap", function (notifyObj) {
        handleTracking(notifyObj);
    });

    connection.start().then(function () {
        console.log("connection started")
    }).catch(function (err) {
        return console.error(err.toString());
    });
}