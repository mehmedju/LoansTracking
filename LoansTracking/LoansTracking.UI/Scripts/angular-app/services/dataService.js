(angular.module('app')
    .service('dataService', function ($http, $q) {

        this.get = function (url) {
            var deferred = $q.defer();
            $http.get(url).
                success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    deferred.reject(err);
                });
            return deferred.promise;
        }

        this.getById = function (url, id) {
            var deferred = $q.defer();
            $http.get(url + id).
                success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    deferred.reject(err);
                });
            return deferred.promise;
        }

        this.post = function (url, data) {
            var req = {
                method: "POST",
                url: url,
                header: {
                    "Content-Type": "application/json"
                },
                data: data
            }
            var deferred = $q.defer();
            $http(req).success(function (result) {
                deferred.resolve(result);
            })
            .error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        this.put = function (url, data) {
            var req = {
                method: "PUT",
                url: url,
                header: {
                    "Content-Type": "application/json"
                },
                data: data
            }
            var deferred = $q.defer();
            $http(req).success(function (result) {
                deferred.resolve(result);
            })
            .error(function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        this.delete = function (url, id) {
            var deferred = $q.defer();
            $http.delete(url + id).
                success(function (response) {
                    deferred.resolve(response);
                }).error(function (err) {
                    deferred.reject(err);
                });
            return deferred.promise;
        }
    })
);