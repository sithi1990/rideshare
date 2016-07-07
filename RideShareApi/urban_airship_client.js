﻿var HttpClient = require('node-rest-client').Client;
var httpClient = new HttpClient();

module.exports = function () {
   
    function sendNotification(driverUserName,requestId,sourceLocation,longitude,latitude,callback) {
       
		var args = {
			data: {
				"audience" : {
					"named_user" : driverUserName
				},
				"device_types": ["android"],
				"notification": {
					"android": {
						"alert": "New Pickup Request",
						"extra": {
							"request_id": requestId,
							"location_name": sourceLocation,
							"longitude": longitude,
							"latitude": latitude
						},
						"interactive": {
							"type": "ua_accept_decline_foreground",
							"button_actions": {
								"accept": {
									"add_tag": "test"
                 
								},
								"decline": {
									"add_tag": "nope"
								}
							}
						}
					}
				}
			},
			headers: {
				"Content-Type": "application/json", 
				"Accept": "application/vnd.urbanairship+json; version=3;",
				"Authorization": "Basic N1JhUG1GRTBRUC1MX3BES3NUeUxDQTpKRWY2S2RzSlJZLUc3YTZRT2cxOUpn"
			}
		};
		
		//Content-Type: application/json
		process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
        httpClient.post("https://go.urbanairship.com/api/push", args, function (data, response) {
            
			var jsonData= JSON.parse(data)
            if (jsonData.ok) {
				callback ({ success: true, message: 'Notification Sent.' });
            }
            else {
				callback ({ success: false, message: 'Error sending notification' });
            }

        });

    }
    
    return {
        sendNotification: sendNotification
    };
}();