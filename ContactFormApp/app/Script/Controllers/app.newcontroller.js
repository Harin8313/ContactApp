angular.module('ContactApp')
        .controller('NewContactController', ['$scope', '$routeParams', '$location', 'dataFactory',
            function ($scope, $routeParams, $location, dataFactory) {



                $scope.saveContact = function () {
                    dataFactory.insertContact($scope.contact)
                    .then(function (response) {
                        if (response.status === 200) {
                            $location.path('/app');
                        } else {
                            $scope.status = 'Unable to save contact';
                        }
                    }, function (error) {
                        $scope.status = 'Oops some error has occured: ' + error.message;
                    });
                };

                $scope.cancel = function () {
                    $location.path('/app');
                };

            }]);
