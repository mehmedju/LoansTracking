describe('mainController test', function () {
    var controller, scope, location;

    beforeEach(module('app', function () {
    }));

    beforeEach(inject(function ($controller, $rootScope) {
        scope = $rootScope.$new();

        location = jasmine.createSpyObj('$location', ['path']);

        controller: $controller('mainController', {
            '$scope': scope,
            '$location': location
        });
    }));


    it('should test temp method', function() {
        scope.getCurrentLocation();
        expect(location.path).toHaveBeenCalled();
    });

})