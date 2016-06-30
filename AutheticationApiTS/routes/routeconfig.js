"use strict";
var express = require('express');
var AuthenticationAPI = require('./AuthenticationApiController');
var UserMongooseDAO = require('../data_access/UserDAO');
var RouteConfig = (function () {
    function RouteConfig(app) {
        this.apiRoutes = express.Router();
        this.app = app;
    }
    RouteConfig.prototype.initApiRoutes = function () {
        var authenticationApi = new AuthenticationAPI(new UserMongooseDAO());
        this.apiRoutes.post('/useraccount', authenticationApi.useraccount);
        this.apiRoutes.post('/accesstoken', authenticationApi.accesstoken);
        this.apiRoutes.get('/userinfo', authenticationApi.userinfo);
        this.app.use('/authapp', this.apiRoutes);
    };
    return RouteConfig;
}());
module.exports = RouteConfig;
//# sourceMappingURL=RouteConfig.js.map