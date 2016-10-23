(angular.module('app')
    .controller('loansController', ['$scope', function ($scope) {
        'use strict';

        angular.extend($scope, {
            addMode: true,
            allUsers: [
{
    $id: "1",
    id: 1,
    person: 1,
    name: "John",
    surname: "Doe",
    amount: 5000,
    status: 4500,
    paidOff: false,
    dueDate: "2017-06-16T00:00:00",
    payments: [
    {
        $id: "2",
        id: 1,
        date: "2016-10-17T10:53:02.313",
        amountPaid: 100,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "3",
        id: 2,
        date: "2016-10-17T10:53:02.32",
        amountPaid: 100,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "4",
        id: 3,
        date: "2016-10-17T10:53:02.32",
        amountPaid: 100,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "5",
        id: 4,
        date: "2016-10-17T10:53:02.32",
        amountPaid: 100,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "6",
        id: 5,
        date: "2016-10-17T10:53:02.32",
        amountPaid: 70,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "7",
        id: 6,
        date: "2016-10-17T10:53:02.32",
        amountPaid: 30,
        paidBy: "John",
        paidById: 1
    }
    ]
},
{
    $id: "8",
    id: 2,
    person: 1,
    name: "Irhad",
    surname: "Ljubcic",
    amount: 10000,
    status: 9150,
    paidOff: false,
    dueDate: "2017-11-24T00:00:00",
    payments: [
    {
        $id: "9",
        id: 7,
        date: "2016-10-17T10:53:02.32",
        amountPaid: 150,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "10",
        id: 8,
        date: "2016-10-17T10:53:02.323",
        amountPaid: 100,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "11",
        id: 9,
        date: "2016-10-17T10:53:02.323",
        amountPaid: 190,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "12",
        id: 10,
        date: "2016-10-17T10:53:02.323",
        amountPaid: 300,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "13",
        id: 11,
        date: "2016-10-17T10:53:02.323",
        amountPaid: 70,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "14",
        id: 12,
        date: "2016-10-17T10:53:02.323",
        amountPaid: 30,
        paidBy: "John",
        paidById: 1
    },
    {
        $id: "15",
        id: 13,
        date: "2016-10-17T10:53:02.323",
        amountPaid: 10,
        paidBy: "John",
        paidById: 1
    }
    ]
},
{
    $id: "16",
    id: 3,
    person: 1,
    name: "Haris",
    surname: "Brackovic",
    amount: 7000,
    status: 0,
    paidOff: false,
    dueDate: "2017-03-05T00:00:00",
    payments: []
},
{
    $id: "17",
    id: 4,
    person: 2,
    name: "Ajla",
    surname: "Galic",
    amount: 3500,
    status: 0,
    paidOff: false,
    dueDate: "2017-01-01T00:00:00",
    payments: []
}
            ]
        });

        $scope.addNewLoan=function() {
            $scope.addMode = true;
        }

    }
    ]));

