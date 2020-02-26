function gotoEdit(ahref) {
    var id = $('#rec-edit-id').val();
    if (id === undefined) {
        return false;
    }
    var url = $(ahref).attr('href');
    if (!url.endsWith('Edit')) {
        url = $(ahref).attr('href').substr(0, $(ahref).attr('href').lastIndexOf('/'));
    }
    url = url + '/' + id;

    $(ahref).attr('href', url);
    return true;
}

function gotoDel(ahref) {
    var id = $('#rec-del-id').val();
    if (id === undefined) {
        return false;
    }
    var url = $(ahref).attr('href');
    if (!url.endsWith('Delete')) {
        url = $(ahref).attr('href').substr(0, $(ahref).attr('href').lastIndexOf('/'));
    }
    url = url + '/' + id;

    $(ahref).attr('href', url);
    return true;
}