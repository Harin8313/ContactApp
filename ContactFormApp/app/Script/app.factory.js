angular
    .module('ContactApp')
	.factory('dataFactory', ['$http', function ($http) {

	    var urlBase = 'http://localhost:17105/api/ContactInformation/';	    
	    var dataFactory = {};
        //var dataResponse = new Object();

        dataFactory.getContacts = function () {

           return  $http.get(urlBase + 'GetContacts');
    	    //.then(function (response) {
	        //        alert('here');
    	    //    dataResponse.data = response.data;
    	    //    dataResponse.success = true;
    	    //}, function (error) {
    	    //        dataResponse.success = false;
    	    //        dataResponse.errorStatusCode = error.status;
	        //        dataResponse.errorMessage = error.MessageChannel;
    	    //});

    	    //alert(dataResponse.success);

            //return dataResponse;
        };

        dataFactory.getContact = function (id) {

           return  $http.get(urlBase + 'GetContact?id=' + id);
    	    //.then(function (response) {
    	    //    dataResponse.data = response.data;
    	    //    dataResponse.success = true;
    	    //}, function (error) {
    	    //    dataResponse.success = false;
    	    //    dataResponse.errorStatusCode = error.status;
    	    //    dataResponse.errorMessage = error.MessageChannel;
    	    //});

    	    //return dataResponse;
    	};
       
    	dataFactory.insertContact = function (contact) {
    	    return $http.post(urlBase + 'Post', contact);
    	};

    	dataFactory.updateContact = function (contact) {	        
    	    return $http.put(urlBase + 'Put', contact);
	    };

    	dataFactory.deleteContact = function (id) {
    		return $http.delete(urlBase + '/' + id);
    	};

    	

    	return dataFactory;
    }]);