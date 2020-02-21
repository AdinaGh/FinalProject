function gotoEdit(ahref) {
    var id = $('#rec-id').val();
    if (id == undefined) {
        return false;
    }
    var url = $(ahref).attr('href');
    if (url.endsWith('Edit')) {
    }
    else {
   url =     $(ahref).attr('href').substr(0, $(ahref).attr('href').lastIndexOf('/'))
    }
    url = url + '/' + id;

    $(ahref).attr('href', url);
    return true;
}