var app = angular.module("MyApp", []);

app.controller("EmployeeController", function($scope,$http) {
    $scope.GetEmployes = function() {
        $http.get('/Employee').then(function(response) {
            console.log(response);
        })
    }
});
