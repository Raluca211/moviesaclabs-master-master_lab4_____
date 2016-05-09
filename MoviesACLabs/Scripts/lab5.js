var app = angular.module('Start', []);

app.service("MoviesService", function($http){

    this.getActors = function () {
        return $http({
            method: "GET",
            url: "api/actors"
            
        });
    };

    this.addActor = function (actor) {
        return $http({
            method: "POST",
            url: "api/actors",
            data: actor
        });
    };

    this.removeActor = function (index) {
        return $http({
            method: "DELETE",
            url: "api/actors/"+index

        });
    };


});

app.controller('body', function($scope, MoviesService) {
    $scope.actorsList = [];
   
 
    $scope.Name = '';
    $scope.Date = '';
    $scope.Rev = '';

    $scope.newActor;
   
    
    MoviesService.getActors().then(function (dataresponse) {
        $scope.actorsList = dataresponse.data;
    });


    $scope.add = function () {

        if ($scope.Name == '' && $scope.Date == '' && $scope.Rev == '' && $scope.Rev == '') {
            return;
        }
        
            //var actor = $.param({
            //    json: JSON.stringify({
            //        Name: $scope.Name,
            //        DateOfBirth: $scope.Date,
            //        Revenue: $scope.Rev

            //    })
        newActor = {
                
                Name: $scope.Name,
                DateOfBirth: $scope.Date,
                Revenue: $scope.Rev


            };
            

            MoviesService.addActor(newActor).then(function () { }, function (response) { console.log(response); });

           
            MoviesService.getActors().then(function (dataresponse) {
                $scope.actorsList = dataresponse.data;
            });
          
        

      
        $scope.Name = '';
        $scope.Date ='';
        $scope.Rev = '';
        

    };


    $scope.remove = function (index) {
        MoviesService.removeActor(index).then(function () { }, function (response) { console.log(response); });



    }


});

   
   





