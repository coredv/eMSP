﻿'use strict';
angular.module('eMSPApp')
    .controller("manageUserRoleController", manageUserRoleController)
function manageUserRoleController($scope, $state, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, formAction) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.userList = [];
    $scope.companyTypeList = ["Customer", "Supplier", "MSP"];
    $scope.companyList = [];
    $scope.roleGroupsList = [];
    $scope.refData.submitted = false;
    $scope.formAction = formAction;

    $scope.CUser = localStorageService.get('CurrentUser');

    

    

    var apiresroles = apiCall.post(APP_CONSTANTS.URL.ROLE.GETALLROLEGROUPURL);
    apiresroles.then(function (data) {
        $scope.roleGroupsList = data;
    });

    $scope.changeUser = function (model) {
        $scope.dataJSON.user = model.user;        
    }

    $scope.changeCompanyType = function (model) {

        if (model != "MSP") {
            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, { companyType: model, companyName: "%" });
            res.then(function (data) {
                $scope.companyList = data;
            });
        }
        else {
            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.GETURL, { companyType: model, companyName: "" });
            res.then(function (data) {
                $scope.companyList.push(data);  
            });
        }

    }

    $scope.changeCompany = function (model) {

        var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, { companyType: model.companyType, id: model.id });
        apires.then(function (data) {
            $scope.userList = data;
        });

    }

    //Function to assign Role to user
    $scope.submit = function (form) {
        $scope.dataJSON.user.roleGroupId = $scope.dataJSON.roleGroup.id;
        $scope.refData.submitted = false;

        if (form.$valid) {
            var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.ASSIGNUSERROLEURL, $scope.dataJSON);
            apires.then(function (data) {
                toaster.success({ body: "Role Assigned Successfully." });                
            });
        }
    }
}