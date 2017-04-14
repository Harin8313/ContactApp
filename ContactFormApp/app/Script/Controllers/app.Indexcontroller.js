(function () {

    'use strict';

    angular.module('ContactApp')
           .controller('ContactListController',
           ['$scope', '$location', 'responseList',
                        function ($scope, $location, responseList) {

                            function getContacts() {
                                if (responseList.status === 200) {
                                    $scope.contacts = responseList.data;
                                } else {
                                    $scope.status = 'Unable to load data: ';
                                }
                            }

                            getContacts();


                            $scope.add = function () {
                                $location.path('/new');
                            };
                        }
           ]);

})();




