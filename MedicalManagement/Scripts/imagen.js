function readURL(i) {
    if (i.files && i.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('.blah').attr('src', e.target.result);
                    
        }

        reader.readAsDataURL(i.files[0]);
    }
}