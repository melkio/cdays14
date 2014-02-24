angular.module('project', [])

.value('$', $)

.service('signalR', function ($, $rootScope) {
    var initialize = function () {
        var hub = $.connection.denormalizer;

        hub.client.notify = function (message) {
            $rootScope.$emit("denormalized", message);
        };

        $.connection.hub.start();
    };

    return {
        initialize: initialize
    };
})

.config(function ($routeProvider) {
    $routeProvider
      .when('/', {
          controller: 'ListCtrl',
          templateUrl: 'list.html'
      })
      .otherwise({
          redirectTo: '/'
      });
})

.controller('ListCtrl', function ($scope, $http, signalR) {
    $scope.talk = { speaker: '', title: '', abstract: '' };

    var readData = function () {
        $http.get("talks")
            .success(function (data) {
                $scope.talks = data;
        });
    };

    $scope.save = function () {
        $http.post("talks", $scope.talk)
            .success(function (data) {
                $scope.talk = { speaker: '', title: '', abstract: '' };
            });
    };

    signalR.initialize();
    readData();

    $scope.$parent.$on('denormalized', function (e, message) {
        $scope.$apply(function () {
            readData();
        })
    });
});