var app = angular.module('Start', []);


app.controller('body', function ($scope) {

    
    $scope.List = [];
    $scope.InputList = '';
    $scope.newList = [];

   
    $scope.addTodo = function () {

        if ($scope.InputList == '') {
            return;
        }
        else {
            $scope.List.push({ name: $scope.InputList, comp: false });
        }
        $scope.InputList = '';



    };

    $scope.submit = function () {
        if ($scope.InputList == '') {
            return;
        }
        else {
            $scope.List.push({ name: $scope.InputList, comp: false });
        }
        $scope.InputList = '';


    };

    $scope.remove = function (index) {
        $scope.List.splice(index, 1);
    }


    /*$scope.completed = function () {
        var oldList = $scope.List;
        $scope.newList = [];
        angular.forEach(oldList, function (elem) {
            if (elem.done) $scope.newList.push(elem);
        });
    }*/
    
   


   


});
