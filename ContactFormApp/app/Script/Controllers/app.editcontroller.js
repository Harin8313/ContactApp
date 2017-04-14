angular.module('ContactApp')
        .controller('EditContactController', ['$scope', '$routeParams', '$location', 'dataFactory',
            function ($scope, $routeParams, $location, dataFactory) {

                var contactId = $routeParams.Id;
                
                function getContact() {
                    dataFactory.getContact(contactId)
                        .then(function (response) {                           
                            $scope.contact = response.data;
                            
                        }, function (error) {
                            $scope.status = 'Unable to load data: ' + error.message;
                        });
                }

                getContact();

                $scope.deleteContact = function () {
                    dataFactory.deleteContact(contactId)
                    .then(function (response) {
                        if (response.status === 200) {
                            $location.path('/app');
                        } else {
                            $scope.status = 'Unable to delete contact';
                        }
                    }, function (error) {
                        $scope.status = 'Oops some error has occured';
                    });
                };

                $scope.saveContact = function () {                  
                    dataFactory.updateContact($scope.contact)
                    .then(function (response) {
                        if (response.status === 200) {
                            $location.path('/app');
                        } else {
                            $scope.status = 'Unable to save contact';
                        }
                    }, function () {                           
                        $scope.status = 'Oops some error has occured ';
                    });
                };

                $scope.cancel = function () {                 
                    $location.path('/app');
                };

            }]);
