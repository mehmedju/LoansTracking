app.filter('searchNotesFilter', function () {
    return function (notes, searchInput) {
        var filtered = [];
        if (notes != undefined) {
            angular.forEach(notes, function (note) {
                if (note.title.substring().match(searchInput)) {
                    filtered.push(note);
                }
            });
            return filtered;
        }
        if (searchInput == undefined || searchInput == '')
            return notes;
    };
}
);


