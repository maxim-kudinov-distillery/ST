function ClearForm() {
    $(".formData").find("input[type=\"text\"], input[type=\"hidden\"], input[type=\"email\"], textarea, select").val("");
    $(".formData").find("input[type=\"checkbox\"]").prop('checked', false);

    SetInputHiddenVal("objId", 0);
}


//Methods for getting input fields data

function GetInputHiddenVal(className) {
    return $("." + className + " input[type=\"hidden\"]").val();
}

//Methods for setting input fields data
function SetInputHiddenVal(className, value) {
    $("." + className + " input[type=\"hidden\"]").val(value);
}
